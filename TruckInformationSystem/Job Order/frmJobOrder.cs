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
    public partial class frmJobOrder : Form
    {
        classJobOrder Manage;
        int chk;
        public frmJobOrder()
        {
            InitializeComponent();
        }

        private void frmJobOrder_Load(object sender, EventArgs e)
        {
            FillData();
            FillBod();
        }
        private void FillData()
        {
            Manage = new classJobOrder();
            Manage.FillJO(listView1);
            Manage.FillBody(txtBN);
            lblTot.Text = listView1.Items.Count.ToString();
        }
        private void FillBod()
        {
            Manage = new classJobOrder();
            if (Manage.FillBody(txtBN))
            { }
        }
        private void _Set()
        {
            btnExit.Text = "Cancel";
            dtDS.Enabled=true;
            txtBN.Enabled = true;
            txtDesc.Enabled = true;
            txtMech.Enabled = true;
            listView1.Enabled = false;
        }
        private void _Reset()
        {
            txtBN.Text = string.Empty;
            txtDesc.Text = string.Empty;
            txtMech.Text = string.Empty;
            lblID.Text = string.Empty;
            lblDays.Text = string.Empty;
            btnExit.Text = "Exit";
            dtDS.Enabled = false;
            txtBN.Enabled = false;
            txtDesc.Enabled = false;
            txtMech.Enabled = false;
            listView1.Enabled = true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Manage = new classJobOrder();
            if (btnSave.Text == "Add")
            {
                _Set();
                chk = 1;
                btnSave.Text = "Save";
            }
            else if(btnSave.Text=="Save")
            {
               if (txtBN.Text != string.Empty
                  && txtDesc.Text != string.Empty
                  && txtMech.Text != string.Empty
                  && lblPN.Text != string.Empty)
               {
                   if (chk == 1)
                   {
                       if (Manage.AddJO(dtDS.Text, txtBN.Text, lblPN.Text, txtDesc.Text, txtMech.Text))
                       {
                           MessageBox.Show("Data Added!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                   }
                   else if (chk == 2)
                   {
                       if (Manage.EditJO(int.Parse(lblID.Text),dtDS.Text,txtBN.Text,lblPN.Text,txtDesc.Text,txtMech.Text))
                       {
                           MessageBox.Show("Data Edited!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       }
                   }
               }
               else
               {
                   MessageBox.Show("Please complete details!");
                   chk = 0;
               }
               _Reset();
               FillData();
               btnSave.Text = "Add";
            }
            else if (btnSave.Text == "Edit")
            {
                _Set();
                chk = 2;
                btnDone.Visible = false;
                btnSave.Text = "Save";
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnExit.Text == "Cancel")
            {
                DialogResult Diag = new DialogResult();
                Diag = MessageBox.Show("Do you want to Cancel? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Diag == DialogResult.Yes)
                {
                    _Reset();
                    btnSave.Text = "Add";
                    btnDone.Visible = false;
                }
                else if (Diag == DialogResult.No)
                { }
                
            }
            else if (btnExit.Text == "Exit")
            {
                this.Close();

            }
        }
        private void txtBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                lblID.Text = item.SubItems[0].Text;
                dtDS.Text = item.SubItems[1].Text;
                txtBN.Text = item.SubItems[2].Text;
                lblPN.Text = item.SubItems[3].Text;
                txtDesc.Text = item.SubItems[4].Text;
                txtMech.Text = item.SubItems[5].Text;
                lblDays.Text = item.SubItems[6].Text;
                btnSave.Text = "Edit";
                btnExit.Text = "Cancel";
                btnDone.Visible = true;
            }
            else
            {
                btnDone.Visible = false;
                txtBN.Text = string.Empty;
                lblPN.Text = string.Empty;
                txtDesc.Text = string.Empty;
                txtMech.Text = string.Empty;
                lblID.Text = string.Empty;
                lblDays.Text = string.Empty;
                btnSave.Text = "Add";
                btnExit.Text = "Exit";
                
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Delete this Data? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Diag == DialogResult.Yes)
            {
                if(Manage.DeleteJO(int.Parse(lblID.Text)))
                {}
                btnDone.Visible = false;
            }
            else if (Diag == DialogResult.No)
            { }
            _Reset();
            FillData();
            btnSave.Text = "Add";
            btnExit.Text = "Exit";
            btnDone.Visible = false;
        }

        private void txtBN_Leave(object sender, EventArgs e)
        {
            Manage = new classJobOrder();
            if (Manage.FillPlateNum(txtBN, lblPN))
            { }
        }
        private void btnDone_Click(object sender, EventArgs e)
        {
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Finished Repair? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (Diag == DialogResult.Yes)
            {
                frmConfirmFinish open = new frmConfirmFinish(dtDS.Text, int.Parse(txtBN.Text), lblPN.Text, txtDesc.Text, txtMech.Text,lblID.Text);
                open.ShowDialog();
            }
            else if (Diag == DialogResult.No)
            {
                _Reset();
                FillData();
                btnSave.Text = "Add";
                btnExit.Text = "Exit";
                btnDone.Visible = false;
            }
           
        }
    }
}
