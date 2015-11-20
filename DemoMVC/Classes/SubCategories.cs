using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoMVC.Models;
using System.Data;

namespace DemoMVC.Classes
{
    public class SubCategories
    {
          public string ConnectionString { get; set; }
          public SubCategories()
        {
            ConnectionString = AllConstants.CONNECTIONSTRING;
        }

          public List<SubCategory> All()
         {
             try
             {
                 List<SubCategory> objresult = new List<SubCategory>();
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "SELECT * FROM vwSubCategory";
                 DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                 if (DS != null)
                 {
                     if (DS.Tables.Count > 0)
                     {
                         foreach (DataRow DR in DS.Tables[0].Rows)
                         {
                             SubCategory obj = GetObjectFromDR(DR); 
                             objresult.Add(obj);
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
          public bool Add(SubCategory objCat)
         {
             try
             {

                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "INSERT INTO SUBCATEGORY(CATEGORYID,SUBCATEGORYNAME) VALUES (" + objCat.CategoryID.ToString() + ",'" + objCat.SubCategoryName + "')";
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
          public SubCategory Find(int id)
         {
             try
             {
                 SubCategory objResult = null;

                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "SELECT * FROM vwSubCategory WHERE SUBCATEGORYID = " + id.ToString();
                 DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                 if (DS != null)
                 {
                     if (DS.Tables.Count > 0)
                     {
                         if (DS.Tables[0].Rows.Count > 0)
                         {
                             DataRow DR = DS.Tables[0].Rows[0];
                             objResult = GetObjectFromDR(DR); 
                             
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
          public bool Edit(SubCategory obj)
         {
             try
             {
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "UPDATE SUBCATEGORY SET SUBCATEGORYNAME = '" + obj.SubCategoryName + "',CATEGORYID = " + obj.CategoryID.ToString() + " WHERE SUBCATEGORYID = " + obj.SubCategoryID.ToString();
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
          public bool Delete(SubCategory obj)
         {
             try
             {
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "DELETE FROM SUBCATEGORY WHERE SUBCATEGORYID = " + obj.SubCategoryID.ToString();
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

        public SubCategory GetObjectFromDR(DataRow DR)
          {
              try
              {
                  SubCategory obj = new SubCategory();
                  obj.SubCategoryID = int.Parse(DR["SUBCATEGORYID"].ToString());
                  obj.SubCategoryName = DR["SUBCATEGORYNAME"].ToString();
                  obj.CategoryID = int.Parse(DR["CATEGORYID"].ToString());
                  obj.Category.CategoryID = obj.CategoryID;
                  obj.Category.CategoryName = DR["CATEGORYNAME"].ToString();
                  return obj;
              }
            catch(Exception ex)
              {
                  throw ex;
              }

          }


    }
}