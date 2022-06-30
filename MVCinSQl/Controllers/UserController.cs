using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCinSQl.Models;
using System;

namespace MVCinSQl.Controllers
{
    public class UserController : Controller
    {
        UserDAL context = new UserDAL();
        private object form;
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(IFormCollection form)
        {
            User u = new User();
            u.FullName = form["FullName"].ToString();
            u.EmailId = form["EmailId"].ToString();
            u.Password = form["Password"].ToString();
            u.RoleId = 2;
            int res = context.Save(u);
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(IFormCollection form)
        {
            User u = new User();
            u.EmailId = form["EmailId"].ToString();
            u.Password = form["Password"].ToString();
            bool res = context.Verify(u);
            if (res == true)
            {
                return RedirectToAction("Index", "Product");
            }
            else
            {
                ViewBag.Message = "Invalid Entry";
                return View();
            }
        }
        public IActionResult Invalid()
        {
            TempData["alertMessage"] = "Invalid Email-id or Password";
            return View();
        }

    }
}
