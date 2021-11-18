using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProjectBookkeeping.Models
{
    public class StudentScholarship
    {
        public int id { get; set; }
        public int student { get; set; }
        public int grades { get; set; }
        public int scholarshiptype { get; set; }
        public bool ifsocial { get; set; }
        public bool ifsocialhelp { get; set; }
    }
}