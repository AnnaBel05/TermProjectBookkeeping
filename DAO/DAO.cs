using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

using System.Configuration;

using log4net;
using log4net.Config;

namespace TermProjectBookkeeping.DAO
{
    public class DAO
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private const string ConString = @"Data Source=LAPTOP-5VSTM1QN\SQLEXPRESS;Initial Catalog=bookkeeping;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";


        public SqlConnection Con { get; set; }

        public void Connect()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Start connection to DB in DAO");
            
            Con = new SqlConnection(ConString);
            Con.Open();
            
        }
        public void Disconnect()
        {
            log.Info("Close connection to DB in DAO");
            Con.Close();
        }

    }
}