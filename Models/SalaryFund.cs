using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProjectBookkeeping.Models
{
    public class SalaryFund
    {
        public int id { get; set; }
        public int worktime { get; set; }
        public int overwork { get; set; }
        public int sickdays { get; set; }
        public int totalsum { get; set; }
        public System.DateTime formationdate { get; set; }

        public List<SalaryFund> SalaryFunds { get; set; }
    }
}