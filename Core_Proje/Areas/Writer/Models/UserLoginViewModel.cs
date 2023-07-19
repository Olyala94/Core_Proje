﻿using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı Adını giriniz...!")]

        public  string UserName{ get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifreyi giriniz...!")]

        public string Password { get; set; }    
    }
}