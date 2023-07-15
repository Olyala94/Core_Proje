using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistic : ViewComponent
    {
        Context c = new Context(); 
        
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Skills.Count();
            ViewBag.v2 = c.Messages.Where(x=>x.Statuse == false).Count();
            ViewBag.v3 = c.Messages.Where(x=>x.Statuse == true).Count();
            ViewBag.v4 = c.Experiences.Count();

            return View();
        }
    }
}
