using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        IOrderRepository repo;

        public OrderController(IOrderRepository obj)
        {
            repo = obj;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrder(int id)
        {
            User u = (User)Session["user"];
            repo.Add(id, u);
            return RedirectToAction("../Home/Index");
        }

        public ActionResult EditOrder(int id)
        {
            repo.ToggleStatus(id);
            return RedirectToAction("../Admin/Orders");
        }

        public ActionResult RemoveOrder(int id)
        {
            repo.Remove(id);
            return RedirectToAction("../Admin/Orders");
        }

    }
}
