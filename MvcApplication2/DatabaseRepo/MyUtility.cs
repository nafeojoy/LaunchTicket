using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

namespace MvcApplication2.DatabaseRepo
{
    public class MyUtility : BaseDataAccess
    {
        public object ExecQuery(string Sql)
        {
            object obj = new object();
            using (DbCommand cmd = Database.GetSqlStringCommand(Sql))
            {
                obj = Database.ExecuteNonQuery(cmd);
            }
            return obj;
        }

        public object GetScalarResult(string Sql)
        {
            object obj = new object();
            using (DbCommand cmd = Database.GetSqlStringCommand(Sql))
            {
                obj = Database.ExecuteScalar(cmd);
            }
            return obj;
        }

        public DataTable GetTable(string Table)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            using (DbCommand cmd = Database.GetSqlStringCommand("Select * From " + Table))
            {
                ds = Database.ExecuteDataSet(cmd);
            }
            dt = ds.Tables[0];
            return dt;
        }

        public DataTable GetTableData(string SQL)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            using (DbCommand cmd = Database.GetSqlStringCommand(SQL))
            {
                ds = Database.ExecuteDataSet(cmd);
            }
            dt = ds.Tables[0];
            return dt;
        }

        public int GetNextId(string Table, string Column)
        {
            string Sql = "Select IsNull(Max(" + Column + "),0)+1 From " + Table;
            object obj = new object();
            using (DbCommand cmd = Database.GetSqlStringCommand(Sql))
            {
                obj = Database.ExecuteScalar(cmd);
            }
            return Convert.ToInt16(obj);
        }
    }
}