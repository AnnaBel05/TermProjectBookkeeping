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
    public class StudentScholarshipDAO : DAO
    {
        public List<StudentScholarship> GetAllRecords()
        {
            Connect();
            List<StudentScholarship> studentScholarships = new List<StudentScholarship>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM studentscholarship", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StudentScholarship studentscholarship = new StudentScholarship();
                    studentscholarship.id = Convert.ToInt32(reader["id"]);
                    studentscholarship.student = Convert.ToInt32(reader["student"]);
                    studentscholarship.grades = Convert.ToInt32(reader["grades"]);
                    studentscholarship.scholarshiptype = Convert.ToInt32(reader["scholarshiptype"]);
                    studentscholarship.ifsocial = Convert.ToBoolean(reader["ifsocial"]);
                    studentscholarship.ifsocialhelp = Convert.ToBoolean(reader["ifsocialhelp"]);
                    studentScholarships.Add(studentscholarship);
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

        public StudentScholarship GetRecord(int id)
        {
            Connect();
            StudentScholarship studentscholarship = new StudentScholarship();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM studentscholarship where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                studentscholarship.id = Convert.ToInt32(reader["id"]);
                studentscholarship.student = Convert.ToInt32(reader["student"]);
                studentscholarship.grades = Convert.ToInt32(reader["grades"]);
                studentscholarship.scholarshiptype = Convert.ToInt32(reader["scholarshiptype"]);
                studentscholarship.ifsocial = Convert.ToBoolean(reader["ifsocial"]);
                studentscholarship.ifsocialhelp = Convert.ToBoolean(reader["ifsocialhelp"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return studentscholarship;
        }

        public bool UpdateRecord(int id, StudentScholarship studentscholarship)
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

                cmd.Parameters.Add(new SqlParameter("@Student", studentscholarship.student));
                cmd.Parameters.Add(new SqlParameter("@Grades", studentscholarship.grades));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipType", studentscholarship.scholarshiptype));
                cmd.Parameters.Add(new SqlParameter("@IfSocial", studentscholarship.ifsocial));
                cmd.Parameters.Add(new SqlParameter("@IfSocialHelp", studentscholarship.ifsocialhelp));
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

        public bool AddRecord(StudentScholarship studentscholarship)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "studentscholarship(student, grades, scholarshiptype, ifsocial, ifsocialhelp) " +
                    "VALUES (@Student, @Grades, @ScholarshipType, @IfSocial, @IfSocialHelp)", Con);
                cmd.Parameters.Add(new SqlParameter("@Student", studentscholarship.student));
                cmd.Parameters.Add(new SqlParameter("@Grades", studentscholarship.grades));
                cmd.Parameters.Add(new SqlParameter("@ScholarshipType", studentscholarship.scholarshiptype));
                cmd.Parameters.Add(new SqlParameter("@IfSocial", studentscholarship.ifsocial));
                cmd.Parameters.Add(new SqlParameter("@IfSocialHelp", studentscholarship.ifsocialhelp));
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