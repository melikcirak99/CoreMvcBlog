using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using X.PagedList;
using System;

namespace BootryCore.Controllers
{
    [AllowAnonymous]
    public class PostController : Controller
    {
        PostManager pm = new PostManager(new EfPostRepository());
        //post list
        public IActionResult Index()
        {
            SettingManager sm = new SettingManager(new EfSettingRepository());
            Setting ayar = sm.GetBL(5);

            ViewBag.ByCategorySectionValue = Convert.ToInt32(ayar.SettingValue);
            ViewBag.SiteName = sm.GetBL(1).SettingValue;
            return View();
        }

        //Post Detail
        [Route("{kategori}/{seoTitle}")]
        public IActionResult SinglePage(string seoTitle)
        {
            var post = pm.GetPostsBySeoTitle(seoTitle);
            pm.PostViewIncrement(post.PostId);

            ViewBag.Prev = pm.GetAllBL(x => x.PostId < post.PostId).LastOrDefault();
            ViewBag.Next = pm.GetBL(x => x.PostId > post.PostId);
            return View(post);
        }

        //search
        [Route("post/search")]
        [HttpGet]
        public IActionResult Search(string src, int page = 1)
        {
            ViewBag.query = src;
            return View(pm.Search(src).ToPagedList(page, 4));
        }

        //Categories page (posts by category)
        [Route("kategori/{kategori}")]
        public IActionResult ListByCategories(string kategori, int page = 1)
        {
            ViewBag.category = kategori;
            return View(pm.GetAllBL(x => x.Category.CategoryName == kategori && x.IsActive==true).ToPagedList());
        }

    }
}
