using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class TrainingRepository : ITrainingRepository
    {
        SiteDataEntities2 de = new SiteDataEntities2();
        public void Add(int uid, string uname, int cid, string title)
        {
            Training t = new Training()
            {
                UserId = uid,
                UserName = uname,
                CourseId = cid,
                CourseName = title,
                Fee_Status = "Pending"
            };
            de.Trainings.Add(t);
            de.SaveChanges();
        }

        public void ToggleStatus(int id)
        {
            Training t = de.Trainings.First(x => x.Id == id);

            if (t.Fee_Status.Equals("Pending"))
            {
                t.Fee_Status = "Paid";
            }
            else 
            {
                t.Fee_Status = "Pending";
            }

            de.Entry(t).State = System.Data.EntityState.Modified;
            de.SaveChanges();
        }
        public void Remove(int id)
        {
            Training t = de.Trainings.First(x => x.Id == id);
            de.Trainings.Remove(t);
            de.SaveChanges();
        }
    }
}