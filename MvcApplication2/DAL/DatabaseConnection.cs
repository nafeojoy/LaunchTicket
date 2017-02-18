using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace MvcApplication2.DAL
{
    //public static class DatabaseConnection
    //{
    //    public static SqlConnection getConnection()
    //    {
    //        return new SqlConnection("");
    //    }
    //}
    public class DbConnection
    {
        public string conString { get; set; }

        public DbConnection()
        {
            conString = "Data Source=NAFEO\\SQLEXPRESS;Initial Catalog=LaunchDB;Integrated Security=True;MultipleActiveResultSets=True;";
        }

        public SqlConnection getConnection()
        {
            return new SqlConnection(conString);
        }
    }

    //public class DbConnection2
    //{
    //    string conString { get; set; }
    //    SqlConnection sqlConnection;

    //    public DbConnection2()
    //    {
    //        conString = "";

    //        sqlConnection = new SqlConnection(conString);

    //        if (sqlConnection.State == System.Data.ConnectionState.Closed)
    //        {
    //            sqlConnection.Open();
    //        }
    //    }

    //}
}