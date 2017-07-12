using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class MessageController : Controller
    {
        //
        // GET: /Message/

        IMessageRepository repo;

        public MessageController(IMessageRepository obj)
        {
            repo = obj;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMessage(Contact msg)
        {
            if (ModelState.IsValid)
            {
                msg.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                repo.Add(msg);
                return RedirectToAction("../Home/Index");
            }
            return View("../Home/Contact");
        }

    }
}
