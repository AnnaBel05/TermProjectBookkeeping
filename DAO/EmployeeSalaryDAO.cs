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
    public class EmployeeSalaryDAO : DAO
    {
        public List<employeesalary> GetAllRecords()
        {
            Connect();
            List<employeesalary> employeeSalaries = new List<employeesalary>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM employeesalary", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employeesalary employeesalaryObj = new employeesalary();
                    employeesalaryObj.id = Convert.ToInt32(reader["id"]);
                    employeesalaryObj.employee = Convert.ToInt32(reader["employee"]);
                    employeesalaryObj.overall = Convert.ToInt32(reader["overall"]);
                    employeesalaryObj.hourspermonth = Convert.ToInt32(reader["hourspermonth"]);
                    //employeesalaryObj.hourlyrate = Convert.ToInt32(reader["hourlyrate"]);
                    employeesalaryObj.overwork = Convert.ToBoolean(reader["overwork"]);
                    employeesalaryObj.sickdays = Convert.ToBoolean(reader["sickdays"]);
                    employeesalaryObj.bonus = Convert.ToBoolean(reader["bonus"]);
                    employeeSalaries.Add(employeesalaryObj);
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
            return employeeSalaries;
        }

        public employeesalary GetRecord(int id)
        {
            Connect();
            employeesalary employeesalaryObj = new employeesalary();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM employeesalary where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                employeesalaryObj.id = Convert.ToInt32(reader["id"]);
                employeesalaryObj.employee = Convert.ToInt32(reader["employee"]);
                employeesalaryObj.overall = Convert.ToInt32(reader["overall"]);
                employeesalaryObj.hourspermonth = Convert.ToInt32(reader["hourspermonth"]);
                //employeesalaryObj.hourlyrate = Convert.ToInt32(reader["hourlyrate"]);
                employeesalaryObj.overwork = Convert.ToBoolean(reader["overwork"]);
                employeesalaryObj.sickdays = Convert.ToBoolean(reader["sickdays"]);
                employeesalaryObj.bonus = Convert.ToBoolean(reader["bonus"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return employeesalaryObj;
        }

        public bool UpdateRecord(int id, employeesalary employeesalaryObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE employeesalary SET " +
                    " employee = @Employee" +
                    " overall = @Overall" +
                    " hourspermonth = @Hourspermonth" +
                    " overwork = @Overwork" +
                    " sickdays = @Sickdays " +
                    " bonus = @Bonus " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@Employee", employeesalaryObj.employee));
                cmd.Parameters.Add(new SqlParameter("@Overall", employeesalaryObj.overall));
                cmd.Parameters.Add(new SqlParameter("@Hourspermonth", employeesalaryObj.hourspermonth));
                //cmd.Parameters.Add(new SqlParameter("@Hourlyrate", employeesalaryObj.hourlyrate));
                cmd.Parameters.Add(new SqlParameter("@Overwork", employeesalaryObj.overwork));
                cmd.Parameters.Add(new SqlParameter("@Sickdays", employeesalaryObj.sickdays));
                cmd.Parameters.Add(new SqlParameter("@Bonus", employeesalaryObj.bonus));
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

        public bool AddRecord(employeesalary employeesalaryObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "employeesalary(employee, overall, hourspermonth, overwork, sickdays, bonus) " +
                    "VALUES (@Employee, @Overall, @Hourspermonth, @Overwork, @Sickdays, @Bonus)", Con);
                cmd.Parameters.Add(new SqlParameter("@Employee", employeesalaryObj.employee));
                cmd.Parameters.Add(new SqlParameter("@Overall", employeesalaryObj.overall));
                cmd.Parameters.Add(new SqlParameter("@Hourspermonth", employeesalaryObj.hourspermonth));
                //cmd.Parameters.Add(new SqlParameter("@Hourlyrate", employeesalaryObj.hourlyrate));
                cmd.Parameters.Add(new SqlParameter("@Overwork", employeesalaryObj.overwork));
                cmd.Parameters.Add(new SqlParameter("@Sickdays", employeesalaryObj.sickdays));
                cmd.Parameters.Add(new SqlParameter("@Bonus", employeesalaryObj.bonus));
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

        public bool DeleteRecord(int id, employeesalary employeesalaryObj)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM employeesalary WHERE Id=@ID", Con);
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