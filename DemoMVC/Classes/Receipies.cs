using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DemoMVC.Classes
{
    public class Receipies
    {

          public string ConnectionString { get; set; }
          public Receipies()
        {
            ConnectionString = AllConstants.CONNECTIONSTRING;
        }

          public List<Receipy> All()
         {
             try
             {
                 List<Receipy> objresult = new List<Receipy>();
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "SELECT * FROM vwReceipy";
                 DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                 if (DS != null)
                 {
                     if (DS.Tables.Count > 0)
                     {
                         foreach (DataRow DR in DS.Tables[0].Rows)
                         {
                             Receipy obj = GetObjectFromDR(DR); 
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
          public bool Add(Receipy obj)
         {
             try
             {

                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "INSERT INTO RECEIPY(RECEIPYNAME,INGREDIENTS,MAKING,TIME,SUBCATEGORYID,IMAGE,DATEINSERT) VALUES (" + obj.ReceipyName.ToString() + ",'" + obj.Ingredients + "','" + obj.Making + "'," + obj.Time + "," + obj.SubCategoryID.ToString() + ",'" + DateTime.Today.ToString("dd-Mon-yyyy") + "')";
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
          public Receipy Find(int id)
         {
             try
             {
                 Receipy objResult = null;

                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "SELECT * FROM vwReceipy WHERE RECEIPYID = " + id.ToString();
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
          public bool Edit(Receipy obj)
         {
             try
             {
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = ""; //"UPDATE SUBCATEGORY SET SUBCATEGORYNAME = '" + obj.SubCategoryName + "',CATEGORYID = " + obj.CategoryID.ToString() + " WHERE SUBCATEGORYID = " + obj.SubCategoryID.ToString();
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
          public bool Delete(Receipy obj)
         {
             try
             {
                 DAL DB = new DAL(ConnectionString);
                 string sqlstring = "DELETE FROM RECEIPY WHERE RECEIPYID = " + obj.ReceipyID.ToString();
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

          public Receipy GetObjectFromDR(DataRow DR)
          {
              try
              {
                  AllDemoMVCBLL objBLL=new AllDemoMVCBLL();
                  Receipy obj = new Receipy();
                  obj.ReceipyID = int.Parse(DR["ReceipyID"].ToString());
                  obj.ReceipyName = DR["ReceipyName"].ToString();
                  obj.Ingredients = DR["Ingredients"].ToString();
                  obj.Time = int.Parse(DR["Time"].ToString());
                  if (DR["DateInsert"] != DBNull.Value)
                      obj.DateInsert = Convert.ToDateTime(DR["DateInsert"]);
                  if (DR["DateUpdate"] != DBNull.Value)
                      obj.DateUpdate = Convert.ToDateTime(DR["DateUpdate"]);
                  obj.SubCategory = objBLL.SubCategories.GetObjectFromDR(DR);
                  return obj;
              }
            catch(Exception ex)
              {
                  throw ex;
              }

          }

    }
}