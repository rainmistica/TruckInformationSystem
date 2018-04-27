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
    public class classTruckIndiv
    {
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt;
        SqlCeDataReader dr;
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
                    com = new SqlCeCommand(@"SELECT DISTINCT BNum FROM tblTruckFile", con);
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
                    com = new SqlCeCommand(@"SELECT DISTINCT PNum FROM tblTruckFile WHERE BNum = '" + int.Parse(bnum.Text) + "'", con);
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
        public bool FillComboSDate(ComboBox sdate, TextBox bnum)
        {
            bool oks;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    com = new SqlCeCommand(@"SELECT DISTINCT SDate FROM tblTruckFile WHERE BNum = '" + int.Parse(bnum.Text) + "'", con);
                    con.Open();
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        sdate.Items.Add(dr.GetString(0));
                    };
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
        public bool FillSpecData(ListView lv, ComboBox sdate, TextBox bnum, Label jo, Label mech, Label df)
        {
            bool Dones;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblTruckFile WHERE SDate = '" + sdate.Text + "' AND BNum = '" + int.Parse(bnum.Text) + "'", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        jo.Text = dt.Rows[i]["JobOrder"].ToString();
                        ListViewItem item = new ListViewItem(dt.Rows[i]["Parts"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Price"].ToString());
                        item.SubItems.Add(dt.Rows[i]["BShop"].ToString());
                        item.SubItems.Add(dt.Rows[i]["ORN"].ToString());
                        item.SubItems.Add(dt.Rows[i]["TF_ID"].ToString());
                        mech.Text = dt.Rows[i]["Mechanic"].ToString();
                        df.Text = dt.Rows[i]["FDate"].ToString();
                        lv.Items.Add(item);
                    }
                    con.Close();

                    Dones = true;
                }
                catch (Exception ex)
                {
                    Dones = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Dones;
        }
        public bool FillGenInfo(ListView lv, TextBox bnum)
        {
            bool Dones;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblTruckFile WHERE BNum = '" + int.Parse(bnum.Text) + "'", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["Parts"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Price"].ToString());
                        item.SubItems.Add(dt.Rows[i]["BShop"].ToString());
                        item.SubItems.Add(dt.Rows[i]["ORN"].ToString());
                        item.SubItems.Add(dt.Rows[i]["TF_ID"].ToString());
                        lv.Items.Add(item);
                    }
                    con.Close();

                    Dones = true;
                }
                catch (Exception ex)
                {
                    Dones = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Dones;
        }
        public void ChangeOilMonitoring(ListView lv)
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                var dta = DateTime.Now.ToShortDateString();
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblChangeOil WHERE NextDate >= '" + dta + "' ORDER BY NextDate ASC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                        string conc = dt.Rows[i]["NextDate"].ToString();
                        DateTime dtf = Convert.ToDateTime(conc);
                        item.SubItems.Add(dtf.ToShortDateString());
                        lv.Items.Add(item);
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
