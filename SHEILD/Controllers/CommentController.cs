using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.Models;

namespace Application.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        ICommentRepository repo;

        public CommentController(ICommentRepository obj)
        {
            repo = obj;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddComment(Comment comment)
        {
            User user = (User)Session["user"];
            comment.UserId = user.Id;
            comment.UserName = user.Name;
            comment.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            repo.Add(comment);
            return RedirectToAction("../Home/ShowItem", new { id = comment.ItemId });
        }

    }
}
