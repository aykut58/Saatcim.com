using OrnekSite.Entity;
using OrnekSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrnekSite.Controllers
{
    public class CartController : Controller
    {
        DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        private void SaveOrder (Cart cart,ShippingDetails model) // siparişleri veritabanına aktarma methodu
        {
            var order = new Order(); // sipariş tanımlıyoruz
            order.OrderNumber = "A" + (new Random()).Next(1111, 9999).ToString(); // sipariş numarası tanımlıyoruz.
            order.Total = cart.Total(); // toplam fiyat
            order.OrderDate = DateTime.Now; // sipariş tarihi
            order.UserName = User.Identity.Name; // kullanıcı adı
            order.OrderState = OrderState.Bekleniyor; // sipariş durumu
            order.Adres = model.Adres; // sipariş adresi 
            order.Sehir = model.Sehir;
            order.Semt = model.Semt;
            order.Mahalle = model.Mahalle;
            order.PostaKodu = model.PostaKodu;
            order.OrderLines = new List<OrderLine>();
            foreach (var item in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = item.Quantity;
                orderline.Price = item.Quantity * item.Product.Price;
                orderline.ProductId = item.Product.Id;
                order.OrderLines.Add(orderline);
            }
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails model)
        {
            var cart = GetCart();
            if(cart.CartLines.Count==0)
            {
                ModelState.AddModelError("UrunYok", "Sepetinizde Ürün Bulunmamaktadır...");
            }
            if(ModelState.IsValid)
            {
                SaveOrder(cart, model);
                cart.Clear();
                return View("SiparisTamamlandi");
            }
            else
            {
                return View(model);
            }
            
        }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public PartialViewResult Summary1()
        {
            return PartialView(GetCart());
        }
        public ActionResult RemoveFronCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product!= null)
            {
                GetCart().DeleteProduct(product);
            }
            return RedirectToAction("Index");
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product!=null)
            {
                GetCart().AddProduct(product, 1);

            }
            return RedirectToAction("index");
        }
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}