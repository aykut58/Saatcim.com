using OrnekSite.Entity;
using OrnekSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataContext db = new DataContext(); // veritabanına bağlantı sağlıyoruz
        [Authorize(Roles = "admin")]// bu bölüme erişimi sadece admin rolüne atama yapıyoruz.
        public ActionResult Index()
        {
            StateModel model = new StateModel();// model ile veritabanını ilişkilendirdik
            //istenilen kritere göre olan siparişleri seçiyoruz.
            model.BekleyenSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList().Count();
            model.TamamlananSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList().Count();
            model.PaketlenenSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList().Count();
            model.KargolananSiparisSayisi = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList().Count();
            model.UrunSayisi = db.Products.Count();
            model.SiparisSayisi = db.Orders.Count();
            return View(model);
        }
        public PartialViewResult BildirimMenusu()
        {
            var bildirim = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return PartialView(bildirim);
        }
    }
}