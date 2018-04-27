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
    public class classBattery
    {
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt;
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        public bool FillCurrentBatt(ListView lv, int bnum)
        {
            bool Okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblNewBatt WHERE BNum = '" + bnum + "'", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["Brand"].ToString());
                        item.SubItems.Add(dt.Rows[i]["SerialNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Type"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Remark"].ToString());
                        lv.Items.Add(item);
                    }
                    con.Close();

                    Okay = true;
                }
                catch (Exception ex)
                {
                    Okay = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Okay;
        }
        public bool FillOldBatt(ListView lv, int bnum)
        {
            bool Okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblOldBatt WHERE BNum = '" + bnum + "'", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["Date"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Brand"].ToString());
                        item.SubItems.Add(dt.Rows[i]["SerialNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Type"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Remark"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Bat_ID"].ToString());
                        lv.Items.Add(item);
                    }
                    con.Close();

                    Okay = true;
                }
                catch (Exception ex)
                {
                    Okay = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Okay;
        }
        public bool AddCurrentBatt(ListView lv, string bnum, string driver)
        {
            bool Added;
            int tid;
            CountNBatt();
            tid = Convert.ToInt32(nCount);   
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    for (int i = 0; i < lv.Items.Count; i++)
                    {
                        tid++;
                        con.Open();
                        com = new SqlCeCommand(@"INSERT INTO tblNewBatt(Bat_ID,BNum,Date,Brand,SerialNum,Type,Driver,Remark) 
                                             VALUES (@Bat_ID,@BNum,@Date,@Brand,@SerialNum,@Type,@Driver,@Remark)", con);
                        com.Parameters.AddWithValue("@Bat_ID", tid);
                        com.Parameters.AddWithValue("@BNum", bnum);
                        com.Parameters.AddWithValue("@Driver", driver);
                        com.Parameters.AddWithValue("@Brand", lv.Items[i].SubItems[0].Text);
                        com.Parameters.AddWithValue("@SerialNum", lv.Items[i].SubItems[1].Text);
                        com.Parameters.AddWithValue("@Type", lv.Items[i].SubItems[2].Text);
                        com.Parameters.AddWithValue("@Date", lv.Items[i].SubItems[3].Text);
                        com.Parameters.AddWithValue("@Remark", lv.Items[i].SubItems[4].Text);
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
        public bool AddOldBatt(ListView lv, string bnum, string driver)
        {
            bool Adds;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                int tid;
                CountOBatt();
                tid = Convert.ToInt32(oCount);

                try
                {
                    for (int i = 0; i < lv.Items.Count; i++)
                    {
                        tid++;
                        con.Open();
                        com = new SqlCeCommand(@"INSERT INTO tblOldBatt(Bat_ID,BNum,Date,Brand,SerialNum,Type,Driver,Remark) 
                                             VALUES (@Bat_ID,@BNum,@Date,@Brand,@SerialNum,@Type,@Driver,@Remark)", con);
                        com.Parameters.AddWithValue("@Bat_ID", tid);
                        com.Parameters.AddWithValue("@BNum", bnum);
                        com.Parameters.AddWithValue("@Driver", driver);
                        com.Parameters.AddWithValue("@Brand", lv.Items[i].SubItems[0].Text);
                        com.Parameters.AddWithValue("@SerialNum", lv.Items[i].SubItems[1].Text);
                        com.Parameters.AddWithValue("@Type", lv.Items[i].SubItems[2].Text);
                        com.Parameters.AddWithValue("@Date", lv.Items[i].SubItems[3].Text);
                        com.Parameters.AddWithValue("@Remark", lv.Items[i].SubItems[4].Text);
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                    Adds = true;
                }
                catch (Exception ex)
                {
                    Adds = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Adds;
        }
        public bool DeleteCurrentBatt(int bnum)
        {
            bool Done;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE FROM tblNewBatt WHERE BNum = '" + bnum + "'", con);
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
        public bool DeleteOldBatt(ListView lv, int bnum)
        {
            bool okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    for (int i = 0; i < lv.CheckedItems.Count; i++)
                    {
                        ListViewItem item = lv.CheckedItems[i];
                        con.Open();
                        com = new SqlCeCommand("DELETE FROM tblOldBatt WHERE Bat_ID = " + item.SubItems[6].Text, con);
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
        public void CountNBatt()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                com = new SqlCeCommand("SELECT MAX(Bat_ID) as Tot FROM tblNewBatt", con);
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
        public void CountOBatt()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                com = new SqlCeCommand("SELECT MAX(Bat_ID) as Tot FROM tblOldBatt", con);
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
