using BootryCore.ViewComponents.Base;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BootryCore.ViewComponents.Comment
{
    public class InActiveCommentsCount : ViewComponent
    {
        public string Invoke()
        {
            CommentManager cm = new ComponentBase().GetCommentManager();
            return cm.GetAllBL(x => x.IsApproved == false && x.Post.IsActive == true).Count().ToString();
        }
    }
}
