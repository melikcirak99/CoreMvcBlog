using Microsoft.AspNetCore.Mvc;
using BootryCore.ViewComponents.Base;

namespace BootryCore.ViewComponents.Post
{
    public class MostPopular : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var pm = new ComponentBase().GetPostManager();            
            return View(pm.MostPopular());
        }
    }
}
