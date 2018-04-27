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
    public class classTruckInfo
    {
        public string GetCon()
        {
            return "Data Source=" + System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf; Persist Security Info=False");
        }
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt;
        string count,countt;
        public bool InsertData(int bnum, string pnum, string type, string gar)
        {
            bool Success;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("INSERT INTO tblDTruck(BNum,PNum,Type,BGar) VALUES (@BNum, @PNum, @Type, @BGar)", con);
                    com.Parameters.AddWithValue("@BNum", bnum);
                    com.Parameters.AddWithValue("@PNum", pnum);
                    com.Parameters.AddWithValue("@Type", type);
                    com.Parameters.AddWithValue("@BGar", gar);
                    com.ExecuteNonQuery();
                    con.Close();
                    Success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Success = false;
                }
            }
            return Success;
        }
        public bool AddOil(int bnum)
        {
            bool success;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                int ctr;
                CountMaxOil();
                ctr = Convert.ToInt32(count);
                ctr++;
                try
                {
                    con.Open();
                    com = new SqlCeCommand("INSERT INTO tblChangeOil(Oil_ID,BNum) VALUES (@Oil_ID,@BNum)", con);
                    com.Parameters.AddWithValue("@Oil_ID", ctr);
                    com.Parameters.AddWithValue("@BNum", bnum);
                    com.ExecuteNonQuery();
                    con.Close();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
        public bool EditOil(int bnum,int bnam)
        {
            bool Done;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("UPDATE tblChangeOil SET BNum=@BNum WHERE BNum = '" + bnam + "'", con);
                    com.Parameters.AddWithValue("@BNum", bnum);
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
        public bool DelOil(int bnum)
        {
            bool Okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE FROM tblChangeOil WHERE BNum = '" + bnum + "'", con);
                    com.ExecuteNonQuery();
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
        public bool AddTool(int bnum)
        {
            bool success;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                int ctr;
                CountMaxTool();
                ctr = Convert.ToInt32(countt);
                ctr++;
                try
                {
                    con.Open();
                    com = new SqlCeCommand("INSERT INTO tblTools(TID,BNum) VALUES (@TID,@BNum)", con);
                    com.Parameters.AddWithValue("@TID", ctr);
                    com.Parameters.AddWithValue("@BNum", bnum);
                    com.ExecuteNonQuery();
                    con.Close();
                    success = true;
                }
                catch (Exception ex)
                {
                    success = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return success;
        }
        public bool EditTool(int bnum, int bnam)
        {
            bool Done;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("UPDATE tblTools SET BNum=@BNum WHERE BNum = '" + bnam + "'", con);
                    com.Parameters.AddWithValue("@BNum", bnum);
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
        public bool DelTool(int bnum)
        {
            bool Okay;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE FROM tblTools WHERE BNum = '" + bnum + "'", con);
                    com.ExecuteNonQuery();
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
        public void CountMaxOil()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    com = new SqlCeCommand("SELECT MAX(Oil_ID) as Tot FROM tblChangeOil", con);
                    con.Open();
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows[0]["Tot"] != DBNull.Value)
                    {
                        count = dt.Rows[0]["Tot"].ToString();
                    }
                    else
                    {
                        count = "0";
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
           
        }
        public void CountMaxTool()
        {
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    com = new SqlCeCommand("SELECT MAX(TID) as Tot FROM tblTools", con);
                    con.Open();
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows[0]["Tot"] != DBNull.Value)
                    {
                        countt = dt.Rows[0]["Tot"].ToString();
                    }
                    else
                    {
                        countt = "0";
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
        }
        public bool RemoveData(int bnum)
        {
            bool Removed;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("DELETE FROM tblDTruck WHERE BNum = '" + bnum + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();

                    Removed = true;
                }
                catch (Exception ex)
                {
                    Removed = false;
                    Console.WriteLine(ex.Message);
                }
            }
            return Removed;
        }
        public bool EditData(int bnum, string pnum, string type, string gar, int ednum)
        {
            bool Updated;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("UPDATE tblDTruck SET BNum=@BNum,PNum=@PNum,Type=@Type,BGar=@BGar WHERE BNum = '" + ednum + "'", con);
                    com.Parameters.AddWithValue("@BNum", bnum);
                    com.Parameters.AddWithValue("@PNum", pnum);
                    com.Parameters.AddWithValue("@Type", type);
                    com.Parameters.AddWithValue("@BGar", gar);
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
        
        public bool FillData(ListView lv)
        {
            bool Filled;
            using (SqlCeConnection con = new SqlCeConnection(GetCon()))
            {
                try
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblDTruck ORDER BY BNum ASC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Type"].ToString());
                        item.SubItems.Add(dt.Rows[i]["BGar"].ToString());
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
        
        public bool ComboSearch(ComboBox cbs,string search,ListView lvs)
        {
            bool Searchy;
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(GetCon()))
                {
                    con.Open();
                    com = new SqlCeCommand("Select * From tblDTruck WHERE Type = '" + search + "' ORDER BY BNum ASC", con);
                    da = new SqlCeDataAdapter(com);
                    dt = new DataTable();
                    da.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(dt.Rows[i]["BNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["PNum"].ToString());
                        item.SubItems.Add(dt.Rows[i]["Type"].ToString());
                        item.SubItems.Add(dt.Rows[i]["BGar"].ToString());
                        lvs.Items.Add(item);
                    }
                    con.Close();
                }
                Searchy = true;
            }
            catch (Exception ex)
            {
                Searchy = false;
                Console.WriteLine(ex.Message);
            }
            return Searchy;
        }
    }
}




