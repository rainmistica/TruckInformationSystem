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
    public partial class frmOilHist : Form
    {
        ClassTruckProf Manage;
        public int bnum;
        public frmOilHist(int bnam,string plate)
        {
            InitializeComponent();
            bnum = bnam;
            txtPN.Text = plate;
        }

        private void frmOilHist_Load(object sender, EventArgs e)
        {
            FillData();
        }
        private void FillData()
        {
            Manage = new ClassTruckProf();
            listView1.Items.Clear();
            if (Manage.FillCOH(listView1,bnum))
            { }
            
            lblBN.Text = bnum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage = new ClassTruckProf();
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Remove this data?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                if (lblBN.Text != string.Empty)
                {
                    if (Manage.DeleteOilDate(bnum, listView1.SelectedItems[0].Text))
                    { }
                    else
                    { }
                }
            }
            else if (Diag == DialogResult.No)
            { }
            FillData();
            button1.Enabled = false;
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
