using Microsoft.AspNetCore.Mvc;
using BootryCore.ViewComponents.Base;

namespace BootryCore.ViewComponents.Writer
{
    public class WriterList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var wm = new ComponentBase().GetWriterManager();
            return View(wm.GetAllBL());
        }
    }
}
