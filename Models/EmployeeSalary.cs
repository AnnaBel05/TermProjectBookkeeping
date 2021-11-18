using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProjectBookkeeping.Models
{
    public class EmployeeSalary
    {
        public int id { get; set; }
        public Nullable<int> employee { get; set; }
        public Nullable<int> hourlyrate { get; set; }
        public Nullable<int> overwork { get; set; }
        public Nullable<int> sickdays { get; set; }
        public Nullable<int> bonus { get; set; }
    }
}