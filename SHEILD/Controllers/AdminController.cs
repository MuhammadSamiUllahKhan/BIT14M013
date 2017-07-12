using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        SiteDataEntities1 data = new SiteDataEntities1();

        public bool CheckAdmin()
        {
            if (Session["user"] == null)
            {
                return false;
            }
            else
            {
                User u = (User)Session["user"];
                if (u.Email.Equals("admin@gmail.com"))
                    return true;
                else
                    return false;
            }
        }

        public ActionResult Index()
        {
            if (CheckAdmin())
                return View();
            else
                return RedirectToAction("../Home/Index");
        }

        public ActionResult Items()
        {
            if (CheckAdmin())
                return View(data.Items.OrderBy(m => m.Name).ToList());
            else
                return RedirectToAction("../Home/Index");
        }

        public ActionResult Courses()
        {
            if (CheckAdmin())
                return View(data.Courses.OrderBy(m => m.Title).ToList());
            else
                return RedirectToAction("../Home/Index");
        }

        public ActionResult Messages()
        {
            if (CheckAdmin())
                return View(data.Contacts.OrderBy(x => x.Date).ToList());
            else
                return RedirectToAction("../Home/Index");
        }

        public ActionResult Users()
        {
            if (CheckAdmin())
                return View(data.Users.OrderBy(m => m.Name).ToList());
            else
                return RedirectToAction("../Home/Index");
        }

        public ActionResult Trainees()
        {
            if (CheckAdmin())
                return View(data.Trainings.ToList());
            else
                return RedirectToAction("../Home/Index");
        }

        public ActionResult Orders()
        {
            if (CheckAdmin())
                return View(data.Orders.ToList());
            else
                return RedirectToAction("../Home/Index");
        }

    }
}
