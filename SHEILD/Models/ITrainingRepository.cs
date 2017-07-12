using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface ITrainingRepository
    {
        void Add(int uid, string uname, int cid, string title);
        void ToggleStatus(int id);
        void Remove(int id);
    }
}
