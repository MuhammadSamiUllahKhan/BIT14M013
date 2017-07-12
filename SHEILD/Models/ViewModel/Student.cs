using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Application.Models.ViewModel
{
    public class Student 
    {
        String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        String cgpa;

        public String Cgpa
        {
            get { return cgpa; }
            set { cgpa = value; }
        }

    }
}
