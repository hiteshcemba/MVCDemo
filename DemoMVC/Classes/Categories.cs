using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoMVC.Models;
using System.Data;

namespace DemoMVC.Classes
{
    public class Categories
    {
         public string ConnectionString { get; set; }
         public Categories()
        {
            ConnectionString = AllConstants.CONNECTIONSTRING;
        }

         public List<Category> All()
         {
             try
             {
                 List<Category> objresult = new List<Category>();
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "SELECT * FROM CATEGORY";
                 DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                 if (DS != null)
                 {
                     if (DS.Tables.Count > 0)
                     {
                         foreach (DataRow DR in DS.Tables[0].Rows)
                         {
                             Category objCAT = new Category();
                             objCAT.CategoryID = int.Parse(DR["CATEGORYID"].ToString());
                             objCAT.CategoryName = DR["CATEGORYNAME"].ToString();
                             objresult.Add(objCAT);
                         }
                     }
                 }
                 return objresult;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         public bool Add(Category objCat)
         {
             try
             {

                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "INSERT INTO CATEGORY(CATEGORYNAME) VALUES ('" + objCat.CategoryName + "')";
                 int ROWCOUNT = DB.ExecuteCommandNoQuery(sqlstring);
                 if (ROWCOUNT > 0)
                     return true;
                 else
                     return false;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         public Category Find(int id)
         {
             try
             {
                 Category objResult = null;

                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "SELECT * FROM CATEGORY WHERE CATEGORYID = " + id.ToString();
                 DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                 if (DS != null)
                 {
                     if (DS.Tables.Count > 0)
                     {
                         if (DS.Tables[0].Rows.Count > 0)
                         {
                             DataRow DR = DS.Tables[0].Rows[0];
                             objResult = new Category();
                             objResult.CategoryID = int.Parse(DR["CATEGORYID"].ToString());
                             objResult.CategoryName = DR["CATEGORYNAME"].ToString();
                         }
                     }
                 }
                 return objResult;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         public bool Edit(Category objCat)
         {
             try
             {
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "UPDATE CATEGORY SET CATEGORYNAME = '" + objCat.CategoryName + "' WHERE CATEGORYID = " + objCat.CategoryID.ToString();
                 int ROWCOUNT = DB.ExecuteCommandNoQuery(sqlstring);
                 if (ROWCOUNT > 0)
                     return true;
                 else
                     return false;
             }
             catch (Exception ex)
             {
                 throw ex;
             }

         }
         public bool Delete(Category objCat)
         {
             try
             {
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "DELETE FROM CATEGORY WHERE CATEGORYID = " + objCat.CategoryID.ToString();
                 int ROWCOUNT = DB.ExecuteCommandNoQuery(sqlstring);
                 if (ROWCOUNT > 0)
                     return true;
                 else
                     return false;
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }




    }
}