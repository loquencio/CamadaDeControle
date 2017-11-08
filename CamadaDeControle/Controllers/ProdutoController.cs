using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CamadaDeControle.Models;

namespace CamadaDeControle.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Lista(double? precoMaximo, double? precoMinimo = 0)
        {
            //double precoTeste = 20;
            K19Context ctx = new K19Context();

            var p = ctx.Produtos.Where(x => x.Preco >= precoMinimo && x.Preco <= precoMaximo || (x.Preco >= precoMinimo && precoMaximo == null));

            //if (precoMinimo != null)
            //    p = ctx.Produtos.Where(x => x.Preco >= precoMinimo && x.Preco <= precoMaximo);

            //var b = precoTeste >= precoMinimo && precoTeste <= precoMaximo || (precoTeste >= precoMinimo && precoMaximo == null);
            //return Content(precoMinimo + " " + precoMaximo + " Resultado: " + b);

            return View(p);
        }

        [HttpGet]
        public ActionResult Cadastra()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Cadastra(string nome, string descricao, double preco)
        //{
        //    Produto p = new Produto
        //    {
        //        Descricao = descricao,
        //        Nome = nome,
        //        Preco = preco
        //    };

        //    K19Context ctx = new K19Context();

        //    ctx.Produtos.Add(p);
        //    ctx.SaveChanges();
        //    return RedirectToAction("Lista", "Produto");
        //}


        [HttpPost]
        public ActionResult Cadastra(Produto p)
        {
            K19Context ctx = new K19Context();

            ctx.Produtos.Add(p);
            ctx.SaveChanges();

            TempData["Mensagem"] = "Produto cadastrado com sucesso!";
            return RedirectToAction("Lista", "Produto");
        }

        public ActionResult Editar(int id = 0)
        {
            K19Context ctx = new K19Context();
            Produto p = ctx.Produtos.Find(id);

            if (p == null)
                return HttpNotFound();

            return View(p);
        }

        [HttpPost]
        public ActionResult Editar(Produto p)
        {
            K19Context ctx = new K19Context();
            ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;

            ctx.SaveChanges();

            return RedirectToAction("Lista");
        }
    }
}