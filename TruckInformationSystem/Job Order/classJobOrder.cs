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
    class classJobOrder
    {
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt;
        SqlCeDataReader dr; 
        public void FillJO(ListView lv)
        {
            lv.Items.Clear();
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                DateTime indate;
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblJobOrder ORDER BY Date DESC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["J_ID"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Date"].ToString());
                        item.SubItems.Add(dt.Rows[i]["BNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Description"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Mech"].ToString());
                        indate = Convert.ToDateTime(item.SubItems[1].Text);
                        TimeSpan dp = DateTime.Now.Subtract(indate);
                        item.SubItems.Add(dp.Days.ToString());
                        lv.Items.Add(item);
                    }
                    con.Close();        
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public bool AddJO(string datee,string bn,string pn,string desca,string mecha)
        {
            bool Added;
            int tid;
            CountJO();
            tid = Convert.ToInt32(nCount);   
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    tid++;
                    con.Open();
                    com = new SqlCeCommand("INSERT INTO tblJobOrder (J_ID,BNum,PNum,Date,Description,Mech) VALUES (@J_ID,@BNum,@PNum,@Date,@Description,@Mech)", con);
                    com.Parameters.AddWithValue("@J_ID",tid);
                    com.Parameters.AddWithValue("@BNum",bn);
                    com.Parameters.AddWithValue("@PNum",pn);
                    com.Parameters.AddWithValue("@Date",datee);
                    com.Parameters.AddWithValue("@Description",desca);
                    com.Parameters.AddWithValue("@Mech",mecha);
                    com.ExecuteNonQuery();
                    con.Close();

                    Added = true;
                }
                catch (Exception ex)
                {
                    Added = false;
                    MessageBox.Show(ex.Message);
                }
            }
            return Added;
        }
        public bool EditJO(int ids, string datee, string bn, string pn, string desca, string mecha)
        {
            bool Edited;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand(@"UPDATE tblJobOrder SET BNum=@BNum,PNum=@PNum,Date=@Date,Description=@Description,Mech=@Mech WHERE J_ID = '" + ids + "'", con);
                    com.Parameters.AddWithValue("@BNum", bn);
                    com.Parameters.AddWithValue("@PNum", pn);
                    com.Parameters.AddWithValue("@Date", datee);
                    com.Parameters.AddWithValue("@Description", desca);
                    com.Parameters.AddWithValue("@Mech", mecha);
                    com.ExecuteNonQuery();
                    con.Close();

                    Edited = true;
                }
                catch (Exception ex)
                {
                    Edited = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Edited;
        }
        public bool DeleteJO(int ids)
        {
            bool Done;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE FROM tblJobOrder WHERE J_ID = '" + ids + "'", con);
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
        public bool FillBody(TextBox Bnuma)
        {
            bool oks;
            Bnuma.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Bnuma.AutoCompleteSource = AutoCompleteSource.CustomSource;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    int bnums;
                    com = new SqlCeCommand(@"SELECT BNum FROM tblDTruck", con);
                    con.Open();
                    dr = com.ExecuteReader();
                    AutoCompleteStringCollection Bnam = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        bnums = dr.GetInt32(0);
                        Bnam.Add(bnums.ToString());
                    }
                    Bnuma.AutoCompleteCustomSource = Bnam;
                    con.Close();
                    oks = true;
                }
                catch (Exception ex)
                {
                    oks = false;
                    Console.WriteLine(ex.Message);
                }
                return oks;
            }
        }
        public bool FillPlateNum(TextBox bnum, Label pnum)
        {
            bool oks;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    com = new SqlCeCommand(@"SELECT PNum FROM tblDTruck WHERE BNum = '" + int.Parse(bnum.Text) + "'", con);
                    con.Open();
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                       pnum.Text = string.Empty;
                    }
                    else
                    {
                        pnum.Text = dt.Rows[0]["PNum"].ToString();
                    }
                    con.Close();
                    oks = true;
                }
                catch (Exception ex)
                {
                    oks = false;
                    Console.WriteLine(ex.Message);
                }
                return oks;
            }
        }
        string nCount;
        public void CountJO()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                com = new SqlCeCommand("SELECT MAX(J_ID) as Tot FROM tblJobOrder", con);
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
    }
}
