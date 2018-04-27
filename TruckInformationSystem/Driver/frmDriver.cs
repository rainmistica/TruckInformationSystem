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
    public partial class frmDriver : Form
    {
        classDriver Manage;
        int chk;
        public frmDriver()
        {
            InitializeComponent();
        }
        private void frmDriver_Load(object sender, EventArgs e)
        {
            _fillDriver();
        }
        private void _fillDriver()
        {
            Manage = new classDriver();
            listView1.Items.Clear();
            if (Manage.fillDriverList(listView1))
            {
                lblCount.Text = listView1.Items.Count.ToString();
            }
        }
        private void Reset()
        {
            listView1.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUp.Enabled = false;
            btnDel.Enabled = false;
            btnExt.Text = "Exit";
            lblID.Text = string.Empty;
            txtFN.Text = string.Empty;
            txtFN.Enabled = false;
            chk = 0;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                lblID.Text = item.SubItems[0].Text;
                txtFN.Text = item.SubItems[1].Text;
                btnEdit.Enabled = true;
                btnAdd.Enabled = false;
                btnDel.Enabled = true;
                btnUp.Enabled = false;
                btnExt.Text = "Cancel";

            }
            else
            {
                lblID.Text = string.Empty;
                txtFN.Text = string.Empty;

            }
        }

        private void btnExt_Click(object sender, EventArgs e)
        {
            if (btnExt.Text == "Cancel")
            {
                DialogResult Diag = new DialogResult();
                Diag = MessageBox.Show("Do you want to Cancel? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Diag == DialogResult.Yes)
                {
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnUp.Enabled = false;
                    btnDel.Enabled = false;
                    btnExt.Text = "Exit";
                    listView1.Enabled = true;
                    txtFN.Text = string.Empty;
                    txtFN.Enabled = false;

                }
                else if (Diag == DialogResult.No)
                {
                }
            }
            else if (btnExt.Text == "Exit")
            {
                this.Close();

            }
        }

        private void txtFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            chk = 1;
            txtFN.Enabled = true;
            btnAdd.Enabled = false;
            btnUp.Enabled = true;
            listView1.Enabled = false;
            btnExt.Text = "Cancel";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            chk = 2;
            txtFN.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnUp.Enabled = true;
            btnDel.Enabled = false;
            listView1.Enabled = false;
            btnExt.Text = "Cancel";
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int TL = txtFN.Text.Length;
            if (String.IsNullOrEmpty(txtFN.Text) || TL < 6)
            {
                MessageBox.Show("Please Complete Details!");
                chk = 0;
            }
            if (chk == 1)
            {
                Manage = new classDriver();
                if (Manage.AddDriver(txtFN.Text))
                {
                    MessageBox.Show("Data Inserted!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (chk == 2)
            {
                Manage = new classDriver();
                if (Manage.EditDriver(int.Parse(lblID.Text),txtFN.Text))
                {
                    MessageBox.Show("Data Edited!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Reset();
            _fillDriver();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Manage = new classDriver();
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to remove this data?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                if (Manage.DeleteDriver(int.Parse(lblID.Text)))
                { }
            }
            else if (Diag == DialogResult.No)
            { }
            Reset();
            _fillDriver();
        }
    }
}
