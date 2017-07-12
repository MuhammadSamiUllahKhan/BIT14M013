using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    
    public class UserController : Controller
    {
        //
        // GET: /User/

        IUserRepository repo;

        public UserController(IUserRepository obj)
        {
            repo = obj;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                    repo.Add(user);
                    Session["user"] = user;
                    return RedirectToAction("../Home/Index");
            }
            return View("../Home/Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUser(User user)
        {
            if (ModelState.IsValid)
            {
                repo.Update(user);
                Session["user"] = user;
                return RedirectToAction("../Home/Profile");
            }
            return View("../Home/Profile");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (user.Email.Equals("admin@gmail.com") && user.Password.Equals("admin"))
            {
                Session["user"] = new User(){ 
                    Email = "admin@gmail.com",
                    Password = "admin",
                    Name = "admin"
                };
                return RedirectToAction("../Admin/Index");
            }
            else
            {
                user = repo.Search(user);
                if (user != null)
                {
                    Session["user"] = user;
                }
                return RedirectToAction("../Home/Index");
            }
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("../Home/Index");
        }

        public ActionResult RemoveUser(int id)
        {
            repo.Remove(id);
            return RedirectToAction("../Admin/Users");
        }

        //public JsonResult CheckUserName()
        //{

        //    string userName = (string)Request["Name"];

        //    if(repo.CheckUsername(userName))
        //        return this.Json(true, JsonRequestBehavior.AllowGet);
        //    else
        //        return this.Json(false, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult Check(string email)
        {
            if (repo.CheckUsername(email))
                return Json(false, JsonRequestBehavior.AllowGet);
            else
                return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
