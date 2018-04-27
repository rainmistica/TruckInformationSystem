using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TruckInformationSystem
{
    public partial class frmMain : Form
    {
        classTruckIndiv Fill;
        public int edNum = 111;
        public frmMain()
        {
            InitializeComponent();
        }
        private void MonitorCOHistory()
        {
            Fill = new classTruckIndiv();
            Fill.ChangeOilMonitoring(listView1);
        }
        private void listOfTrucksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTruckInfo sum = new frmTruckInfo();
            sum.ShowDialog();
        }
        private void listOfDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDriver sum = new frmDriver();
            sum.ShowDialog();
        }

        private void pendingJobOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmJobOrder sum = new frmJobOrder();
            sum.ShowDialog();
        }

        private void finishedJobOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRepairHistory sum = new frmRepairHistory();
            sum.ShowDialog();
        }

        private void truckHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTruckIndiv sum = new frmTruckIndiv();
            sum.ShowDialog();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
            timer1.Enabled = true;
            timer1.Start();
            MonitorCOHistory();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();

            Diag = MessageBox.Show("Do you want to logout?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                this.Hide();
                var form2 = new frmLogin();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else if (Diag == DialogResult.No)
            {
            }     
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBackup sum = new frmBackup();
            sum.ShowDialog();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
        }

    }
}
