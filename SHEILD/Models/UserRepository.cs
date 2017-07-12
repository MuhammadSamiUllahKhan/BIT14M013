using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class UserRepository : IUserRepository
    {
        SiteDataEntities2 de = new SiteDataEntities2();
        public void Add(User user)
        {
            de.Users.Add(user);
            de.SaveChanges();
        }

        public User Search(User user)
        {
            try
            {
                return de.Users.First(u => u.Email.Equals(user.Email) && u.Password.Equals(u.Password));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Remove(int id)
        {
            User user = de.Users.First(x => x.Id == id);
            de.Users.Remove(user);
            de.SaveChanges();
        }


        public bool ValidateEmail(string email)
        {
            try
            {
                de.Users.First(u => u.Email.Equals(email));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckUsername(string email)
        {
            try
            {
                de.Users.First(u => u.Email.Equals(email));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void Update(User user)
        {
            User u = de.Users.First(x => x.Id == user.Id);

            u.Name = user.Name;
            u.Address = user.Address;
            u.Number = user.Number;
            u.Password = user.Password;

            de.Entry(u).State = System.Data.EntityState.Modified;

            de.SaveChanges();
        }
    }
}