using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace BootryCore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        

        public IActionResult Index()
        {
            return View(cm.GetAllBL());
        }
        [Route("admin/onay-bekleyen-yorumlar")]
        
        public IActionResult InActiveComments()
        {
            return View(cm.GetAllBL(x => x.IsApproved == false));
        }

        //comment set inactive
        [Route("admin/yorum-cope-at/{id}")]
        public IActionResult SetInactive(int id)
        {
            cm.AddToTrash(id);
            return Redirect("/admin/onay-bekleyen-yorumlar");
        }

        //comment set active
        [Route("admin/yorum-kurtar/{id}")]
        public IActionResult SetActive(int id)
        {
            cm.OutOfTrash(id);
            return Redirect("/admin/onay-bekleyen-yorumlar");
        }

        //delete comment
        [Route("admin/yorum-sil/{id}")]
        public IActionResult Delete(int id)
        {
            cm.DeleteBL(cm.GetBL(id));
            return Redirect("/admin/onay-bekleyen-yorumlar");
        }
    }
}
