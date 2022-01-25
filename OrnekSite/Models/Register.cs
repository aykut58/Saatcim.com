using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrnekSite.Models
{
    public class Register
    {
        // kullanıcıdan üye olurken girmesi istenilen bigiler.  
        [Required] // boş bırakılmaması gerektiği için ekliyoruz.
        [DisplayName("Adınız")] // kullanıcını görmesi için ekliyoruz.
        public string Name { get; set; }
        [Required]
        [DisplayName("Soyadınız")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Geçersiz Email Adresi...")]// mail adresi kontrolü mail formatında olmazsa hata verecek
        public string Email { get; set; }
        [Required]
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Şifreler Aynı Değil...")] // şifre kontrolü. şifreler aynı olmazsa hata mesajı verecek
        [DisplayName("Şifre Tekrar")] 
        public string Repassword { get; set; }

    }
}