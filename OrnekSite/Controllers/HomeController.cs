using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrnekSite.Entity; // veritabanı bağlantısı sağlıyoruz.

namespace OrnekSite.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public PartialViewResult _FeaturedProductList() //onaylı ürünlerin gösterimi
        {
            //onaylı olan ilk 5 ürün listelenecek
            return PartialView(db.Products.Where(i => i.IsApproved && i.IsFeatured).Take(5).ToList());
        }
        public ActionResult Adres()
        {
            return View();
        }
        public ActionResult Search(string q) // arama sonucu gösterilen ürünlerin gösterimi
        {
            var p = db.Products.Where(i => i.IsApproved == true);
            if(!string.IsNullOrEmpty(q))
            {
                p=p.Where(i=>i.Name.Contains(q)||i.Descrition.Contains(q));
            }
            return View(p.ToList());
        }
        public PartialViewResult Slider()// sliderda yer alan ürünlerin gösterimi
        {
            //onaylı olan ilk 5 ürün sliderda yer alıyor.
            return PartialView(db.Products.Where(i => i.IsApproved && i.Slider).Take(5).ToList());
        }
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Products.Where(i=>i.IsHome&&i.IsApproved).ToList()); // anasayfada onaylı ürün gösterimi
        }
        public ActionResult ProductDetails(int id) //ürün detay sayfası gösterimi
        {
            return View(db.Products.Where(i=>i.Id==id).FirstOrDefault());
        }
        public ActionResult Product()
        {
            return View(db.Products.ToList()); // tüm ürünlerin gösterimi
        }
        public ActionResult ProductList(int id)
        {
            return View(db.Products.Where(i=>i.CategoryId==id).ToList());
        }
    }
}