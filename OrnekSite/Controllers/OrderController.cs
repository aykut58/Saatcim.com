using OrnekSite.Entity;
using OrnekSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekSite.Controllers
{
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrder() //bütün siparişleri getiriyorum.
            {
                Id = i.Id, // siparişin ID'si
                OrderNumber = i.OrderNumber, // sipariş numarası
                OrderDate = i.OrderDate, //sipariş tarihi
                OrderState = i.OrderState, // sipariş durumu
                Total = i.Total, // toplam fiyat
                Count = i.OrderLines.Count // sipariş sayısı
            }).OrderByDescending(i => i.OrderDate).ToList();// siparişi tarihe göre sıralama yapıyoruz.    
            return View(orders);
        }
        public ActionResult Details(int id)
        {
            var model = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetails()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                Total = i.Total,
                UserName = i.UserName,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Adres = i.Adres,
                Sehir = i.Sehir,
                Semt = i.Semt,
                Mahalle = i.Mahalle,
                PostaKodu = i.PostaKodu,
                OrderLines = i.OrderLines.Select(x => new OrdeLineModel()
                {
                    ProductId = x.ProductId,
                    Image = x.Product.image,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList()
            }).FirstOrDefault();
            return View(model);
        }
        public ActionResult UpdateOrderState(int OrderId,OrderState Orderstate)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order!=null)
            {
                order.OrderState = Orderstate;
                db.SaveChanges();
                TempData["mesaj"] = "Bilgiler Kaydedildi";
                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
        public ActionResult BekleyenSiparisler()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Bekleniyor).ToList();
            return View(model);
        }
        public ActionResult TamamlananSiparisler()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Tamamlandı).ToList();
            return View(model);
        }
        public ActionResult PaketlenenSiparisler()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Paketlendi).ToList();
            return View(model);
        }
        public ActionResult KargolananSiparisler()
        {
            var model = db.Orders.Where(i => i.OrderState == OrderState.Kargolandı).ToList();
            return View(model);
        }
    }
}