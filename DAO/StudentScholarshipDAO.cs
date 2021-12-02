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
    public class StudentScholarshipDAO : DAO
    {
        public List<studentscholarship> GetAllRecords()
        {
            Connect();
            List<studentscholarship> studentScholarships = new List<studentscholarship>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM studentscholarship", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    studentscholarship studentscholarshipObj = new studentscholarship();
                    studentscholarshipObj.id = Convert.ToInt32(reader["id"]);
                    studentscholarshipObj.student = Convert.ToInt32(reader["student"]);
                    studentscholarshipObj.grades = Convert.ToInt32(reader["grades"]);
                    studentscholarshipObj.scholarshiptype = Convert.ToInt32(reader["scholarshiptype"]);
                    studentscholarshipObj.ifsocial = Convert.ToBoolean(reader["ifsocial"]);
                    studentscholarshipObj.ifsocialhelp = Convert.ToBoolean(reader["ifsocialhelp"]);
                    studentScholarships.Add(studentscholarshipObj);
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
            return studentScholarships;
        }

        public studentscholarship GetRecord(int id)
        {
            Connect();
            studentscholarship studentscholarshipObj = new studentscholarship();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM studentscholarship where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                studentscholarshipObj.id = Convert.ToInt32(reader["id"]);
                studentscholarshipObj.student = Convert.ToInt32(reader["student"]);
                studentscholarshipObj.grades = Convert.ToInt32(reader["grades"]);
                studentscholarshipObj.scholarshiptype = Convert.ToInt32(reader["scholarshiptype"]);
                studentscholarshipObj.ifsocial = Convert.ToBoolean(reader["ifsocial"]);
                studentscholarshipObj.ifsocialhelp = Convert.ToBoolean(reader["ifsocialhelp"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return studentscholarshipObj;
        }

        public bool UpdateRecord(int id, studentscholarship studentscholarshipObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE studentscholarship SET " +
                    " student = @Student " +
                    " grades = @Grades " +
                    " scholarshiptype = @ScholarshipType " +
                    " ifsocial = @IfSocial " +
                    " ifsocialhelp = @IfSocialHelp " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@Student", studentscholarshipObj.student));
                cmd.Parameters.Add(new SqlParameter("@Grades", studentscholarshipObj.grades));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipType", studentscholarshipObj.scholarshiptype));
                cmd.Parameters.Add(new SqlParameter("@IfSocial", studentscholarshipObj.ifsocial));
                cmd.Parameters.Add(new SqlParameter("@IfSocialHelp", studentscholarshipObj.ifsocialhelp));
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

        public bool AddRecord(studentscholarship studentscholarshipObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "studentscholarship(student, grades, scholarshiptype, ifsocial, ifsocialhelp) " +
                    "VALUES (@Student, @Grades, @ScholarshipType, @IfSocial, @IfSocialHelp)", Con);
                cmd.Parameters.Add(new SqlParameter("@Student", studentscholarshipObj.student));
                cmd.Parameters.Add(new SqlParameter("@Grades", studentscholarshipObj.grades));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipType", studentscholarshipObj.scholarshiptype));
                cmd.Parameters.Add(new SqlParameter("@IfSocial", studentscholarshipObj.ifsocial));
                cmd.Parameters.Add(new SqlParameter("@IfSocialHelp", studentscholarshipObj.ifsocialhelp));
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

        public bool DeleteRecord(int id, studentscholarship studentscholarshipObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM studentscholarship WHERE Id=@ID", Con);
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