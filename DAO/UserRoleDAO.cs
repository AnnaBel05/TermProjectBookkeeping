using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TermProjectBookkeeping.Models;

namespace TermProjectBookkeeping.DAO
{
    public class UserRoleDAO : DAO
    {
        public List<UserRole> GetAllUserRoles()
        {
            Connect();
            List<UserRole> roleList = new List<UserRole>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM userrole", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserRole userrole = new UserRole();
                    userrole.ID = Convert.ToInt32(reader["ID"]);
                    userrole.rolename = Convert.ToString(reader["rolename"]);
                    roleList.Add(userrole);
                 
                }
                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            { 
                Disconnect();
            }
            return roleList;
        }
    }
}