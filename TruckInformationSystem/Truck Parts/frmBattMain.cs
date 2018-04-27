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
    public partial class frmBattMain : Form
    {
        classBattery Manage;
        public int bnum;
        public frmBattMain(int bnam,string passDriv,string plate)
        {
            InitializeComponent();
            bnum = bnam;
            lblBN.Text = bnum.ToString();
            lblDriver.Text = passDriv;
            cbPN.Text = plate;
        }
        private void frmBattMain_Load(object sender, EventArgs e)
        {
            FillCBatt();
            Width = 420;
            Height = 274;
        }
        private void FillCBatt()
        {
            listView1.Items.Clear();
            Manage = new classBattery();
            if (Manage.FillCurrentBatt(listView1, int.Parse(lblBN.Text)))
            { }
        }
        private void FillOBatt()
        {
            listView2.Items.Clear();
            Manage = new classBattery();
            if (Manage.FillOldBatt(listView2, int.Parse(lblBN.Text)))
            { }
        }
        private void _OnControl()
        {
            listView1.Items.Clear();
            txtBrand.Enabled = true;
            txtSerial.Enabled = true;
            txtType.Enabled = true;
            dtpDate.Enabled = true;
            txtRemark.Enabled = true;
            btnCnl.Enabled = true;
            btnHist.Enabled = false;
            btnAddTop.Visible = true;
            btnRemoveTop.Visible = true;
        }
        private void _OffControl()
        {
            btnAdd.Text = "Replace Battery";
            btnCnl.Enabled = false;
            btnHist.Enabled = true;
            listView1.Enabled = true;
            txtBrand.Enabled = false;
            txtSerial.Enabled = false;
            txtType.Enabled = false;
            txtRemark.Enabled = false;
            dtpDate.Enabled = false;
            btnAddTop.Visible = false;
            btnRemoveTop.Visible = false;
        }
        private void ClrInfo()
        {
            txtBrand.Text = string.Empty;
            txtSerial.Text = string.Empty;
            txtType.Text = string.Empty;
            txtSerial.Text = string.Empty;
            txtRemark.Text = string.Empty;
        }
        private void btnHist_Click(object sender, EventArgs e)
        {
            if (btnHist.Text == "View History")
            {
                btnAdd.Enabled = false;
                listView1.Enabled = false;
                btnCnl.Enabled = false;
                listView2.CheckBoxes = false;
                Width = 420;
                Height = 547;
                btnHist.Text = "Hide History";
                FillOBatt();
            }
            else if (btnHist.Text == "Hide History")
            {
                btnAdd.Enabled = true;
                listView1.Enabled = true;
                Width = 420;
                Height = 274;
                btnHist.Text = "View History";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Replace Battery")
            {
                _OnControl();
                btnAdd.Text = "Save";
            }
            else if (btnAdd.Text == "Save")
            {
                Manage = new classBattery();
                if (listView1.Items.Count == 0)
                { }
                else if (listView1.Items.Count != 0)
                {
                    if  (Manage.DeleteCurrentBatt(int.Parse(lblBN.Text)) &&
                        (Manage.AddCurrentBatt(listView1,lblBN.Text,lblDriver.Text)&&
                        (Manage.AddOldBatt(listView1,lblBN.Text,lblDriver.Text))))
                    {

                        MessageBox.Show("Data Saved");
                    }
                }
                _OffControl();
                FillCBatt();
            }
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
            _OffControl();
            FillCBatt();
        }

        private void btnAddTop_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text != string.Empty
                && txtSerial.Text != string.Empty
                && txtType.Text != string.Empty
                && txtSerial.Text != string.Empty
                && listView1.Items.Count < 2)
            {
                ListViewItem AddItem = listView1.Items.Add(txtBrand.Text);
                AddItem.SubItems.Add(txtSerial.Text);
                AddItem.SubItems.Add(txtType.Text);
                AddItem.SubItems.Add(dtpDate.Text);
                AddItem.SubItems.Add(txtRemark.Text);
                ClrInfo();
            }
            else
            {
                MessageBox.Show("Please Complete Details!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemoveTop_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                listView1.Items[listView1.Items.Count - 1].Remove();
            }
            else
            { }
        }

        private void btnDelHist_Click(object sender, EventArgs e)
        {
            Manage = new classBattery();
            if (listView2.CheckBoxes == true && listView2.CheckedItems.Count != 0)
            {
                if (Manage.DeleteOldBatt(listView2, int.Parse(lblBN.Text)))
                {
                    MessageBox.Show("Data Deleted!");
                }
                FillCBatt();
                FillOBatt();

            }
            else if (listView2.CheckBoxes == false)
            {
                listView2.CheckBoxes = true;
            }
        }
    }
}
