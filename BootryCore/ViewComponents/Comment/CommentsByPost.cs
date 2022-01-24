using BootryCore.ViewComponents.Base;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BootryCore.ViewComponents.Comment
{
    public class CommentsByPost : ViewComponent
    {
        public IViewComponentResult Invoke(int postId)
        {
            CommentManager cm = new ComponentBase().GetCommentManager();
            return View(cm.GetAllBL(x=>x.PostId==postId));
        }
    }
}
