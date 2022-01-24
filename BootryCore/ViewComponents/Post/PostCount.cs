using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using BootryCore.ViewComponents.Base;
using System.Linq;

namespace BootryCore.ViewComponents.Post
{
    public class PostCount : ViewComponent
    {
        public string Invoke()
        {
            return new ComponentBase().GetPostManager().GetAllBL(x => x.IsActive == true).Count().ToString();
        }
    }
}
