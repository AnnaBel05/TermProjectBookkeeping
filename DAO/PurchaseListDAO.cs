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
    public class PurchaseListDAO : DAO
    {
        public List<PurchaseList> GetAllRecords()
        {
            Connect();
            List<PurchaseList> purchaseLists = new List<PurchaseList>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM purchaselist", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PurchaseList purchaselist = new PurchaseList();
                    purchaselist.id = Convert.ToInt32(reader["id"]);
                    purchaselist.purchasename = Convert.ToString(reader["purchasename"]);
                    purchaselist.purchasedescription = Convert.ToString(reader["purchasedescription"]);
                    purchaselist.sender = Convert.ToInt32(reader["sender"]);
                    purchaselist.quantity = Convert.ToInt32(reader["quantity"]);
                    purchaselist.price1pc = Convert.ToInt32(reader["price1pc"]);
                    purchaselist.overallsum = Convert.ToInt32(reader["overallsum"]);
                    purchaselist.ifapproved = Convert.ToBoolean(reader["ifapproved"]);
                    purchaseLists.Add(purchaselist);
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
            return purchaseLists;
        }

        public PurchaseList GetRecord(int id)
        {
            Connect();
            PurchaseList purchaselist = new PurchaseList();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM purchaselist where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                purchaselist.id = Convert.ToInt32(reader["id"]);
                purchaselist.purchasename = Convert.ToString(reader["purchasename"]);
                purchaselist.purchasedescription = Convert.ToString(reader["purchasedescription"]);
                purchaselist.sender = Convert.ToInt32(reader["sender"]);
                purchaselist.quantity = Convert.ToInt32(reader["quantity"]);
                purchaselist.price1pc = Convert.ToInt32(reader["price1pc"]);
                purchaselist.overallsum = Convert.ToInt32(reader["overallsum"]);
                purchaselist.ifapproved = Convert.ToBoolean(reader["ifapproved"]);

                reader.Close();

            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return purchaselist;
        }

        public bool UpdateRecord(int id, PurchaseList purchaselist)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE purchaselist SET " +
                    " purchasename = @Purchasename " +
                    " purchasedescription = @Purchasedescription" +
                    " sender = @Sender" +
                    " quantity = @Quantity " +
                    " price1pc = @Price1pc " +
                    " overallsum = @Overallsum " +
                    " ifapproved = @Ifapproved " +
                    " WHERE id = @ID ", Con);

                cmd.Parameters.Add(new SqlParameter("@Purchasename", purchaselist.purchasename));
                cmd.Parameters.Add(new SqlParameter("@Purchasedescription", purchaselist.purchasedescription));
                cmd.Parameters.Add(new SqlParameter("@Sender", purchaselist.sender));
                cmd.Parameters.Add(new SqlParameter("@Quantity", purchaselist.quantity));
                cmd.Parameters.Add(new SqlParameter("@Price1pc", purchaselist.price1pc));
                cmd.Parameters.Add(new SqlParameter("@Overallsum", purchaselist.overallsum));
                cmd.Parameters.Add(new SqlParameter("@Ifapproved", purchaselist.ifapproved));
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

        public bool AddRecord(PurchaseList purchaselist)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO " +
                    "purchaselist(purchasename, purchasedescription, sender, " +
                    "quantity, price1pc, overallsum, ifapproved) " +
                    "VALUES (@Purchasename, @Purchasedescription, @Sender, " +
                    "@Quantity, @Price1pc, @Overallsum, @Ifapproved)", Con);
                cmd.Parameters.Add(new SqlParameter("@Purchasename", purchaselist.purchasename));
                cmd.Parameters.Add(new SqlParameter("@Purchasedescription", purchaselist.purchasedescription));
                cmd.Parameters.Add(new SqlParameter("@Sender", purchaselist.sender));
                cmd.Parameters.Add(new SqlParameter("@Quantity", purchaselist.quantity));
                cmd.Parameters.Add(new SqlParameter("@Price1pc", purchaselist.price1pc));
                cmd.Parameters.Add(new SqlParameter("@Overallsum", purchaselist.overallsum));
                cmd.Parameters.Add(new SqlParameter("@Ifapproved", purchaselist.ifapproved));
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

        public bool DeleteRecord(int id, PurchaseList purchaselist)
        {
            Connect();
            bool result = true;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM purchaselist WHERE Id=@ID", Con);
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