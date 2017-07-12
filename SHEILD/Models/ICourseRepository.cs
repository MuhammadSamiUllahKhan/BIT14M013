using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface ICourseRepository
    {
        void Add(Course c);
        void Remove(int id);
        void Edit(Course c);
    }
}
