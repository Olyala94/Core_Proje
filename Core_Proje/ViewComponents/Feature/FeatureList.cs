using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Feature
{
    //Ekliyecegimiz klasorin ismi -> oluşturdugumuz ViewComponent icindeki klasin ismi ile ayni olmalidir
    //Ekliyecegimiz "View'in" ismi "Default" -> olmak zorunda!!!!
    public class FeatureList : ViewComponent  
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

        public IViewComponentResult Invoke() 
        {
            var values = featureManager.TGetList();
            return View(values); 
        }
    }
}
