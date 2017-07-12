using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class TrainingController : Controller
    {
        //
        // GET: /Training/

        ITrainingRepository repo;

        public TrainingController(ITrainingRepository obj)
        {
            repo = obj;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddTraining(int id, string title)
        {
            User u = (User)Session["user"];
            repo.Add(u.Id, u.Name, id, title);
            return RedirectToAction("../Home/Training");
        }

        public ActionResult EditTraining(int id)
        {
            repo.ToggleStatus(id);
            return RedirectToAction("../Admin/Trainees");
        }

        public ActionResult RemoveTraining(int id)
        {
            repo.Remove(id);
            return RedirectToAction("../Admin/Trainees");
        }

    }
}
