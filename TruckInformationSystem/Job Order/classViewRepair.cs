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
    public class classViewRepair
    {
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt;
        public void fillData(ListView lv)
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                DateTime sdate,fdate;
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblFinish ORDER BY SDate ASC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["SDate"].ToString());
                        item.SubItems.Add(dt.Rows[i]["JobOrder"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Mechanic"].ToString());
                        item.SubItems.Add(dt.Rows[i]["FDate"].ToString());
                        sdate = Convert.ToDateTime(item.SubItems[2].Text);
                        fdate = Convert.ToDateTime(item.SubItems[5].Text);
                        TimeSpan dp = fdate.Subtract(sdate);
                        item.SubItems.Add(dp.Days.ToString()+" Days");
                        item.SubItems.Add(dt.Rows[i]["F_ID"].ToString());
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
        public bool delHistory(ListView lv)
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
                        com = new SqlCeCommand("DELETE FROM tblFinish WHERE F_ID = " + item.SubItems[7].Text, con);
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
        public bool SearchParam(ListView lv, DateTimePicker sdate, DateTimePicker fdate)
        {
            bool Oks;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                DateTime sdatee, fdatee;
                try
                {
                    con.Open();
                    com = new SqlCeCommand("SELECT * FROM tblFinish WHERE SDate >= '" + sdate.Text + "' AND SDate <= '" + fdate.Text + "' ORDER BY SDate ASC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["SDate"].ToString());
                        item.SubItems.Add(dt.Rows[i]["JobOrder"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Mechanic"].ToString());
                        item.SubItems.Add(dt.Rows[i]["FDate"].ToString());
                        sdatee = Convert.ToDateTime(item.SubItems[2].Text);
                        fdatee = Convert.ToDateTime(item.SubItems[5].Text);
                        TimeSpan dp = fdatee.Subtract(sdatee);
                        item.SubItems.Add(dp.Days.ToString() + " Days");
                        item.SubItems.Add(dt.Rows[i]["F_ID"].ToString());
                        lv.Items.Add(item);
                    }
                    con.Close();

                    Oks = true;
                }
                catch (Exception ex)
                {
                    Oks = false;
                    MessageBox.Show(ex.Message);
                }
            }
            return Oks;
        }
    }
}
