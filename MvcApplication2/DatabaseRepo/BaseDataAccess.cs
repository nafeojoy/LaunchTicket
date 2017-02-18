using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Web;

namespace MvcApplication2.DatabaseRepo
{
    public class BaseDataAccess : IDisposable
    {
        #region Instance Variables

        private bool _isDisPosed;
        private Database _db;

        #endregion

        #region Properties

        protected virtual Database Database
        {
            get
            {
                //_db = DatabaseFactory.CreateDatabase("CRM.Properties.Settings.mySQLConnectionString");
                _db = DatabaseFactory.CreateDatabase("CRM.Properties.Settings.ConnectionString");
                return _db;
            }
        }

        #endregion

        #region Constructer & Destructer

        protected BaseDataAccess()
        {

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisPosed)
            {
                if (disposing)
                {

                }
            }
            _isDisPosed = true;
        }

        ~BaseDataAccess()
        {
            Dispose(false);
        }

        #endregion

        #region Protected Methods

        [DebuggerStepThrough()] //If you have some shared method that your code calls often (maybe something in a DAL) that performs some common task for you that you would rather not have to step through in the IDE all the 
        protected virtual IDataReader ExecuteReader(DbCommand cmd)//IDataReader a means of reading one or more forward-only streams of result sets
        {
            return Database.ExecuteReader(cmd);
        }
        [DebuggerStepThrough()]
        protected virtual int ExecuteNoneQuery(DbCommand cmd)
        {
            return Database.ExecuteNonQuery(cmd);
        }

        [DebuggerStepThrough()]
        protected virtual object ExecuteScalar(DbCommand cmd)
        {
            return Database.ExecuteScalar(cmd);
        }
        [DebuggerStepThrough()]
        protected virtual int GetReturnCodeFromParamet(DbCommand cmd)
        {
            return (int)Database.GetParameterValue(cmd, "@ReturnCode");
        }
        [DebuggerStepThrough()]
        protected virtual int GetNewIdFromParameter(DbCommand cmd)
        {
            return (int)Database.GetParameterValue(cmd, "@ID");
        }
        [DebuggerStepThrough()]

        protected virtual int GetTotalRowFromParamet(DbCommand cmd)
        {
            return (int)Database.GetParameterValue(cmd, "@TotalRow");
        }

        [DebuggerStepThrough()]
        protected virtual int GetCountFromParameter(DbCommand cmd)
        {
            return (int)Database.GetParameterValue(cmd, "@Count");
        }

        #endregion
    }
}