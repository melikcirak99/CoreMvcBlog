using BootryCore.ViewComponents.Base;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BootryCore.ViewComponents.Comment
{
    public class CommentCount : ViewComponent
    {
        public string Invoke()
        {
            CommentManager cm = new ComponentBase().GetCommentManager();
            return cm.GetAllBL(x => x.IsApproved == true && x.Post.IsActive == true).Count().ToString();
        }
    }
}
