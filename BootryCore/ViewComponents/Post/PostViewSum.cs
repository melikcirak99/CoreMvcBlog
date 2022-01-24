using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using BootryCore.ViewComponents.Base;
using System.Linq;

namespace BootryCore.ViewComponents.Post
{
    public class PostViewSum : ViewComponent
    {
        public string Invoke()
        {
            PostManager pm = new ComponentBase().GetPostManager();
            return pm.GetAllBL(x => x.IsActive == true).Sum(x => x.PostView).ToString();
        }
    }
}
