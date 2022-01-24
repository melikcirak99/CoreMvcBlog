using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;


namespace BootryCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SettingController : Controller
    {
        SettingManager sm = new SettingManager(new EfSettingRepository());

        [Route("admin/ayarlar")]
        public IActionResult Index()
        {
            return View(sm.GetAllBL());
        }


        [HttpGet]
        [Route("admin/ayar-ekle")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("admin/ayar-ekle")]
        public IActionResult Add(Setting setting)
        {
            SettingValidator sv = new SettingValidator();
            ValidationResult results = sv.Validate(setting);

            if (results.IsValid)
            {
                sm.InsertBL(setting);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(setting);
        }

        [HttpGet]
        [Route("admin/ayar/{id}")]
        public IActionResult Update(int id)
        {
            return View(sm.GetBL(id));
        }
        [HttpPost]
        [Route("admin/ayar-duzenle")]
        public IActionResult Update(Setting setting)
        {
            SettingValidator sv = new SettingValidator();
            ValidationResult results = sv.Validate(setting);

            if (results.IsValid)
            {
                sm.UpdateBL(setting);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(setting);
        }


    }
}
