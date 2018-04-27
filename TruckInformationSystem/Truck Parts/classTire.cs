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
    public class classTire
    {
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt;
        public bool FillCurrentTire(ListView lv, int bnam)
        {
            bool Filled;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblNewTire WHERE BNum = '"+bnam+"'", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["Brand"].ToString());
                        item.SubItems.Add(dt.Rows[i]["SerialNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["CompNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Remarks"].ToString());
                        lv.Items.Add(item);
                    }
                    con.Close();

                    Filled = true;
                }
                catch (Exception ex)
                {
                    Filled = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Filled;
        }
        public bool FillOldTire(ListView lv2, int bnum)
        {
            bool okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblOldTire WHERE BNum = '" + bnum + "' ORDER BY Date DESC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["Date"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Brand"].ToString());
                        item.SubItems.Add(dt.Rows[i]["SerialNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["CompNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Remarks"].ToString());
                        item.SubItems.Add(dt.Rows[i]["T_ID"].ToString());
                        lv2.Items.Add(item);
                    }
                    con.Close();
                    okay = true;
                }
                catch (Exception ex)
                {
                    okay = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return okay;
        }
        public bool AddCurrentTire(ListView lv,string bnum,string driver)
                                   
        {
            bool Added;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                int tid;
                CountNTire();
                tid = Convert.ToInt32(nCount);
                
                try
                { 
                    for (int i = 0; i < lv.Items.Count; i++)
                    {
                        tid++;
                        con.Open();
                        com = new SqlCeCommand(@"INSERT INTO tblNewTire(T_ID,BNum,Date,Brand,SerialNum,CompNum,Driver,Remarks) 
                                             VALUES (@T_ID,@BNum,@Date,@Brand,@SerialNum,@CompNum,@Driver,@Remarks)", con);
                        com.Parameters.AddWithValue("@T_ID", tid);
                        com.Parameters.AddWithValue("@BNum", bnum);
                        com.Parameters.AddWithValue("@Driver", driver);
                        com.Parameters.AddWithValue("@Brand", lv.Items[i].SubItems[0].Text);
                        com.Parameters.AddWithValue("@SerialNum", lv.Items[i].SubItems[1].Text);
                        com.Parameters.AddWithValue("@CompNum", lv.Items[i].SubItems[2].Text); 
                        com.Parameters.AddWithValue("@Date", lv.Items[i].SubItems[3].Text);     
                        com.Parameters.AddWithValue("@Remarks", lv.Items[i].SubItems[4].Text);
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                    Added = true;
                }
                catch (Exception ex)
                {
                    Added = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Added;
        }
        public bool AddOldTire(ListView lv, string bnum, string driver)
        {
            bool Added;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                int tid;
                CountOTire();
                tid = Convert.ToInt32(oCount);

                try
                {
                    for (int i = 0; i < lv.Items.Count; i++)
                    {
                        tid++;
                        con.Open();
                        com = new SqlCeCommand(@"INSERT INTO tblOldTire(T_ID,BNum,Date,Brand,SerialNum,CompNum,Driver,Remarks) 
                                             VALUES (@T_ID,@BNum,@Date,@Brand,@SerialNum,@CompNum,@Driver,@Remarks)", con);
                        com.Parameters.AddWithValue("@T_ID", tid);
                        com.Parameters.AddWithValue("@BNum", bnum);
                        com.Parameters.AddWithValue("@Driver", driver);
                        com.Parameters.AddWithValue("@Brand", lv.Items[i].SubItems[0].Text);
                        com.Parameters.AddWithValue("@SerialNum", lv.Items[i].SubItems[1].Text);
                        com.Parameters.AddWithValue("@CompNum", lv.Items[i].SubItems[2].Text);
                        com.Parameters.AddWithValue("@Date", lv.Items[i].SubItems[3].Text);
                        com.Parameters.AddWithValue("@Remarks", lv.Items[i].SubItems[4].Text);
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                    Added = true;
                }
                catch (Exception ex)
                {
                    Added = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Added;
        }
        public bool DeleteCurrentTire(int bnum)
        {
            bool Done;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE FROM tblNewTire WHERE BNum = '" + bnum + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    Done = true;
                }
                catch (Exception ex)
                {
                    Done = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Done;
        }
        public bool DeleteAllOldTire(ListView lv2,int bnum)
        {
            bool okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    for (int i = 0; i < lv2.CheckedItems.Count; i++)
                    {
                        ListViewItem item = lv2.CheckedItems[i];
                        con.Open();
                        com = new SqlCeCommand("DELETE FROM tblOldTire WHERE T_ID = " + item.SubItems[6].Text, con);
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                    okay = true;
                }
                catch (Exception ex)
                {
                    okay = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return okay;
        }
        string nCount;
        public void CountNTire()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                com = new SqlCeCommand("SELECT MAX(T_ID) as Tot FROM tblNewTire", con);
                con.Open();
                da = new SqlCeDataAdapter(com);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0]["Tot"] != DBNull.Value)
                {
                    nCount = dt.Rows[0]["Tot"].ToString();
                }
                else
                {
                    nCount = "0";

                }
                con.Close();
            }
        }
        string oCount;
        public void CountOTire()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                com = new SqlCeCommand("SELECT MAX(T_ID) as Tot FROM tblOldTire", con);
                con.Open();
                da = new SqlCeDataAdapter(com);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0]["Tot"] != DBNull.Value)
                {
                    oCount = dt.Rows[0]["Tot"].ToString();
                }
                else
                {
                    oCount = "0";
                }
                con.Close();
            }
        }

    }
}
