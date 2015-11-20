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
        public SubCategories(string strconnectionstring)
        {
            ConnectionString = strconnectionstring;
        }

        public List<SubCategory> All()
        {
            try
            {
                List<SubCategory> objresult = new List<SubCategory>();
                DAL DB = new DAL(ConnectionString);
                string sqlstring = "SELECT S.*,C.CATEGORYNAME FROM SUBCATEGORIES S INNER JOIN CATEGORY C ON S.CATEGORYID = C.CATEGORYID";
                DataSet DS = DB.GetDataSet(sqlstring, "TABLE1");
                if (DS != null)
                {
                    if (DS.Tables.Count > 0)
                    {
                        foreach (DataRow DR in DS.Tables[0].Rows)
                        {
                            SubCategory objsubCAT = new SubCategory();
                            objsubCAT.SubCategoryId = int.Parse(DR["SUBCATEGORYID"].ToString());
                            objsubCAT.SubCategoryName = DR["SUBCATEGORYNAME"].ToString();
                            objsubCAT.CategoryId = int.Parse(DR["CATEGORYID"].ToString());
                            objsubCAT.Category = new Category(); 
                            objsubCAT.Category.CategoryID = int.Parse(DR["CATEGORYID"].ToString());
                            objsubCAT.Category.CategoryName  = DR["CATEGORYNAME"].ToString();
                            objresult.Add(objsubCAT);
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
        public bool Add(SubCategory objsubCat)
        {
            try
            {

                DAL DB = new DAL(ConnectionString);
                string sqlstring = "INSERT INTO SUBCATEGORIES(SUBCATEGORYNAME,CATEGORYID) VALUES ('" + objsubCat.SubCategoryName + "','" + objsubCat.CategoryId.ToString() + "')";
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