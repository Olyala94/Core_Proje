using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]  //Bu yazdığımız route "url" li takip ederek işlem yapacaksın "Apilerde" daha iyi göreceğiz bu işemi
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var values = await _userManager.FindByNameAsync(User.Identity.Name);
            //UserRegisterViewModel model = new UserRegisterViewModel();
            //model.ImageUrl = values.ImageUrl;    
            return View(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //if (p.Picture != null)
            //{
            //    var resource = Directory.GetCurrentDirectory();
            //    var extension = Path.GetExtension(p.Picture.FileName);
            //    var imagename = Guid.NewGuid() + extension;
            //    var savelocation = resource + "/wwwroot/createuserimage/" + imagename;
            //    var stream = new FileStream(savelocation, FileMode.Create);
            //    await p.Picture.CopyToAsync(stream);
            //    user.ImageUrl = imagename;
            //}
            WriterUser writerUser = new WriterUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Email,
                UserName = p.UserName,
                ImageUrl = p.ImageUrl,
            };

            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(writerUser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                } 
            }
            return View();
        }
    }
}
