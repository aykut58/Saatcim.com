using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class DataContext:DbContext // veritabnı bağlantısı kuruyoruz.
    {
        public DataContext():base("dataConnection") // web configde oluşturduğumuz dataconecction adresini yazıyoruz.
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Product> Products { get; set; } // veritabanında oluşturduğumuz tablolar.
        public DbSet<Category> Categoris { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}