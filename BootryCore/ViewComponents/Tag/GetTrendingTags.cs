using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using System.Linq;
using BootryCore.ViewComponents.Base;

namespace BootryCore.ViewComponents.Tag
{
    public class GetTrendingTags : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            TagManager tm = new ComponentBase().GetTagManager();
            return View(tm.GetAllBL().Take(15));
        }
    }
}
