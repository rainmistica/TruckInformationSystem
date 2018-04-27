using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
namespace TruckInformationSystem
{
    public class classSaveFinish
    {
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        SqlCeCommand com;
        public bool AddFinishOrder(int bnum,string pnum,string sdate,string jobord,string mecha,string fdate)
        {
            bool addFinish;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand(@"INSERT INTO tblFinish(BNum,PNum,SDate,JobOrder,Mechanic,FDate) 
                                            VALUES (@BNum,@PNum,@SDate,@JobOrder,@Mechanic,@FDate)", con);
                    com.Parameters.AddWithValue("@BNum", bnum);
                    com.Parameters.AddWithValue("@PNum", pnum);
                    com.Parameters.AddWithValue("@SDate", sdate);
                    com.Parameters.AddWithValue("@JobOrder", jobord);
                    com.Parameters.AddWithValue("@Mechanic", mecha);
                    com.Parameters.AddWithValue("@FDate", fdate);
                    com.ExecuteNonQuery();
                    con.Close();

                    addFinish = true;
                }
                catch (Exception ex)
                {
                    addFinish = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return addFinish;
        }
        public bool AddTruckFile(int bnum, string pnum, string sdate, string jobord,
            string parts, decimal price, string shop, string ORN, string mecha, string fdate)
        {
            bool addTFile;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand(@"INSERT INTO tblTruckFile(BNum,PNum,SDate,JobOrder,Parts,Price,BShop,ORN,Mechanic,FDate) 
                                                          VALUES(@BNum,@PNum,@SDate,@JobOrder,@Parts,@Price,@BShop,@ORN,@Mechanic,@FDate)", con);
                    com.Parameters.AddWithValue("@BNum", bnum);
                    com.Parameters.AddWithValue("@PNum", pnum);
                    com.Parameters.AddWithValue("@SDate", sdate);
                    com.Parameters.AddWithValue("@JobOrder", jobord);
                    com.Parameters.AddWithValue("@Parts", parts);
                    com.Parameters.AddWithValue("@Price", price);
                    com.Parameters.AddWithValue("@BShop", shop);
                    com.Parameters.AddWithValue("@ORN", ORN);
                    com.Parameters.AddWithValue("@Mechanic", mecha);
                    com.Parameters.AddWithValue("@FDate", fdate);
                    com.ExecuteNonQuery();
                    con.Close();

                    addTFile = true;
                }
                catch (Exception ex)
                {
                    addTFile = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return addTFile;
        }
        public bool DeleteJobOrder(int id)
        {
            bool delDone;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE FROM tblJobOrder WHERE J_ID = '" + id + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
              
                    delDone = true;
                }
                catch (Exception ex)
                {
                    delDone = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return delDone;
        }
    }
}
