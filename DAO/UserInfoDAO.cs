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
    public class UserInfoDAO : DAO
    {
        public List<UserInfo> GetAllRecords()
        {
            Connect();
            List<UserInfo> infoList = new List<UserInfo>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM userinfo", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserInfo userinfo = new UserInfo();
                    userinfo.id = Convert.ToInt32(reader["id"]);
                    userinfo.lastname = Convert.ToString(reader["lastname"]);
                    userinfo.username = Convert.ToString(reader["username"]);
                    userinfo.patronymic = Convert.ToString(reader["patronymic"]);
                    userinfo.userroleid = Convert.ToInt32(reader["userroleid"]);
                    infoList.Add(userinfo);

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
            return infoList;
        }

        public UserInfo GetRecord(int id)
        {
            Connect();
            UserInfo userinfo = new UserInfo();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM userinfo where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                userinfo.id = Convert.ToInt32(reader["id"]);
                userinfo.lastname = Convert.ToString(reader["lastname"]);
                userinfo.username = Convert.ToString(reader["username"]);
                userinfo.patronymic = Convert.ToString(reader["patronymic"]);
                userinfo.userroleid = Convert.ToInt32(reader["userroleid"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return userinfo;
        }

        public bool UpdateRecord(int id, UserInfo userinfo)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE userrole SET " +
                    " lastname = @LastName " +
                    " username = @UserName " +
                    " patronymic = @Patronymic " +
                    " userroleid = @UserRoleID " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@LastName", userinfo.lastname));
                cmd.Parameters.Add(new SqlParameter("@UserName", userinfo.username));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", userinfo.patronymic));
                cmd.Parameters.Add(new SqlParameter("@UserRoleID", userinfo.userroleid));
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

        public bool AddRecord(UserInfo userinfo)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "userinfo(lastname, username, patronymic, userroleid) " +
                    "VALUES (@LastName, @UserName, @Patronymic, @UserRoleID )", Con);
                cmd.Parameters.Add(new SqlParameter("@LastName", userinfo.lastname));
                cmd.Parameters.Add(new SqlParameter("@UserName", userinfo.username));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", userinfo.patronymic));
                cmd.Parameters.Add(new SqlParameter("@UserRoleID", userinfo.userroleid));
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

        public bool DeleteRecord(int id, UserInfo userinfo)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM userinfo WHERE Id=@ID", Con);
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