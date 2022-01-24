using BootryCore.ViewComponents.Base;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BootryCore.ViewComponents.Category
{
    public class GetCategories : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryManager cm = new ComponentBase().GetCategoryManager();
            return View(cm.GetAllBL());
        }
    }
}
