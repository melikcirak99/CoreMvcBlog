using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.EntityFramework;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace BootryCore.Areas.Admin.Controllers
{
    [Area("admin")]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        
        [Route("admin/yazar")]
        public IActionResult Index()
        {
            return View(wm.GetAllBL());
        }

        //writer add
        [HttpGet]
        [Route("admin/yazar-ekle")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/yazar-ekle")]
        public IActionResult Add(Writer writer)
        {

            WriterValidator pv = new WriterValidator();
            ValidationResult results = pv.Validate(writer);

            if (results.IsValid)
            {
                writer.IsActive = true;
                wm.InsertBL(writer);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(writer);
        }


        //writer update
        [HttpGet]
        [Route("admin/yazar-duzenle/{id}")]
        public IActionResult Update(int id)
        {
            return View(wm.GetBL(id));
        }

        [HttpPost]
        [Route("admin/yazar-duzenle")]
        public IActionResult Update(Writer writer)
        {

            WriterValidator pv = new WriterValidator();
            ValidationResult results = pv.Validate(writer);

            if (results.IsValid)
            {
                wm.UpdateBL(writer);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(writer);
        }

        [HttpGet]
        [Route("admin/yazar-sil/{id}")]
        public IActionResult Delete(int id)
        {
            wm.SetInActive(id);
            return Redirect("/admin/yazar");
        }

    }
}
