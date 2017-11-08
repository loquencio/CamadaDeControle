using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CamadaDeControle.Models
{
    public class K19Context : DbContext
    {

        public K19Context()
        {

        }

        public DbSet<Produto> Produtos { get; set; }


    }
}