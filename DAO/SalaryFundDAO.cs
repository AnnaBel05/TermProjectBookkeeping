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
    public class SalaryFundDAO : DAO
    {
        public List<SalaryFund> GetAllRecords()
        {
            Connect();
            List<SalaryFund> salaryFunds = new List<SalaryFund>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM salaryfund", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    SalaryFund salaryfund = new SalaryFund();
                    salaryfund.id = Convert.ToInt32(reader["id"]);
                    salaryfund.worktime = Convert.ToInt32(reader["worktime"]);
                    salaryfund.overwork = Convert.ToInt32(reader["overwork"]);
                    salaryfund.sickdays = Convert.ToInt32(reader["sickdays"]);
                    salaryfund.totalsum = Convert.ToInt32(reader["totalsum"]);
                    salaryfund.formationdate = Convert.ToDateTime(reader["formationdate"]);
                    salaryFunds.Add(salaryfund);
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

        public SalaryFund GetRecord(int id)
        {
            Connect();
            SalaryFund salaryfund = new SalaryFund();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM salaryfund where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                salaryfund.id = Convert.ToInt32(reader["id"]);
                salaryfund.worktime = Convert.ToInt32(reader["worktime"]);
                salaryfund.overwork = Convert.ToInt32(reader["overwork"]);
                salaryfund.sickdays = Convert.ToInt32(reader["sickdays"]);
                salaryfund.totalsum = Convert.ToInt32(reader["totalsum"]);
                salaryfund.formationdate = Convert.ToDateTime(reader["formationdate"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return salaryfund;
        }

        public bool UpdateRecord(int id, SalaryFund salaryfund)
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

                cmd.Parameters.Add(new SqlParameter(" @Worktime", salaryfund.worktime));
                cmd.Parameters.Add(new SqlParameter("@Overwork", salaryfund.overwork));
                cmd.Parameters.Add(new SqlParameter("@Sickdays", salaryfund.sickdays));
                cmd.Parameters.Add(new SqlParameter("@TotalSum", salaryfund.totalsum));
                cmd.Parameters.Add(new SqlParameter("@FormationDate", salaryfund.formationdate));
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

        public bool AddRecord(SalaryFund salaryfund)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "salaryfund(worktime, overwork, sickdays, totalsum, formationdate) " +
                    "VALUES (@Worktime, @Overwork, @Sickdays, @TotalSum, @FormationDate)", Con);
                cmd.Parameters.Add(new SqlParameter(" @Worktime", salaryfund.worktime));
                cmd.Parameters.Add(new SqlParameter("@Overwork", salaryfund.overwork));
                cmd.Parameters.Add(new SqlParameter("@Sickdays", salaryfund.sickdays));
                cmd.Parameters.Add(new SqlParameter("@TotalSum", salaryfund.totalsum));
                cmd.Parameters.Add(new SqlParameter("@FormationDate", salaryfund.formationdate));
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

        public bool DeleteRecord(int id, StudentScholarship studentscholarship)
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