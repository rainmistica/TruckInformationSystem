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
    public class ClassTruckProf
    {
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt;
        SqlCeDataReader dr; 
        bool Updated;
        public bool UpdateData(int bnum,string driv,string rf,
            string en,string cn,string orcr,string st,string insur,
            string casno,string app,string mot,string proba)
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand(@"UPDATE tblDTruck SET Driver=@Driver,RFNum=@RFNum,EngNum=@EngNum,ChasNum=@ChasNum,ORCR=@ORCR,STest=@STest,Insur=@Insur,CaseNum=@CaseNum,
                                            Application=@Application,Motion=@Motion,ProbAuth=@ProbAuth WHERE BNum = '" + bnum + "'", con);
                    com.Parameters.AddWithValue("@Driver", driv);
                    com.Parameters.AddWithValue("@RFNum", rf);
                    com.Parameters.AddWithValue("@EngNum", en);
                    com.Parameters.AddWithValue("@ChasNum", cn);
                    com.Parameters.AddWithValue("@ORCR", orcr);
                    com.Parameters.AddWithValue("@STest", st);
                    com.Parameters.AddWithValue("@Insur", insur);
                    com.Parameters.AddWithValue("@CaseNum", casno);
                    com.Parameters.AddWithValue("@Application", app);
                    com.Parameters.AddWithValue("@Motion", mot);
                    com.Parameters.AddWithValue("@ProbAuth", proba);
                    com.ExecuteNonQuery();
                    con.Close();
                    Updated = true;
                }
                catch (Exception ex)
                {
                    Updated = false;
                    Console.WriteLine(ex.Message);
                }
            }

            return Updated;
        }
        bool FC;
        public bool FillCO(DateTimePicker LD, DateTimePicker ND, int bnum)
        {
          
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                con.Open();
                com = new SqlCeCommand("Select LastDate,NextDate FROM tblChangeOil WHERE BNum = '" + bnum + "'", con);
                da = new SqlCeDataAdapter(com);
                dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    LD.Text = dt.Rows[0]["LastDate"].ToString();
                    ND.Text = dt.Rows[0]["NextDate"].ToString();
                    con.Close();
                    FC = true;
                }
                catch (Exception ex)
                {
                    FC = false;
                    Console.WriteLine(ex.Message);
                }
            }

            return FC;
        }
        public bool FillCurrentTire(ListView lv, int bnum)
        {
            bool Filled;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblNewTire WHERE BNum = '" + bnum + "'", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["Brand"].ToString());
                        item.SubItems.Add(dt.Rows[i]["SerialNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["CompNum"].ToString());
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
        public bool FillPlateNumber(ComboBox PN,int bnum)
        {
            bool Success;
            PN.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            PN.AutoCompleteSource = AutoCompleteSource.CustomSource;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    com = new SqlCeCommand(@"SELECT PNum FROM tblDTruck", con);
                    con.Open();
                    dr = com.ExecuteReader();
                    AutoCompleteStringCollection Pnum = new AutoCompleteStringCollection();
                    while (dr.Read())
                    {
                        Pnum.Add(dr.GetString(0));
                    }
                    PN.AutoCompleteCustomSource = Pnum;
                    con.Close();
                    Success = true;
                }
                catch (Exception ex)
                {
                    Success = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Success;
        }

        public bool EditCO(string LD,string ND, int bnum)
        {
            bool Done;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                
                try
                {
                    con.Open();
                    com = new SqlCeCommand(@"UPDATE tblChangeOil SET LastDate=@LastDate,NextDate=@NextDate WHERE BNum = '" + bnum + "'", con);
                    com.Parameters.AddWithValue("@LastDate", LD);
                    com.Parameters.AddWithValue("@NextDate", ND);
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

        public bool AddCH(string savhist,int bnum)
        {
            bool Addhist;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                int ctr;
                CountOil();
                ctr = Convert.ToInt32(cou);
                ctr++;
                try
                {
                    con.Open();
                    com = new SqlCeCommand("INSERT INTO tblOilHistory(OH_ID,BNum,LastDate) VALUES (@OH_ID,@BNum,@LastDate)", con);
                    com.Parameters.AddWithValue("@OH_ID", ctr);
                    com.Parameters.AddWithValue("@BNum", bnum);
                    com.Parameters.AddWithValue("@LastDate",savhist);
                    com.ExecuteNonQuery();
                    con.Close();
                    Addhist = true;
                }
                catch (Exception ex)
                {
                    Addhist = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Addhist;

        }
        string cou;
        public void CountOil()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                com = new SqlCeCommand("SELECT MAX(OH_ID) as Tot FROM tblOilHistory", con);
                con.Open();
                da = new SqlCeDataAdapter(com);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0]["Tot"] != DBNull.Value)
                {
                   cou = dt.Rows[0]["Tot"].ToString();
                }
                else
                {
                   cou = "0";

                }
                con.Close();
            }

        }
        
        public bool FillCOH(ListView lv,int bnam)
        {
            bool fCo;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblOilHistory   WHERE BNum = '" + bnam + "' ORDER BY LastDate ASC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["LastDate"].ToString());
                        lv.Items.Add(item);
                    }
                    con.Close();
                    fCo = true;
                }
                catch (Exception ex)
                {
                    fCo = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return fCo;
        }
      
        public bool DeleteOilDate(int bnum, string date)
        {
            bool dOil;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE FROM tblOilHistory WHERE BNum = '" + bnum + "' AND LastDate = '" + date + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                    dOil = true;
                }
                catch (Exception ex)
                {
                    dOil = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return dOil;

        }

    }
}
