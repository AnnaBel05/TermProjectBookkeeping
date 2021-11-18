using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace TermProjectBookkeeping.DAO
{
    public class DAO
    {
        private const string ConString = @"Data Source = .\SQLEXPRESS; Initial Catalog = bookkeeping; Integrated Security = True;";

        public SqlConnection Con { get; set; }

        public void Connect()
        {
            Con = new SqlConnection(ConString);
            Con.Open();
            
        }
        public void Disconnect()
        {
            Con.Close();
        }

    }
}