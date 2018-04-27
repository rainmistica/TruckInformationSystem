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
    public partial class frmTruckProf : Form
    {
        ClassTruckProf Manage;
        classTools Fill;
        classDriver fillDriv;
        public int SavNum;
        public string passDriver,plateNumber;
        public frmTruckProf(int PassNum)
        {
            InitializeComponent();
            SavNum = PassNum;
        }

        private void frmTruckProf_Load(object sender, EventArgs e)
        {
            FillCO();
            FillProf();
            FillTires();
            FillBatts();
            fillTools();
            fillDriver();
        }
        SqlCeCommand com;
        SqlCeDataAdapter da;
        DataTable dt; 
        private void FillProf()
        {
            Manage = new ClassTruckProf();
            using (SqlCeConnection con = new SqlCeConnection(Manage.GetCon()))
            {

                con.Open();
                com = new SqlCeCommand("Select * FROM tblDTruck WHERE BNum = '" + SavNum + "'", con);
                da = new SqlCeDataAdapter(com);
                dt = new DataTable();
                try
                {
                    da.Fill(dt);
                    lblBNum.Text = dt.Rows[0]["BNum"].ToString();
                    txtPN.Text = dt.Rows[0]["PNum"].ToString();
                    txtDriver.Text = dt.Rows[0]["Driver"].ToString();
                    txtRF.Text = dt.Rows[0]["RFNum"].ToString();
                    txtEN.Text = dt.Rows[0]["EngNum"].ToString();
                    txtCN.Text = dt.Rows[0]["ChasNum"].ToString();
                    txtORCR.Text = dt.Rows[0]["ORCR"].ToString();
                    dtpST.Text = dt.Rows[0]["STest"].ToString();
                    txtInsur.Text = dt.Rows[0]["Insur"].ToString();
                    txtCasNum.Text = dt.Rows[0]["CaseNum"].ToString();
                    txtApp.Text = dt.Rows[0]["Application"].ToString();
                    txtMotion.Text = dt.Rows[0]["Motion"].ToString();
                    txtPA.Text = dt.Rows[0]["ProbAuth"].ToString();
                    con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            passDriver = txtDriver.Text;
        }
        private void ResEd()
        {
            gbBI.Enabled = false;
            gbLD.Enabled = false;
            gbLT.Enabled = false;
            btnCnl.Enabled = false;
            btnEdit.Text = "Modify";
        }
        private void FillCO()
        {
            Manage = new ClassTruckProf();
            if (Manage.FillCO(lblLD, lblND, SavNum))
            {}
        }
        private void FillTires()
        {
            LVTires.Items.Clear();
            Manage = new ClassTruckProf();
            if (Manage.FillCurrentTire(LVTires,SavNum))
            { }

        }
        private void FillBatts()
        {
            LVBatt.Items.Clear();
            Manage = new ClassTruckProf();
            if (Manage.FillCurrentBatt(LVBatt, SavNum))
            { }
        }
        private void fillTools()
        {
            Fill = new classTools();
            if (Fill.FillProfData(TC, TW, OP, Jack, EWD, SavNum))
            {}
            if (TC.Text != DateTime.Now.ToShortDateString())
            { cbTC.Checked = true; }
            else { cbTC.Checked = false; }

            if (TW.Text != DateTime.Now.ToShortDateString())
            { cbTW.Checked = true; }
            else { cbTW.Checked = false; }

            if (OP.Text != DateTime.Now.ToShortDateString())
            { cbOP.Checked = true; }
            else { cbOP.Checked = false; }

            if (Jack.Text != DateTime.Now.ToShortDateString())
            { cbJack.Checked = true; }
            else { cbJack.Checked = false; }

            if (EWD.Text != DateTime.Now.ToShortDateString())
            { cbEWD.Checked = true; }
            else { cbEWD.Checked = false; }
        }
        private void fillDriver()
        {
            fillDriv = new classDriver();
            if (fillDriv.fillDriverProf(txtDriver))
            {
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Modify")
            {
                gbBI.Enabled = true;
                gbLD.Enabled = true;
                gbLT.Enabled = true;
                btnCnl.Enabled = true;
                btnEdit.Text = "Save";
            }
            else if (btnEdit.Text == "Save")
            {
                Manage = new ClassTruckProf();
                fillDriv= new classDriver();
                if (Manage.UpdateData(SavNum, txtDriver.Text, txtRF.Text, txtEN.Text, txtCN.Text, txtORCR.Text,
                    dtpST.Text, txtInsur.Text, txtCasNum.Text, txtApp.Text, txtMotion.Text, txtPA.Text) 
                    && (fillDriv.AddDriverHistory(SavNum,txtDriver.Text)) )
                {
                    MessageBox.Show("Data Save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ResEd();

            }
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
             DialogResult Diag = new DialogResult();
                Diag = MessageBox.Show("Do you want to Cancel? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Diag == DialogResult.Yes)
                {
                    ResEd();
                }else if (Diag == DialogResult.No) { }      
        }
        string savehist;
        private void btnCO_Click(object sender, EventArgs e)
        {
            Manage = new ClassTruckProf();
            if (btnCO.Text == "Update")
            {
                lblLD.Enabled = true;
                lblND.Enabled = true;
                btnCOH.Enabled = false;
                btnCO.Text = "Save";
                savehist = lblLD.Text;
            }
            else if (btnCO.Text == "Save")
            {
                if (lblLD.Value >= lblND.Value)
                {
                    MessageBox.Show("Wrong Info!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (lblLD.Value < lblND.Value)
                {
                    if (Manage.EditCO(lblLD.Text, lblND.Text, SavNum) && Manage.AddCH(lblLD.Text,SavNum))
                    {
                        MessageBox.Show("Success!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                FillCO();
                lblLD.Enabled = false;
                lblND.Enabled = false;
                btnCOH.Enabled = true;
                btnCO.Text = "Update";
            }
        }
        private void btnCOH_Click(object sender, EventArgs e)
        {
            plateNumber = txtPN.Text;
            frmOilHist sum = new frmOilHist(SavNum,plateNumber);
            sum.ShowDialog();
        }
        private void btnTire_Click(object sender, EventArgs e)
        {
            passDriver = txtDriver.Text;
            plateNumber = txtPN.Text;
            frmTireMain sum = new frmTireMain(SavNum,passDriver,plateNumber);
            sum.ShowDialog();
        }
        private void btnBatt_Click(object sender, EventArgs e)
        {
            passDriver = txtDriver.Text;
            plateNumber = txtPN.Text;
            frmBattMain sum = new frmBattMain(SavNum,passDriver,plateNumber);
            sum.ShowDialog();
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            FillTires();
            FillBatts();
            fillTools();
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            passDriver = txtDriver.Text;
            plateNumber = txtPN.Text;
            frmTools sum = new frmTools(SavNum, passDriver, plateNumber);
            sum.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            plateNumber = txtPN.Text;
            frmDriverHistory sum = new frmDriverHistory(SavNum, plateNumber);
            sum.ShowDialog();
        }
    }
}
