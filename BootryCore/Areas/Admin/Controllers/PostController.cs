using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Newtonsoft.Json;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace BootryCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        PostManager pm = new PostManager(new EfPostRepository());

        public IActionResult Index()
        {
            return View();
        }

        // <<< post adding >>>
        [HttpGet]
        [Route("admin/addpost")]
        public IActionResult Add()
        {
            ViewData["categories"] = GetCategorySelectListItems();
            ViewData["writers"] = GetWriterSelectListItems();
            return View();
        }
        [HttpPost]
        [Route("admin/addpost")]
        public IActionResult Add(Post post)
        {
            PostValidator pv = new PostValidator();
            ValidationResult results = pv.Validate(post);

            if (results.IsValid)
            {
                post.PostCreatedTime = System.DateTime.Now;
                post.PostView = 0;
                pm.InsertBL(post);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }


            ViewData["categories"] = GetCategorySelectListItems();
            ViewData["writers"] = GetWriterSelectListItems();
            return View(post);
        } //post adding end



        // <<< post updating >>>
        [HttpGet]
        [Route("admin/updatepost/{id}")]
        public IActionResult Update(int id)
        {
            
            ViewData["categories"] = GetCategorySelectListItems();
            ViewData["writers"] = GetWriterSelectListItems();
            return View(pm.GetBL(id));
        }

        [HttpPost]
        [Route("admin/updatepost")]
        public IActionResult Update(Post post)
        {

            PostValidator pv = new PostValidator();
            ValidationResult results = pv.Validate(post);

            if (results.IsValid)
            {
                post.PostUpdatedTime = System.DateTime.Now;
                pm.UpdateBL(post);
                return RedirectToAction("Index");
            }
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            ViewData["categories"] = GetCategorySelectListItems();
            ViewData["writers"] = GetWriterSelectListItems();
            return View(post);
        }//post updating end

        [HttpGet]
        [Route("admin/cope-at/{id}")]
        public IActionResult AddToTrash(int id)
        {
            pm.AddToTrash(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("admin/kalici-sil/{id}")]
        public IActionResult Delete(int id)
        {
            pm.DeleteBL(pm.GetBL(id));
            return Redirect("/admin");
        }

        [Route("admin/GetAllPostsToJson")]
        public IActionResult GetAllJson()
        {
            var model = pm.GetAllBL();
            var jsonData = model.Select(x => new
            {
                id = x.PostId,

                title = x.PostTitle,

                viewCount = x.PostView,

                content = x.PostContent,

                createdDate = x.PostCreatedTime,

                fullName = x.Writer.WriterFirstName + " " + x.Writer.WriterLastName,

                category = x.Category.CategoryName,
                x.Comments.Count
            });


            return Json(JsonConvert.SerializeObject(jsonData));
        }

        public IActionResult InTrash()
        {
            return View(pm.GetAllBL(x => x.IsActive == false));
        }
        [Route("admin/copten-cikar/{id}")]
        public IActionResult OutOfTrush(int id)
        {
            pm.OutOfTrash(id);
            return RedirectToAction("InTrash");
        }
        private List<SelectListItem> GetWriterSelectListItems()
        {
            var wm = new WriterManager(new EfWriterRepository());
            List<SelectListItem> writers = (from x in wm.GetAllBL()
                                            select new SelectListItem
                                            {
                                                Text = x.WriterFirstName + " " + x.WriterLastName,
                                                Value = x.WriterId.ToString()
                                            }
                                              ).ToList();
            return writers;
        }
        private List<SelectListItem> GetCategorySelectListItems()
        {
            var cm = new CategoryManager(new EfCategoryRepository());
            List<SelectListItem> categories = (from x in cm.GetAllBL()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }
                                              ).ToList();
            return categories;
        }
    }
}
