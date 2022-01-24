using Microsoft.AspNetCore.Mvc;
using BootryCore.ViewComponents.Base;
using System.Linq;

namespace BootryCore.ViewComponents.User
{
    public class GetUserCount : ViewComponent
    {
        public string Invoke()
        {
            var um = new ComponentBase().GetUserManager();
            return um.GetAllBL(x => x.IsActive == true).Count().ToString();
        }
    }
}
