using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using BootryCore.ViewComponents.Base;
using System.Linq;

namespace BootryCore.ViewComponents.Category
{
    public class GetTrendingCategories : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryManager cm = new ComponentBase().GetCategoryManager();
            return View(cm.GetAllBL(x=>x.IsActive==true).Take(15));
        }
    }
}
