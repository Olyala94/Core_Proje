using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class LastFiveProjects :ViewComponent
    {
   
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
