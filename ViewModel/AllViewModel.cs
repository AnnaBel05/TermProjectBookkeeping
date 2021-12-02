using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TermProjectBookkeeping.DAO;

namespace TermProjectBookkeeping.ViewModel
{
    public class AllViewModel
    {
        public IEnumerable<purchaselist> purchaselists { get; set; }
        public IEnumerable<employeesalary> employeesalaries { get; set; }
    }
}