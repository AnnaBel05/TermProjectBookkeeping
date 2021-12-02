using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using TermProjectBookkeeping.Models;
using TermProjectBookkeeping;
using MyLib;

using System.Configuration;

using log4net;
using log4net.Config;

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
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<purchaselist> GetAllRecords()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Start connection to DB in GetAllRecords method");
            Connect();
            
            List<purchaselist> purchaseLists = new List<purchaselist>();
            try
            {
                log.Info("Get all records from table purchaselist");
                SqlCommand command = new SqlCommand("SELECT * FROM purchaselist", Con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    purchaselist purchaselistObj = new purchaselist();
                    purchaselistObj.id = Convert.ToInt32(reader["id"]);
                    purchaselistObj.purchasename = Convert.ToString(reader["purchasename"]);
                    purchaselistObj.purchasedescription = Convert.ToString(reader["purchasedescription"]);
                    purchaselistObj.sender = Convert.ToInt32(reader["sender"]);
                    purchaselistObj.quantity = Convert.ToInt32(reader["quantity"]);
                    purchaselistObj.price1pc = Convert.ToInt32(reader["price1pc"]);
                    //purchaselistObj.overallsum = Convert.ToInt32(reader["overallsum"]);
                    purchaselistObj.ifapproved = Convert.ToBoolean(reader["ifapproved"]);

                    TotalSum record = new TotalSum(purchaselistObj.purchasename, purchaselistObj.purchasedescription,
                    purchaselistObj.quantity, purchaselistObj.price1pc);

                    purchaselistObj.overallsum = record.ReturnTotalPrice(record);

                    purchaseLists.Add(purchaselistObj);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                log.Error("Error happened",ex);
            }
            finally
            {
                Disconnect();
            }
            return purchaseLists;
        }

        public purchaselist GetRecord(int id)
        {
            Connect();
            purchaselist purchaselistObj = new purchaselist();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM purchaselist where id = @ID", Con);
                cmd.Parameters.Add(new SqlParameter("@ID", id));
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                purchaselistObj.id = Convert.ToInt32(reader["id"]);
                purchaselistObj.purchasename = Convert.ToString(reader["purchasename"]);
                purchaselistObj.purchasedescription = Convert.ToString(reader["purchasedescription"]);
                purchaselistObj.sender = Convert.ToInt32(reader["sender"]);
                purchaselistObj.quantity = Convert.ToInt32(reader["quantity"]);
                purchaselistObj.price1pc = Convert.ToInt32(reader["price1pc"]);
                //purchaselistClass.overallsum = Convert.ToInt32(reader["overallsum"]);
                purchaselistObj.ifapproved = Convert.ToBoolean(reader["ifapproved"]);

                TotalSum record = new TotalSum(purchaselistObj.purchasename, purchaselistObj.purchasedescription,
                    purchaselistObj.quantity, purchaselistObj.price1pc);

                purchaselistObj.overallsum = record.ReturnTotalPrice(record);

                reader.Close();


            }
            catch (Exception)
            {

            }
            finally
            {
                Disconnect();
            }
            return purchaselistObj;
        }

        public bool UpdateRecord(int id, purchaselist purchaselistObj)
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

                cmd.Parameters.Add(new SqlParameter("@Purchasename", purchaselistObj.purchasename));
                cmd.Parameters.Add(new SqlParameter("@Purchasedescription", purchaselistObj.purchasedescription));
                cmd.Parameters.Add(new SqlParameter("@Sender", purchaselistObj.sender));
                cmd.Parameters.Add(new SqlParameter("@Quantity", purchaselistObj.quantity));
                cmd.Parameters.Add(new SqlParameter("@Price1pc", purchaselistObj.price1pc));
                cmd.Parameters.Add(new SqlParameter("@Overallsum", purchaselistObj.overallsum));
                cmd.Parameters.Add(new SqlParameter("@Ifapproved", purchaselistObj.ifapproved));
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

        public bool AddRecord(purchaselist purchaselistObj)
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
                cmd.Parameters.Add(new SqlParameter("@Purchasename", purchaselistObj.purchasename));
                cmd.Parameters.Add(new SqlParameter("@Purchasedescription", purchaselistObj.purchasedescription));
                cmd.Parameters.Add(new SqlParameter("@Sender", purchaselistObj.sender));
                cmd.Parameters.Add(new SqlParameter("@Quantity", purchaselistObj.quantity));
                cmd.Parameters.Add(new SqlParameter("@Price1pc", purchaselistObj.price1pc));
                cmd.Parameters.Add(new SqlParameter("@Overallsum", purchaselistObj.overallsum));
                cmd.Parameters.Add(new SqlParameter("@Ifapproved", purchaselistObj.ifapproved));
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

        public bool DeleteRecord(int id, purchaselist purchaselistObj)
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