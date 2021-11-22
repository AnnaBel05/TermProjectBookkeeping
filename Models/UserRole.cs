using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProjectBookkeeping.Models
{
    public class UserRole
    {
        public int ID { get; set; }
        public string rolename { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}