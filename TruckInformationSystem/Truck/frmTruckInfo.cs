using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
namespace TruckInformationSystem
{
    public partial class frmTruckInfo : Form
    {
        classTruckInfo Manage;
        int chk;
        public int edNum;
        public frmTruckInfo()
        {
            InitializeComponent();
        }
        private void frmTruckInfo_Load(object sender, EventArgs e)
        {
            FillList();
        }
        private void FillList()
        {
            listView1.Items.Clear();
            Manage = new classTruckInfo();      
            if (Manage.FillData(listView1))
            {}
            lblCount.Text = listView1.Items.Count.ToString();                        
        }
        private void ComboSearch()
        {
            listView1.Items.Clear();
            Manage = new classTruckInfo();
            if (cbSearch.SelectedIndex == 0)
            {
                FillList();
            }
            else
            {
                if (Manage.ComboSearch(cbSearch, cbSearch.Text, listView1))
                { }
                
                lblCount.Text = listView1.Items.Count.ToString();
            }    
    
        }
        private void Clear()
        {
            txtBN.Text = string.Empty; txtPN.Text = string.Empty; cbType.Text = string.Empty; cbGar.Text = string.Empty;
            txtBN.Enabled = false; txtPN.Enabled = false; cbType.Enabled = false; cbGar.Enabled = false;            
        }
        private void delRes()
        {
            Clear();
            FillList();
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnDel.Enabled = false;
            btnExit.Text = "Exit";
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtBN.Text = item.SubItems[0].Text;
                edNum = Convert.ToInt32(item.SubItems[0].Text);
                txtPN.Text = item.SubItems[1].Text;
                cbType.Text = item.SubItems[2].Text;
                cbGar.Text = item.SubItems[3].Text;
                btnEdit.Enabled = true;
                btnAdd.Enabled = false;
                btnDel.Enabled = true;
                btnUp.Enabled = false;
                btnExit.Text = "Cancel";
            }
            else
            {
                txtBN.Text = string.Empty;
                txtPN.Text = string.Empty;
                cbType.Text = string.Empty;
                cbGar.Text = string.Empty;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            chk = 1;
            txtBN.Enabled = true;
            btnAdd.Enabled = false;
            txtPN.Enabled = true;
            cbType.Enabled = true;
            cbGar.Enabled = true;
            btnUp.Enabled = true;
            listView1.Enabled = false;
            btnExit.Text = "Cancel";
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnExit.Text == "Cancel")
            {
                DialogResult Diag = new DialogResult();
                Diag = MessageBox.Show("Do you want to Cancel? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Diag == DialogResult.Yes)
                {
                    btnAdd.Enabled = true;
                    btnEdit.Enabled = false;
                    btnUp.Enabled = false;
                    btnDel.Enabled = false;
                    btnExit.Text = "Exit";
                    listView1.Enabled = true;
                    Clear();
                 }
                else if (Diag == DialogResult.No)
                {
                }
            }
            else if (btnExit.Text == "Exit")
            {
                this.Close();

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            chk = 2;
            txtBN.Enabled = true;
            txtPN.Enabled = true;
            cbType.Enabled = true;
            cbGar.Enabled = true;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnUp.Enabled = true;
            btnDel.Enabled = false;
            listView1.Enabled = false;
            btnExit.Text = "Cancel";
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            Manage = new classTruckInfo();
            if (txtBN.Text != string.Empty
                && txtPN.Text != string.Empty
                && cbType.Text != string.Empty
                && cbGar.Text != string.Empty)
            {
                if (chk == 1)
                {
                    if (Manage.InsertData(int.Parse(txtBN.Text), txtPN.Text, cbType.Text, cbGar.Text) && Manage.AddOil(int.Parse(txtBN.Text)) && Manage.AddTool(int.Parse(txtBN.Text)))
                    {
                        MessageBox.Show("Data Inserted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (chk == 2)
                {
                    if (Manage.EditData(int.Parse(txtBN.Text), txtPN.Text, cbType.Text, cbGar.Text, edNum) && Manage.EditOil(int.Parse(txtBN.Text), edNum) && Manage.EditTool(int.Parse(txtBN.Text), edNum))
                    {
                        MessageBox.Show("Data Edited!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                chk = 0;
                MessageBox.Show("Please Complete Data!", "Error");
            }
            listView1.Enabled = true;
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnUp.Enabled = false;
            btnDel.Enabled = false;
            btnExit.Text = "Exit";
            chk = 0;
            Clear();
            FillList();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Manage = new classTruckInfo();
            DialogResult Diag = new DialogResult();
            Diag = MessageBox.Show("Do you want to Remove this data?", "Confirmation", MessageBoxButtons.YesNo);

            if (Diag == DialogResult.Yes)
            {
                if (txtBN.Text != string.Empty)
                {
                    if (Manage.RemoveData(int.Parse(txtBN.Text)) && Manage.DelOil(int.Parse(txtBN.Text)) && Manage.DelTool(int.Parse(txtBN.Text)))
                    { }
                }
                delRes();
            }
            else if (Diag == DialogResult.No)
            {
                delRes();
            }     
        }
        private void txtBN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboSearch();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            frmTruckProf sum = new frmTruckProf(edNum);
            sum.ShowDialog();
        }
    }
}
