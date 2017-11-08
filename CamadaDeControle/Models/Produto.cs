using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CamadaDeControle.Models
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoID { get; set; }

        [Display(Name ="Nome do Produto")]
        public string Nome { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name ="Descrição do Produto")]
        public string Descricao { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name ="Preço do Produto")]
        public double Preco { get; set; }
    }
}