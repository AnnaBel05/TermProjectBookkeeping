using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using TermProjectBookkeeping.Models;
using TermProjectBookkeeping;

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
        public List<userrole> GetAllRecords()
        {
            Connect();
            List<userrole> roleList = new List<userrole>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM userrole", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userrole userroleObj = new userrole();
                    userroleObj.id = Convert.ToInt32(reader["id"]);
                    userroleObj.rolename = Convert.ToString(reader["rolename"]);
                    roleList.Add(userroleObj);
                 
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

        public userrole GetRecord(int id)
        {
            Connect();
            userrole userroleObj = new userrole();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM userrole where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                userroleObj.id = Convert.ToInt32(reader["id"]);
                userroleObj.rolename = Convert.ToString(reader["rolename"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return userroleObj;
        }

        public bool UpdateRecord(int id, userrole userroleObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE userrole SET rolename = @RoleName WHERE id = @ID", Con);
                
                cmd.Parameters.Add(new SqlParameter("@RoleName", userroleObj.rolename));
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

        public bool AddRecord(userrole userroleObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO userrole(rolename) VALUES (@RoleName)", Con);
                cmd.Parameters.Add(new SqlParameter("@RoleName", userroleObj.rolename));
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

        public bool DeleteRecord(int id, userrole userroleObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM userrole WHERE id=@ID", Con);
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