﻿using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly SignInManager<WriterUser> _signinManager;

        public LoginController(SignInManager<WriterUser> signinManager)
        {
            _signinManager = signinManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> Index(UserLoginViewModel p )
        {
           if(ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(p.UserName, p.Password, true, true);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile");   
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }
           return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signinManager.SignOutAsync();    
            return RedirectToAction("Index", "Login");
        }
    }
}
