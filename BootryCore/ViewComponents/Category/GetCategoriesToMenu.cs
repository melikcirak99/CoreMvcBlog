using BootryCore.ViewComponents.Base;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BootryCore.ViewComponents.Category
{
    public class GetCategoriesToMenu : ViewComponent
    {
        public IViewComponentResult Invoke(int count)
        {
            CategoryManager cm = new ComponentBase().GetCategoryManager();
            SettingManager sm = new ComponentBase().GetSettingManager();

            ViewBag.siteBrand = sm.GetBL(6).SettingValue;
            var model = cm.GetAllBL().OrderByDescending(x => x.Posts.Count).Take(5);
            return View(model);
        }
    }
}
