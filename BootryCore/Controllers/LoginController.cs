using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace BootryCore.Controllers
{
    public class LoginController : Controller
    {
        Context db = new Context();
        [HttpGet]
        [Route("giris-{type}")]
        // GET: Logins
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("giris-{type}")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(string Mail, string Password)
        {
            if (Mail == null || Password == null)
            {
                ViewBag.message = "tüm bilgileri doldurun";
                return View("Login");
            }
            else
            {
                //admin için kontrol
                if (RouteData.Values["type"].ToString() == "admin")
                {
                    Admin _query = db.Admins.Where(x => x.AdminMail == Mail && x.AdminPassword == Password).FirstOrDefault();
                    if (_query != null)
                    {
                        //giriş başarılı
                        var admin = JsonConvert.SerializeObject(_query).ToString();
                        HttpContext.Session.SetString("admin", admin);
                        HttpContext.Session.SetInt32("adminId", _query.AdminId);

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,_query.AdminMail)
                        };
                        var adminIdentity = new ClaimsIdentity(claims, "a");
                        ClaimsPrincipal principal = new ClaimsPrincipal(adminIdentity);
                        await HttpContext.SignInAsync(principal);
                        return Redirect("/admin");
                    }
                    else
                    {
                        ViewBag.message = "0";
                        return View("Login");
                    }
                }

                //yazar için kontrol
                else if (RouteData.Values["type"].ToString() == "yazar")
                {
                    var _query = db.Writers.Where(x => x.WriterMail == Mail && x.WriterPassword == Password).FirstOrDefault();
                    if (_query != null)
                    {
                        //giriş başarılı
                        var writer = JsonConvert.SerializeObject(_query);
                        HttpContext.Session.SetString("writer", writer);
                        HttpContext.Session.SetInt32("writerId", _query.WriterId);
                        HttpContext.Session.SetString("writerFullName", _query.WriterFirstName + " " + _query.WriterLastName);

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,_query.WriterMail)
                        };
                        var writerIdentity = new ClaimsIdentity(claims, "a");
                        ClaimsPrincipal principal = new ClaimsPrincipal(writerIdentity);
                        await HttpContext.SignInAsync(principal);
                        return Redirect("/Admin");
                    }
                    else
                    {
                        ViewBag.message = "0";
                        return View("Login");
                    }
                }

                //kulllanıcı için kontrol
                else if (RouteData.Values["type"].ToString() == "kullanici")
                {
                    var _query = db.Users.Where(x => x.UserMail == Mail && x.UserPassword == Password).FirstOrDefault();
                    if (_query != null)
                    {
                        //giriş başarılı
                        var user = JsonConvert.SerializeObject(_query).ToString();
                        HttpContext.Session.SetString("user", user);

                        return Redirect("/");
                    }
                    else
                    {
                        ViewBag.message = "kullanıcı adı yada şifre hatalı";
                        return View("Login");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
        }

        [Route("/LogOut")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return Redirect("/giris-yazar");
        }
    }
}
