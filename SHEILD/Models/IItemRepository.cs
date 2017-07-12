using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IItemRepository
    {
        void Add(Item item);
        List<Item> GetAll();
        void Remove(int id);
        void Edit(Item item);
    }
}
