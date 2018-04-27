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
    public partial class frmTruckIndiv : Form
    {
        classTruckIndiv Manage;
        public frmTruckIndiv()
        {
            InitializeComponent();
        }

        private void frmTruckIndiv_Load(object sender, EventArgs e)
        {
            FillBodyN();
        }
        private void FillBodyN()
        {
            Manage = new classTruckIndiv();
            if (Manage.FillBody(txtBN))
            {
            }
        }
        private void CountDays()
        {
            DateTime s, d;
            s = Convert.ToDateTime(cbSDate.Text);
            d = Convert.ToDateTime(lblFDate.Text);
            TimeSpan dp = d.Subtract(s);
            lblDuration.Text = dp.Days.ToString() + " Days";
        }
        private void TotalExpense()
        {
            decimal asd = 0;
            foreach (ListViewItem item in listView1.Items)
            {
                asd += Convert.ToDecimal(item.SubItems[1].Text);

            }
            lblExpense.Text = asd.ToString();
        }
        private void ClrInfo()
        {
            lblPN.Text = string.Empty;
            lblMech.Text = string.Empty;
            lblJO.Text = string.Empty;
            lblFDate.Text =  string.Empty;
            lblExpense.Text = string.Empty;
            lblDuration.Text = string.Empty;
        }

        private void txtBN_Leave(object sender, EventArgs e)
        {
            cbSDate.Items.Clear();
            Manage = new classTruckIndiv();
            if (Manage.FillPlateNum(txtBN,lblPN) && Manage.FillComboSDate(cbSDate,txtBN))
            { }
        }

        private void cbSDate_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            listView1.Items.Clear();
            ClrInfo();
            Manage = new classTruckIndiv();
            if (Manage.FillSpecData(listView1, cbSDate, txtBN, lblJO, lblMech, lblFDate))
            {
                CountDays();
                TotalExpense();
            }
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ClrInfo();
            listView1.Items.Clear();
            Manage = new classTruckIndiv();
            if (Manage.FillGenInfo(listView1, txtBN))
            { TotalExpense(); }
        }
    }
}
