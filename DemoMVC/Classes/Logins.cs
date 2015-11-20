using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoMVC.Models;
using System.Data; 

namespace DemoMVC.Classes
{
    public class Logins
    {
         public string ConnectionString { get; set; }
         public Logins()
        {
            ConnectionString = AllConstants.CONNECTIONSTRING;
        }

        public Login Find(Login login)
         {
            try
            {
                Login  objResult = null ;

                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "SELECT * FROM LOGIN WHERE USERID = '" + login.UserId.ToString() + "' AND PASSWORD ='" + login.Password.ToString() + "'";
                 DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                 if (DS != null)
                 {
                     if (DS.Tables.Count > 0)
                     {
                         if (DS.Tables[0].Rows.Count > 0)
                         {
                             DataRow DR = DS.Tables[0].Rows[0];
                             objResult = new Login();
                             objResult.UserId = DR["USERID"].ToString();
                             objResult.Password = DR["PASSWORD"].ToString();
                            
                         }
                     }
                 }
                 return objResult;

            }
            catch(Exception ex)
            {
                throw ex;
            }

         }


    }
}