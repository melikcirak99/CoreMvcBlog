using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace BootryCore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class UserController : Controller
    {
        UserManager um = new UserManager(new EfUserRepository());
        
        [Route("admin/kullanici")]
        public IActionResult Index()
        {
            return View(um.GetAllBL());
        }

        //writer add
        [HttpGet]
        [Route("admin/kullanici-ekle")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/kullanici-ekle")]
        public IActionResult Add(User user)
        {

            UserValidator pv = new UserValidator();
            ValidationResult results = pv.Validate(user);

            if (results.IsValid)
            {
                user.IsActive = true;
                um.InsertBL(user);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(user);
        }


        //writer update
        [HttpGet]
        [Route("admin/kullanici-duzenle/{id}")]
        public IActionResult Update(int id)
        {
            return View(um.GetBL(id));
        }

        [HttpPost]
        [Route("admin/kullanici-duzenle")]
        public IActionResult Update(User user)
        {

            UserValidator pv = new UserValidator();
            ValidationResult results = pv.Validate(user);

            if (results.IsValid)
            {
                um.UpdateBL(user);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(user);
        }

        [HttpGet]
        [Route("admin/kullanici-sil/{id}")]
        public IActionResult Delete(int id)
        {
            return Redirect("/admin/yazar");
        }

    }
}
