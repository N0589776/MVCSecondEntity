using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWebApp2.Models
{
    public class Standard
    {
        public int StandardID { get; set; }

        public string StandardName { get; set; }

        public ICollection<Student> Students { get; set; }


    }
}