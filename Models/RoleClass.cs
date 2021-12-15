using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using TermProjectBookkeeping.DAO;

namespace TermProjectBookkeeping
{
    public class RoleClass : RoleProvider
    {
        UserInfoDAO userinfoDAO = new UserInfoDAO();
        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            /*List<userinfo> userlist = userinfoDAO.GetAllRecords();
            var user = userlist.Where(a => a.email == username).FirstOrDefault().userrole.rolename.ToString();
            string[] roles = { user };

            return roles;*/
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}