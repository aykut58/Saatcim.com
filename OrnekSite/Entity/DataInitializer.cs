using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrnekSite.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext> // modelde değişklik olursa veritabanını siler ve yeniden kurar
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category() {Name="Erkek Saat", Descrition="Erkek Saat Ürünleri" }, // kategori oluşturma işlemi yapılıyor
                new Category() {Name="Kadın Saat", Descrition="Kadın Saat Ürünleri" },
                new Category() {Name="Çocuk Saat", Descrition="Çocuk Saat Ürünleri" }
            };
            foreach (var kategori in kategoriler)
            {
                context.Categoris.Add(kategori);

            }
            context.SaveChanges();
            var urunler = new List<Product>()
            {
                new Product() {Name="E-Model 1", Descrition="erkek saat ürünleri",Price=250,Stock=125,IsHome=true,IsApproved=true,IsFeatured=false,Slider=true,CategoryId=1,image="1.jpg" }, // kategoriler için ürün eklmesi yapıldı
                new Product() {Name="K-Model 1", Descrition="kadın saat ürünleri",Price=200,Stock=120,IsHome=true,IsApproved=true,IsFeatured=true,Slider=true,CategoryId=3,image="2.jpg" },
                new Product() {Name="Ç-Model 1", Descrition="çocuk saat ürünleri",Price=250,Stock=125,IsHome=false,IsApproved=true,IsFeatured=true,Slider=false,CategoryId=3,image="3.jpg" },
            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges(); // bu şekilde ürünler veritabanna ekleme işlemi yapıyoruz.
            base.Seed(context);
        }
    }
}