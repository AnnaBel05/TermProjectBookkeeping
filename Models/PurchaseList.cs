using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProjectBookkeeping.Models
{
    public class PurchaseList
    {
        public int id { get; set; }
        public string purchasename { get; set; }
        public string purchasedescription { get; set; }
        public int sender { get; set; }
        public int quantity { get; set; }
        public int price1pc { get; set; }
        public Nullable<int> overallsum { get; set; }
        public Nullable<bool> ifapproved { get; set; }

        public List<PurchaseList> PurchaseLists { get; set; }
    }
}