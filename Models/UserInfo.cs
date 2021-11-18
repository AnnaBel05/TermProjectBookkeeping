using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TermProjectBookkeeping.Models
{
    public class UserInfo
    {
        public int id { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string patronymic { get; set; }
        public int userroleid { get; set; }
        public virtual userrole userrole { get; set; }

        public List<UserInfo> UserInfoList { get; set; }
    }
}