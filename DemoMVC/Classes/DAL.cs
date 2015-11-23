using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb; 
using System.Data;
namespace DemoMVC
{
    class DAL
    {
        public string ConnectionString { get; set; }
        public OleDbConnection DBConnection { get; set; }
        public OleDbCommand DBCommand { get; set; }
        public OleDbTransaction DBTransaction { get; set; }
        public string UserName { get; set; }
        public string Server { get; set; }
        public string Password { get; set; }


        public  DAL(string _tmpconnectionstring)
        {
            ConnectionString = _tmpconnectionstring;
        }
        public void OpenConnection()
        {
            DBConnection = new OleDbConnection(ConnectionString);
            DBConnection.Open();

        }
        public void CloseConnection()
        {
            if (DBConnection.State == System.Data.ConnectionState.Open)
                DBConnection.Close();
        }
        public void CreateTrans()
        {
            DBTransaction = DBConnection.BeginTransaction();
        }
        public void RollBackTrans()
        {
            DBTransaction.Rollback();
        }
        public void BeginTrans()
        {
            DBCommand.Transaction = DBTransaction;
           
        }
        public void CommitTrans()
        {
            DBTransaction.Commit();
        }
        public void CreateCommand()
        {
            DBCommand = DBConnection.CreateCommand();
        }

        public int ExecuteCommandNoQuery(string strSQL)
        {
            int NumRows = -1;
            using( OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(strSQL, connection))
                {
                    connection.Open();
                    NumRows = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                connection.Close();
            }
            return NumRows;
        }
        public int ExecuteCommandNoQuery(string strSQL, OleDbParameter[] _params, string ErrNumParamName, string ErrMessgParamName)
        {
            int NumRows = -1;
            //int ErrNum = 0;
            string ErrMsg="";
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbConnection.ReleaseObjectPool();
                using (OleDbCommand cmd = new OleDbCommand(strSQL, connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    foreach (OleDbParameter par in _params)
                    {
                        cmd.Parameters.Add(par);
                    }
                    connection.Open();
                    NumRows = cmd.ExecuteNonQuery();
                    if (int.TryParse(cmd.Parameters[ErrNumParamName].Value.ToString(), out NumRows))
                    {   if (NumRows != 0)
                        {
                            ErrMsg = cmd.Parameters[ErrMessgParamName].Value.ToString();
                              if(ErrMsg!="SUCCESS")
                                {  
                                  connection.Close();
                                  OleDbConnection.ReleaseObjectPool();
                                  throw new Exception(ErrMsg);
                                }

                        }

                        cmd.Dispose();
                    }
                 connection.Close();
                 OleDbConnection.ReleaseObjectPool();
                }
            }
            return NumRows;
        }

        public DataSet GetDataSet(string strSQL, string TableName)
        {
            DataSet ds = new DataSet();
            using (OleDbConnection connection = new OleDbConnection(ConnectionString))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(strSQL, connection);
                da.Fill(ds, TableName);
                connection.Close();
            }
            return ds;
        }



    }
}
