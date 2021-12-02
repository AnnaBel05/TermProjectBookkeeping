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
    public class ScholarshipFundDAO : DAO
    {
        public List<scholarshipfund> GetAllRecords()
        {
            Connect();
            List<scholarshipfund> scholarshipFunds = new List<scholarshipfund>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM scholarshipfund", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    scholarshipfund scholarshipfundObj = new scholarshipfund();
                    scholarshipfundObj.id = Convert.ToInt32(reader["id"]);
                    scholarshipfundObj.formationdate = Convert.ToDateTime(reader["formationdate"]);
                    scholarshipfundObj.scholarshipsocial = Convert.ToInt32(reader["scholarshipsocial"]);
                    scholarshipfundObj.scholarshipgreat = Convert.ToInt32(reader["scholarshipgreat"]);
                    scholarshipfundObj.scholarshipgreatperfect = Convert.ToInt32(reader["scholarshipgreatperfect"]);
                    scholarshipfundObj.scholarshipperfect = Convert.ToInt32(reader["scholarshipperfect"]);
                    scholarshipfundObj.basescholarship = Convert.ToInt32(reader["basescholarship"]);
                    scholarshipfundObj.totalsum = Convert.ToInt32(reader["totalsum"]);
                    scholarshipFunds.Add(scholarshipfundObj);
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

        public scholarshipfund GetRecord(int id)
        {
            Connect();
            scholarshipfund scholarshipfundObj = new scholarshipfund();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM scholarshipfund where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                scholarshipfundObj.id = Convert.ToInt32(reader["id"]);
                scholarshipfundObj.formationdate = Convert.ToDateTime(reader["formationdate"]);
                scholarshipfundObj.scholarshipsocial = Convert.ToInt32(reader["scholarshipsocial"]);
                scholarshipfundObj.scholarshipgreat = Convert.ToInt32(reader["scholarshipgreat"]);
                scholarshipfundObj.scholarshipgreatperfect = Convert.ToInt32(reader["scholarshipgreatperfect"]);
                scholarshipfundObj.scholarshipperfect = Convert.ToInt32(reader["scholarshipperfect"]);
                scholarshipfundObj.basescholarship = Convert.ToInt32(reader["basescholarship"]);
                scholarshipfundObj.totalsum = Convert.ToInt32(reader["totalsum"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return scholarshipfundObj;
        }

        public bool UpdateRecord(int id, scholarshipfund scholarshipfundObj
            )
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

                cmd.Parameters.Add(new SqlParameter("@FormationDate", scholarshipfundObj.formationdate));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipSocial", scholarshipfundObj.scholarshipsocial));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipGreat", scholarshipfundObj.scholarshipgreat));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipGreatPerfect", scholarshipfundObj.scholarshipgreatperfect));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipPerfect", scholarshipfundObj.scholarshipperfect));
                cmd.Parameters.Add(new SqlParameter("@BaseScholarship", scholarshipfundObj.basescholarship));
                cmd.Parameters.Add(new SqlParameter("@TotalSum", scholarshipfundObj.totalsum));
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

        public bool AddRecord(scholarshipfund scholarshipfundObj)
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
                cmd.Parameters.Add(new SqlParameter("@FormationDate", scholarshipfundObj.formationdate));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipSocial", scholarshipfundObj.scholarshipsocial));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipGreat", scholarshipfundObj.scholarshipgreat));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipGreatPerfect", scholarshipfundObj.scholarshipgreatperfect));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipPerfect", scholarshipfundObj.scholarshipperfect));
                cmd.Parameters.Add(new SqlParameter("@BaseScholarship", scholarshipfundObj.basescholarship));
                cmd.Parameters.Add(new SqlParameter("@TotalSum", scholarshipfundObj.totalsum));
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

        public bool DeleteRecord(int id, scholarshipfund scholarshipfundObj)
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