using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public List<Product> Products { get; set; } // ürün ve kategori  arasında ki ilişki kuruldu
    }
}