using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IOrderRepository
    {
        void Add(int id, User user);
        void ToggleStatus(int id);
        void Remove(int id);
    }
}
