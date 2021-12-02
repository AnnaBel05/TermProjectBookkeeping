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
    public class SalaryFundDAO : DAO
    {
        public List<salaryfund> GetAllRecords()
        {
            Connect();
            List<salaryfund> salaryFunds = new List<salaryfund>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM salaryfund", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    salaryfund salaryfundObj = new salaryfund();
                    salaryfundObj.id = Convert.ToInt32(reader["id"]);
                    salaryfundObj.worktime = Convert.ToInt32(reader["worktime"]);
                    salaryfundObj.overwork = Convert.ToInt32(reader["overwork"]);
                    salaryfundObj.sickdays = Convert.ToInt32(reader["sickdays"]);
                    salaryfundObj.totalsum = Convert.ToInt32(reader["totalsum"]);
                    salaryfundObj.formationdate = Convert.ToDateTime(reader["formationdate"]);
                    salaryFunds.Add(salaryfundObj);
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
            return salaryFunds;
        }

        public salaryfund GetRecord(int id)
        {
            Connect();
            salaryfund salaryfundObj = new salaryfund();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM salaryfund where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                salaryfundObj.id = Convert.ToInt32(reader["id"]);
                salaryfundObj.worktime = Convert.ToInt32(reader["worktime"]);
                salaryfundObj.overwork = Convert.ToInt32(reader["overwork"]);
                salaryfundObj.sickdays = Convert.ToInt32(reader["sickdays"]);
                salaryfundObj.totalsum = Convert.ToInt32(reader["totalsum"]);
                salaryfundObj.formationdate = Convert.ToDateTime(reader["formationdate"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return salaryfundObj;
        }

        public bool UpdateRecord(int id, salaryfund salaryfundObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE salaryfund SET " +
                    " worktime = @Worktime" +
                    " overwork = @Overwork" +
                    " sickdays = @Sickdays" +
                    " totalsum = @TotalSum " +
                    " formationdate = @FormationDate " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter(" @Worktime", salaryfundObj.worktime));
                cmd.Parameters.Add(new SqlParameter("@Overwork", salaryfundObj.overwork));
                cmd.Parameters.Add(new SqlParameter("@Sickdays", salaryfundObj.sickdays));
                cmd.Parameters.Add(new SqlParameter("@TotalSum", salaryfundObj.totalsum));
                cmd.Parameters.Add(new SqlParameter("@FormationDate", salaryfundObj.formationdate));
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

        public bool AddRecord(salaryfund salaryfundObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "salaryfund(worktime, overwork, sickdays, totalsum, formationdate) " +
                    "VALUES (@Worktime, @Overwork, @Sickdays, @TotalSum, @FormationDate)", Con);
                cmd.Parameters.Add(new SqlParameter(" @Worktime", salaryfundObj.worktime));
                cmd.Parameters.Add(new SqlParameter("@Overwork", salaryfundObj.overwork));
                cmd.Parameters.Add(new SqlParameter("@Sickdays", salaryfundObj.sickdays));
                cmd.Parameters.Add(new SqlParameter("@TotalSum", salaryfundObj.totalsum));
                cmd.Parameters.Add(new SqlParameter("@FormationDate", salaryfundObj.formationdate));
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

        public bool DeleteRecord(int id, salaryfund salaryfundObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM salaryfund WHERE Id=@ID", Con);
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