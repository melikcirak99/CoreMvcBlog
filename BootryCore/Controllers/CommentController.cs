using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace BootryCore.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        [HttpPost]
        [AllowAnonymous]
        [Route("yorum-ekle")]
        public IActionResult CreateComment(Comment comment)
        {
            if (HttpContext.Session.GetString("user") != null)
            {
                comment.IsApproved = false;
                comment.CreateDate = System.DateTime.Now;
                comment.UpdateDate = System.DateTime.Now;
                cm.InsertBL(comment);
                return Redirect("/");
            }
            else
            {
                return Redirect("/giris-kullanici");
            }
        }
    }
}
