using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class Order
    {
        // satılan ürünlerin bilgilerini veritabanına taşıyoruz.
        public int Id { get; set; } // ürün ID'si
        public string OrderNumber { get; set; } // sipariş numarası
        public double Total { get; set; } // toplam tutar
        public DateTime OrderDate { get; set; } // sipariş tarihi
        public OrderState OrderState { get; set; } // kimin ispariş ettiği
        public string UserName { get; set; } // kullanıcı bilgileri
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Semt { get; set; }
        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }
        public virtual List<OrderLine> OrdeLines { set; get; }
        public List<OrderLine> OrderLines { get; internal set; }
    }
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}