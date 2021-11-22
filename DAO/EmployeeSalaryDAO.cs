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
    public class EmployeeSalaryDAO : DAO
    {
        public List<EmployeeSalary> GetAllRecords()
        {
            Connect();
            List<EmployeeSalary> employeeSalaries = new List<EmployeeSalary>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM employeesalary", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeSalary employeesalary = new EmployeeSalary();
                    employeesalary.id = Convert.ToInt32(reader["id"]);
                    employeesalary.employee = Convert.ToInt32(reader["employee"]);
                    employeesalary.hourlyrate = Convert.ToInt32(reader["hourlyrate"]);
                    employeesalary.overwork = Convert.ToInt32(reader["overwork"]);
                    employeesalary.sickdays = Convert.ToInt32(reader["sickdays"]);
                    employeesalary.bonus = Convert.ToInt32(reader["bonus"]);
                    employeeSalaries.Add(employeesalary);
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

        public EmployeeSalary GetRecord(int id)
        {
            Connect();
            EmployeeSalary employeesalary = new EmployeeSalary();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM employeesalary where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                employeesalary.id = Convert.ToInt32(reader["id"]);
                employeesalary.employee = Convert.ToInt32(reader["employee"]);
                employeesalary.hourlyrate = Convert.ToInt32(reader["hourlyrate"]);
                employeesalary.overwork = Convert.ToInt32(reader["overwork"]);
                employeesalary.sickdays = Convert.ToInt32(reader["sickdays"]);
                employeesalary.bonus = Convert.ToInt32(reader["bonus"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return employeesalary;
        }

        public bool UpdateRecord(int id, EmployeeSalary employeesalary)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE employeesalary SET " +
                    " employee = @Employee" +
                    " hourlyrate = @Hourlyrate" +
                    " overwork = @Overwork" +
                    " sickdays = @Sickdays " +
                    " bonus = @Bonus " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@Employee", employeesalary.employee));
                cmd.Parameters.Add(new SqlParameter("@Hourlyrate", employeesalary.hourlyrate));
                cmd.Parameters.Add(new SqlParameter("@Overwork", employeesalary.overwork));
                cmd.Parameters.Add(new SqlParameter("@Sickdays", employeesalary.sickdays));
                cmd.Parameters.Add(new SqlParameter("@Bonus", employeesalary.bonus));
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

        public bool AddRecord(EmployeeSalary employeesalary)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "employeesalary(employee, hourlyrate, overwork, sickdays, bonus) " +
                    "VALUES (@Employee, @Hourlyrate, @Overwork, @Sickdays, @Bonus)", Con);
                cmd.Parameters.Add(new SqlParameter("@Employee", employeesalary.employee));
                cmd.Parameters.Add(new SqlParameter("@Hourlyrate", employeesalary.hourlyrate));
                cmd.Parameters.Add(new SqlParameter("@Overwork", employeesalary.overwork));
                cmd.Parameters.Add(new SqlParameter("@Sickdays", employeesalary.sickdays));
                cmd.Parameters.Add(new SqlParameter("@Bonus", employeesalary.bonus));
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

        public bool DeleteRecord(int id, EmployeeSalary employeesalary)
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