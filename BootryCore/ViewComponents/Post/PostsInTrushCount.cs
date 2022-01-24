using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using BootryCore.ViewComponents.Base;

namespace BootryCore.ViewComponents.Post
{
    public class PostsInTrushCount : ViewComponent
    {
        public string Invoke()
        {
            return new ComponentBase().GetPostManager().PostsInTrushCount().ToString();
        }
    }
}
