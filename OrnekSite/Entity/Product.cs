using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descrition { get; set; }
        public string image { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool Slider { get; set; } // slider kısmında yer alacak ürünler.
        public bool IsHome { get; set; } // anasayfada yer alacak ürünler.
        public bool IsFeatured { get; set; } // öne çıkan ürünler.
        public bool IsApproved { get; set; } // onaylı ürünler. false olursa kullanıcılara gözükmez admin görür.
        public int CategoryId { get; set; }  
        public Category Category { get; set; } //her bir ürünün bir kategorisi olsun istiyorum.

    }
}