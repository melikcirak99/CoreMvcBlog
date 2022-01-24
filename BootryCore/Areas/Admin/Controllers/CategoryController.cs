using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace BootryCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        [Route("admin/kategori")]
        public IActionResult Index()
        {
            var categories = cm.GetAllBL();
            return View(categories);
        }

        [HttpGet]
        [Route("admin/kategori-ekle")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/kategori-ekle")]
        public IActionResult Add(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(category);
            if (results.IsValid)
            {
                cm.InsertBL(category);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(category);
        }

        [HttpGet]
        [Route("admin/kategori-duzenle/{id}")]
        public IActionResult Update(int id)
        {
            return View(cm.GetBL(id));
        }

        [HttpGet]
        [Route("admin/kategori-duzenle")]
        public IActionResult Update(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(category);
            if (results.IsValid)
            {
                cm.UpdateBL(category);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(category);
        }

    }
}
