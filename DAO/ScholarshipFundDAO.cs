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
    public class ScholarshipFundDAO : DAO
    {
        public List<ScholarshipFund> GetAllRecords()
        {
            Connect();
            List<ScholarshipFund> scholarshipFunds = new List<ScholarshipFund>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM scholarshipfund", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ScholarshipFund scholarshipfund = new ScholarshipFund();
                    scholarshipfund.id = Convert.ToInt32(reader["id"]);
                    scholarshipfund.formationdate = Convert.ToDateTime(reader["formationdate"]);
                    scholarshipfund.scholarshipsocial = Convert.ToInt32(reader["scholarshipsocial"]);
                    scholarshipfund.scholarshipgreat = Convert.ToInt32(reader["scholarshipgreat"]);
                    scholarshipfund.scholarshipgreatperfect = Convert.ToInt32(reader["scholarshipgreatperfect"]);
                    scholarshipfund.scholarshipperfect = Convert.ToInt32(reader["scholarshipperfect"]);
                    scholarshipfund.basescholarship = Convert.ToInt32(reader["basescholarship"]);
                    scholarshipfund.totalsum = Convert.ToInt32(reader["totalsum"]);
                    scholarshipFunds.Add(scholarshipfund);
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
            return scholarshipFunds;
        }

        public ScholarshipFund GetRecord(int id)
        {
            Connect();
            ScholarshipFund scholarshipfund = new ScholarshipFund();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM scholarshipfund where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                scholarshipfund.id = Convert.ToInt32(reader["id"]);
                scholarshipfund.formationdate = Convert.ToDateTime(reader["formationdate"]);
                scholarshipfund.scholarshipsocial = Convert.ToInt32(reader["scholarshipsocial"]);
                scholarshipfund.scholarshipgreat = Convert.ToInt32(reader["scholarshipgreat"]);
                scholarshipfund.scholarshipgreatperfect = Convert.ToInt32(reader["scholarshipgreatperfect"]);
                scholarshipfund.scholarshipperfect = Convert.ToInt32(reader["scholarshipperfect"]);
                scholarshipfund.basescholarship = Convert.ToInt32(reader["basescholarship"]);
                scholarshipfund.totalsum = Convert.ToInt32(reader["totalsum"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return scholarshipfund;
        }

        public bool UpdateRecord(int id, ScholarshipFund scholarshipfund)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE scholarshipfund SET " +
                    " formationdate = @FormationDate " +
                    " scholarshipsocial = @ScholarshipSocial" +
                    " scholarshipgreat = @ScholarshipGreat" +
                    " scholarshipgreatperfect = @ScholarshipGreatPerfect " +
                    " scholarshipperfect = @ScholarshipPerfect " +
                    " basescholarship = @BaseScholarship " +
                    " totalsum = @TotalSum " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@FormationDate", scholarshipfund.formationdate));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipSocial", scholarshipfund.scholarshipsocial));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipGreat", scholarshipfund.scholarshipgreat));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipGreatPerfect", scholarshipfund.scholarshipgreatperfect));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipPerfect", scholarshipfund.scholarshipperfect));
                cmd.Parameters.Add(new SqlParameter("@BaseScholarship", scholarshipfund.basescholarship));
                cmd.Parameters.Add(new SqlParameter("@TotalSum", scholarshipfund.totalsum));
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

        public bool AddRecord(ScholarshipFund scholarshipfund)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "scholarshipfund(formationdate, scholarshipsocial, scholarshipgreat, " +
                    "scholarshipgreatperfect, scholarshipperfect, basescholarship, totalsum) " +
                    "VALUES (@FormationDate, @ScholarshipSocial, @ScholarshipGreat, " +
                    "@ScholarshipGreatPerfect, @ScholarshipPerfect, @BaseScholarship, @TotalSum)", Con);
                cmd.Parameters.Add(new SqlParameter("@FormationDate", scholarshipfund.formationdate));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipSocial", scholarshipfund.scholarshipsocial));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipGreat", scholarshipfund.scholarshipgreat));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipGreatPerfect", scholarshipfund.scholarshipgreatperfect));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipPerfect", scholarshipfund.scholarshipperfect));
                cmd.Parameters.Add(new SqlParameter("@BaseScholarship", scholarshipfund.basescholarship));
                cmd.Parameters.Add(new SqlParameter("@TotalSum", scholarshipfund.totalsum));
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

        public bool DeleteRecord(int id, ScholarshipFund scholarshipfund)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM scholarshipfund WHERE Id=@ID", Con);
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