using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BootryCore.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        
        [HttpGet]
        [Route("/profilim/{id}")]
        public IActionResult Index(int id)
        {
            if(HttpContext.Session.GetString("user") != null)
            {
                User user = um.GetBL(id);
                ViewBag.user = user;
                return View(um.GetBL(user.UserId));
            }
            return Redirect("/kullanici-kayit");
        }

        [Route("kullanici-kayit")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [Route("kullanici-kayit")]
        [HttpPost]
        public IActionResult Register(User user)
        {
            UserValidator pv = new UserValidator();
            ValidationResult results = pv.Validate(user);

            if (results.IsValid)
            {
                um.InsertBL(user);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(user);
        }


        [Route("kullanici-duzenle")]
        [HttpPost]
        public IActionResult Update(User user)
        {
            UserValidator pv = new UserValidator();
            ValidationResult results = pv.Validate(user);

            if (results.IsValid)
            {
                um.UpdateBL(user);
                ViewBag.user = user;
                return Redirect("/profilim/"+user.UserId);
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return RedirectToAction("Index", new { id=user.UserId});
        }

        public IActionResult LogoutUser()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
