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
    public class classDriver
    {
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt;
        SqlCeDataReader dr;
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        public bool fillDriverList(ListView Lv)
        {
            bool okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblDriver ORDER BY FName ASC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["ID"].ToString());
                        item.SubItems.Add(dt.Rows[i]["FName"].ToString());
                        Lv.Items.Add(item);
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
        public bool fillDriverHistory(ListView Lv,int bnum)
        {
            bool okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblDriverHistory WHERE BNum = '"+ bnum +"'ORDER BY Date DESC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["Date"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Driver"].ToString());
                        item.SubItems.Add(dt.Rows[i]["D_ID"].ToString());
                        Lv.Items.Add(item);
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
        public bool AddDriver(string fn)
        {
            bool Added;    
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    CountDriver();
                    int ctr;
                    ctr = Convert.ToInt32(_count);
                    ctr++;
                    con.Open();
                    com = new SqlCeCommand("INSERT INTO tblDriver(ID,FName) VALUES (@ID,@FName)", con);
                    com.Parameters.AddWithValue("ID", ctr);
                    com.Parameters.AddWithValue("FName", fn);
                    com.ExecuteNonQuery();
                    con.Close();
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
        public bool AddDriverHistory(int bnum,string driv)
        {
            bool Added;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    CountDriverHist();
                    int ctr;
                    ctr = Convert.ToInt32(_dhcount);
                    ctr++;
                    con.Open();
                    com = new SqlCeCommand("INSERT INTO tblDriverHistory(D_ID,BNum,Driver,Date) VALUES (@D_ID,@BNum,@Driver,@Date)", con);
                    com.Parameters.AddWithValue("@D_ID", ctr);
                    com.Parameters.AddWithValue("@BNum", bnum);
                    com.Parameters.AddWithValue("@Driver",driv);
                    com.Parameters.AddWithValue("@Date", DateTime.Now.ToShortDateString());
                    com.ExecuteNonQuery();
                    con.Close();
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
        public bool EditDriver(int id, string fn)
        {
            bool Edited;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("UPDATE tblDriver SET FName=@FName WHERE ID='" + id + "'", con);
                    com.Parameters.AddWithValue("FName", fn);
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
        public bool DeleteDriver(int id)
        {
            bool Deleted;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE tblDriver where ID = '" + id + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();

                    Deleted = true;
                }
                catch (Exception ex)
                {
                    Deleted = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Deleted;
        }
        public bool DeleteDriverHistory(ListView lv)
        {
            bool Deleted;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    for (int i = 0; i < lv.CheckedItems.Count; i++)
                    {
                        ListViewItem item = lv.CheckedItems[i];
                        con.Open();
                        com = new SqlCeCommand("DELETE FROM tblDriverHistory WHERE D_ID = " + item.SubItems[2].Text, con);
                        com.ExecuteNonQuery();
                        con.Close();
                    }

                    Deleted = true;
                }
                catch (Exception ex)
                {
                    Deleted = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Deleted;
        }
        public bool fillDriverProf(TextBox txt)
        {
            bool okay;
            txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select FName From tblDriver", con);
                    dr = com.ExecuteReader();
                    AutoCompleteStringCollection DName = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        DName.Add(dr.GetString(0));
                    }
                    txt.AutoCompleteCustomSource = DName;
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
        string _count;
        private void CountDriver()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                com = new SqlCeCommand("SELECT MAX(ID) as Tot FROM tblDriver", con);
                con.Open();
                da = new SqlCeDataAdapter(com);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0]["Tot"] != DBNull.Value)
                {
                    _count = dt.Rows[0]["Tot"].ToString();
                }
                else
                {
                    _count = "0";
                }
                con.Close();
            }
        }
        string _dhcount;
        private void CountDriverHist()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                com = new SqlCeCommand("SELECT MAX(D_ID) as Tot FROM tblDriverHistory", con);
                con.Open();
                da = new SqlCeDataAdapter(com);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0]["Tot"] != DBNull.Value)
                {
                    _dhcount = dt.Rows[0]["Tot"].ToString();
                }
                else
                {
                    _dhcount = "0";
                }
                con.Close();
            }
        }
    }
}
