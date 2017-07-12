using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/

        ICourseRepository repo;

        public CourseController(ICourseRepository obj)
        {
            repo = obj;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCourse(Course c)
        {
            repo.Add(c);
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                file.SaveAs(Server.MapPath(@"~\Content\themes\base\images\" + "c" + c.Id + ".jpg"));
            }
            return RedirectToAction("../Admin/Courses");
        }

        public ActionResult EditCourse(Course c)
        {
            repo.Edit(c);
            return RedirectToAction("../Admin/Courses");
        }

        public ActionResult RemoveCourse(int id)
        {
            repo.Remove(id);
            return RedirectToAction("../Admin/Courses");
        }

    }
}
