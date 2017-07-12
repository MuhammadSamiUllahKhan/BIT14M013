using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class MessageRepository : IMessageRepository
    {
        SiteDataEntities2 de = new SiteDataEntities2();
        public void Add(Contact msg)
        {
            de.Contacts.Add(msg);
            de.SaveChanges();
        }
    }
}