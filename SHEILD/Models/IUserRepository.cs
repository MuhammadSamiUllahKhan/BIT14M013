using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        User Search(User user);
        void Remove(int id);
        bool ValidateEmail(string email);
        bool CheckUsername(string username);
    }
}
