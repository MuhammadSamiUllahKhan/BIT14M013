using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class OrderRepository : IOrderRepository
    {
        SiteDataEntities2 de = new SiteDataEntities2();
        public void Add(int id, User user)
        {
            Item item = de.Items.First(x => x.Id == id);
            Order order = new Order() 
            {
                UserId = user.Id,
                UserName = user.Name,
                ItemId = item.Id,
                ItemName = item.Name,
                Price = item.Price,
                Destination = user.Address,
                FeeStatus = "Pending"
            };

            de.Orders.Add(order);
            de.SaveChanges();
        }

        public void ToggleStatus(int id)
        {
            Order o = de.Orders.First(x => x.Id == id);

            if (o.FeeStatus.Equals("Pending"))
            {
                o.FeeStatus = "Paid";
            }
            else
            {
                o.FeeStatus = "Pending";
            }

            de.Entry(o).State = System.Data.EntityState.Modified;
            de.SaveChanges();
        }
        public void Remove(int id)
        {
            Order o = de.Orders.First(x => x.Id == id);
            de.Orders.Remove(o);
            de.SaveChanges();
        }
    }
}