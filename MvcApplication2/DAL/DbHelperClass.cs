using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MvcApplication2.DAL
{
    public class DbHelperClass
    {

        public int GetNextID(string tblName, string columnName)
        {
            try
            {
                string sqlToExecute = "Select IsNull(Max(" + columnName + "),0)+1 From " + tblName;
                object obj = new object();
                using (SqlConnection sqlCon = new DbConnection().getConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(sqlToExecute, sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }
                        obj = sqlCommand.ExecuteScalar();
                    }
                }

                return Convert.ToInt16(obj);
            }
            catch
            {
                return 0;
            }
        }


        public int ExecuteScalerDataString(string dataString)
        {
            try
            {
                object obj = new object();
                using (SqlConnection sqlCon = new DbConnection().getConnection())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(dataString, sqlCon))
                    {
                        sqlCommand.CommandType = CommandType.Text;

                        if (sqlCon.State != ConnectionState.Open)
                        {
                            sqlCon.Open();
                        }
                        obj = sqlCommand.ExecuteScalar();
                    }
                }

                return Convert.ToInt16(obj);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}