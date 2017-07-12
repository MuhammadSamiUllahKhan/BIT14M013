using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class ItemController : Controller
    {
        //
        // GET: /Item/
        SiteDataEntities1 de = new SiteDataEntities1();

        IItemRepository repo;

        public ItemController(IItemRepository obj)
        {
            repo = obj;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
                repo.Add(item);
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    file.SaveAs(Server.MapPath(@"~\Content\themes\base\images\" + item.Id + ".jpg"));
                }
                return RedirectToAction("../Admin/Items");
            }
            return View();
        }

        public ActionResult EditItem(int id)
        {
            return View(de.Items.First(x => x.Id == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem(Item item)
        {
            if (ModelState.IsValid)
            {
                repo.Edit(item);
                return RedirectToAction("../Admin/Items");
            }
            return View();
        }

        public ActionResult RemoveItem(int id)
        {
            repo.Remove(id);
            return RedirectToAction("../Admin/Items");
        }

    }
}
