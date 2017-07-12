using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        SiteDataEntities2 de = new SiteDataEntities2();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View(de.Items.Where(x => x.Type.Equals("Product")).OrderBy(x => x.Name).ToList());
        }

        public ActionResult Services()
        {
            return View(de.Items.Where(x => x.Type.Equals("Service")).OrderBy(x => x.Name).ToList());
        }

        public ActionResult Training()
        {
            return View(de.Courses.OrderBy(x => x.Title).ToList());
        }

        public ActionResult Employment()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult ShowItem(int id)
        {
            ViewBag.comments = de.Comments.Where(x => x.ItemId == id).OrderBy(x => x.Date).ToList();
            return View(de.Items.First(x => x.Id == id));
        }

        public ActionResult Search()
        {
            string input = Request["input"];
            List<Item> list = de.Items.ToList();



            string[] arr = input.Split(' ');

            foreach (string s in arr)
            {
                list = list.Where(x => x.Name.ToLower().Contains(s)).ToList();
            }

            return View(list);
        }

        public ActionResult Profile()
        {
            User u = (User)Session["user"];
            return View(de.Users.First(x => x.Id == u.Id));
        }

    }
}
