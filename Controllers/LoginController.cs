﻿using CRUD_MVC_WebApplication.Models;
using CRUD_MVC_WebApplication.Repository;
using System.Web.Mvc;

namespace CRUD_MVC_WebApplication.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(UserModel user)
        {
            UserAuthentication UA = new UserAuthentication();
            bool check = UA.GetLogin(user);
            if (check)
            {
                System.Web.HttpContext.Current.Application.Lock();
                System.Web.HttpContext.Current.Application["UserIdentifier"] = user.UserType.ToString();
                System.Web.HttpContext.Current.Application.UnLock();
                return RedirectToAction("GetAllEmpDetails", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}