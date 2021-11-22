using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProjectBookkeeping.Models
{
    public class ScholarshipFund
    {
        public int id { get; set; }
        public System.DateTime formationdate { get; set; }
        public int scholarshipsocial { get; set; }
        public int scholarshipgreat { get; set; }
        public int scholarshipgreatperfect { get; set; }
        public int scholarshipperfect { get; set; }
        public int basescholarship { get; set; }
        public int totalsum { get; set; }

        public List<ScholarshipFund> ScolarshipFunds { get; set; }
    }
}