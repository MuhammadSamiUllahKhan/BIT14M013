using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Application.Models
{
    public class ItemRepository : IItemRepository
    {
        SiteDataEntities2 de = new SiteDataEntities2();
        public void Add(Item item)
        {
            de.Items.Add(item);
            de.SaveChanges();
        }

        public List<Item> GetAll()
        {
            return de.Items.ToList();
        }

        public void Remove(int id)
        {
            Item item = de.Items.First(x => x.Id == id);
            de.Items.Remove(item);
            de.SaveChanges();
        }

        public void Edit(Item item)
        {
            Item i = de.Items.First(x => x.Id == item.Id);

            i.Name = item.Name;
            i.Price = item.Price;
            i.Type = item.Type;
            i.Description = item.Description;

            de.Entry(i).State = EntityState.Modified;

            de.SaveChanges();
        }

    }
}