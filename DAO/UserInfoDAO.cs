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
    public class UserInfoDAO : DAO
    {
        public List<userinfo> GetAllRecords()
        {
            Connect();
            List<userinfo> infoList = new List<userinfo>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM userinfo", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    userinfo userinfoObj = new userinfo();
                    userinfoObj.id = Convert.ToInt32(reader["id"]);
                    userinfoObj.lastname = Convert.ToString(reader["lastname"]);
                    userinfoObj.username = Convert.ToString(reader["username"]);
                    userinfoObj.patronymic = Convert.ToString(reader["patronymic"]);
                    userinfoObj.userroleid = Convert.ToInt32(reader["userroleid"]);
                    userinfoObj.email = Convert.ToString(reader["email"]);
                    userinfoObj.password = Convert.ToString(reader["password"]);
                    infoList.Add(userinfoObj);

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

        public userinfo GetRecord(int id)
        {
            Connect();
            userinfo userinfoObj = new userinfo();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM userinfo where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                userinfoObj.id = Convert.ToInt32(reader["id"]);
                userinfoObj.lastname = Convert.ToString(reader["lastname"]);
                userinfoObj.username = Convert.ToString(reader["username"]);
                userinfoObj.patronymic = Convert.ToString(reader["patronymic"]);
                userinfoObj.userroleid = Convert.ToInt32(reader["userroleid"]);
                userinfoObj.email = Convert.ToString(reader["email"]);
                userinfoObj.password = Convert.ToString(reader["password"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return userinfoObj;
        }

        public bool UpdateRecord(int id, userinfo userinfoObj)
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
                    " email = @Email" +
                    " password = @Password" +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@LastName", userinfoObj.lastname));
                cmd.Parameters.Add(new SqlParameter("@UserName", userinfoObj.username));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", userinfoObj.patronymic));
                //cmd.Parameters.Add(new SqlParameter("@UserRoleID", userinfoObj.userroleid));
                cmd.Parameters.Add(new SqlParameter("@Email", userinfoObj.email));
                cmd.Parameters.Add(new SqlParameter("@Password", userinfoObj.password));
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

        public bool AddRecord(userinfo userinfoObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "userinfo(lastname, username, patronymic, email, password) " +
                    "VALUES (@LastName, @UserName, @Patronymic, @Email, @Password )", Con);
                cmd.Parameters.Add(new SqlParameter("@LastName", userinfoObj.lastname));
                cmd.Parameters.Add(new SqlParameter("@UserName", userinfoObj.username));
                cmd.Parameters.Add(new SqlParameter("@Patronymic", userinfoObj.patronymic));
                //cmd.Parameters.Add(new SqlParameter("@UserRoleID", userinfoObj.userroleid));
                cmd.Parameters.Add(new SqlParameter("@Email", userinfoObj.email));
                cmd.Parameters.Add(new SqlParameter("@Password",userinfoObj.password));
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

        public bool DeleteRecord(int id, userinfo userinfoObj)
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