using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TermProjectBookkeeping.Models;

namespace TermProjectBookkeeping.DAO
{
    /* 
       GetAllRecords - SELECT ALL       : check
       GetRecord - SELECT ONE by ID     : check
       UpdateRecord - UPDATE ONE by ID  : check
       AddRecord - ADD ONE              : check
       DeleteRecord - DELETE ONE by ID  : check    
    */
    public class UserRoleDAO : DAO
    {
        public List<UserRole> GetAllRecords()
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
                    userrole.ID = Convert.ToInt32(reader["id"]);
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

        public UserRole GetRecord(int id)
        {
            Connect();
            UserRole userrole = new UserRole();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM userrole where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                userrole.ID = Convert.ToInt32(reader["id"]);
                userrole.rolename = Convert.ToString(reader["rolename"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return userrole;
        }

        public bool UpdateRecord(int id, UserRole userrole)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE userrole SET rolename = @RoleName WHERE id = @ID", Con);
                
                cmd.Parameters.Add(new SqlParameter("@RoleName", userrole.rolename));
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public bool AddRecord(UserRole userrole)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO userrole(rolename) VALUES (@RoleName)", Con);
                cmd.Parameters.Add(new SqlParameter("@RoleName", userrole.rolename));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }

        public bool DeleteRecord(int id, UserRole userrole)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM userrole WHERE Id=@ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                Disconnect();
            }
            return result;
        }
    }
}