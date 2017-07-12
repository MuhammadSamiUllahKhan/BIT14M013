using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Application.Models
{
    public class CourseRepository : ICourseRepository
    {
        SiteDataEntities2 de = new SiteDataEntities2();
        public void Add(Course c)
        {
            de.Courses.Add(c);
            de.SaveChanges();
        }

        public void Remove(int id)
        {
            Course c = de.Courses.First(x => x.Id == id);
            de.Courses.Remove(c);
            de.SaveChanges();
        }

        public void Edit(Course c)
        {
            Course course = de.Courses.First(x => x.Id == c.Id);

            course.Title = c.Title;
            course.Duration = c.Duration;
            course.Description = c.Description;
            course.Fee = c.Fee;

            de.Entry(course).State = EntityState.Modified;

            de.SaveChanges();
        }
    }
}