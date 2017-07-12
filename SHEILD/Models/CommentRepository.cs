using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Models;

namespace Application.Models
{
    public class CommentRepository : ICommentRepository
    {
        SiteDataEntities2 de = new SiteDataEntities2();
        public void Add(Comment comment)
        {
            de.Comments.Add(comment);
            de.SaveChanges();
        }
    }
}