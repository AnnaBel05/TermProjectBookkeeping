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
        UserRoleDAO userroleDAO = new UserRoleDAO();
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
            using (bookkeepingEntities2 db = new bookkeepingEntities2())
            {
                var user = db.userinfo.Include("userrole").Where(a => a.email == username).FirstOrDefault().userrole.rolename;
                string[] role = { user };
                return role;
            }

            //throw new NotImplementedException();
        }

        /*
        public override string[] GetRolesForUser(string username)
        {
            List<userrole> userrole = userroleDAO.GetAllRecords();
            string[] roleArray;
            List<string> roles = new List<string>();
            int count = 0;
            foreach (userrole i in userrole)
            {
                roles.Add(i.rolename);
                count += 1;
            }

            roleArray = new string[count];

            count = 0;
            foreach (string str in roles)
            {
                roleArray[count] = str;
                count += 1;
            }

            return roleArray;
            //throw new NotImplementedException();
        }

        */

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