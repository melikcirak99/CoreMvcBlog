using BootryCore.ViewComponents.Base;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BootryCore.ViewComponents.Category
{
    public class GetSideBarCategories : ViewComponent
    {
        public IViewComponentResult Invoke(int count)
        {
            CategoryManager cm = new ComponentBase().GetCategoryManager();
            var model = cm.GetAllBL().OrderByDescending(x => x.Posts.Count).Take(count);
            return View(model);
        }
    }
}
