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
    public class classTools
    {
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        SqlCeCommand com;
        SqlCeDataReader dr;
        public bool FillDatas(TextBox tc, TextBox tw, TextBox op, TextBox jack, TextBox ewd,
                              DateTimePicker dtc, DateTimePicker dtw, DateTimePicker dtop, DateTimePicker dtj, DateTimePicker dtewd, int bnum)
        {
            bool okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    com = new SqlCeCommand("SELECT * FROM tblTools WHERE BNum = '"+bnum+"'", con);
                    con.Open();
                    dr = com.ExecuteReader();     
                    while (dr.Read())
                    {
                        tc.Text = dr.GetString(dr.GetOrdinal("TC"));
                        dtc.Text = dr.GetString(dr.GetOrdinal("TCD"));
                        tw.Text = dr.GetString(dr.GetOrdinal("TW"));
                        dtw.Text = dr.GetString(dr.GetOrdinal("TWD"));
                        op.Text = dr.GetString(dr.GetOrdinal("OP"));
                        dtop.Text = dr.GetString(dr.GetOrdinal("OPD"));
                        jack.Text = dr.GetString(dr.GetOrdinal("Jack"));
                        dtj.Text = dr.GetString(dr.GetOrdinal("JackD"));
                        ewd.Text = dr.GetString(dr.GetOrdinal("EWD"));
                        dtewd.Text = dr.GetString(dr.GetOrdinal("EWDD"));
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
        public bool FillProfData(DateTimePicker dtc, DateTimePicker dtw, DateTimePicker dtop, DateTimePicker dtj, DateTimePicker dtewd, int bnum)
        {
            bool okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    com = new SqlCeCommand("SELECT * FROM tblTools WHERE BNum = '" + bnum + "'", con);
                    con.Open();
                    dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        dtc.Text = dr.GetString(dr.GetOrdinal("TCD"));
                        dtw.Text = dr.GetString(dr.GetOrdinal("TWD"));
                        dtop.Text = dr.GetString(dr.GetOrdinal("OPD"));
                        dtj.Text = dr.GetString(dr.GetOrdinal("JackD"));
                        dtewd.Text = dr.GetString(dr.GetOrdinal("EWDD"));
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
        public bool EditData(string tc, string tw, string op, string jack, string ewd,
                             string dtc,string dtw, string dtop, string dtj, string dtewd, int bnum)
        {
            bool eDited;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand(@"UPDATE tblTools SET TC=@TC,TCD=@TCD,TW=@TW,TWD=@TWD,OP=@OP,OPD=@OPD,Jack=@Jack,
                                             JackD=@JackD,EWD=@EWD,EWDD=@EWDD WHERE BNum = '" + bnum + "'", con);
                    com.Parameters.AddWithValue("@TC", tc);
                    com.Parameters.AddWithValue("@TCD", dtc);
                    com.Parameters.AddWithValue("@TW", tw);
                    com.Parameters.AddWithValue("@TWD", dtw);
                    com.Parameters.AddWithValue("@OP", op);
                    com.Parameters.AddWithValue("@OPD", dtop);
                    com.Parameters.AddWithValue("@Jack", jack);
                    com.Parameters.AddWithValue("@JackD", dtj);
                    com.Parameters.AddWithValue("@EWD", ewd);
                    com.Parameters.AddWithValue("@EWDD", dtewd);
                    com.ExecuteNonQuery();
                    con.Close();
                    eDited = true;
                }
                catch (Exception ex)
                {
                    eDited = false;
                    MessageBox.Show(ex.Message);
                }
                return eDited;
            }
        }
    }

}
