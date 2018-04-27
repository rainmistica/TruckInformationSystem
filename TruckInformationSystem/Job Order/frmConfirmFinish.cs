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
    public partial class frmConfirmFinish : Form
    {
        classSaveFinish Manage;
        public frmConfirmFinish(string date,int bn,string pn,string descrip,string mech,string id)
        {
            InitializeComponent();
            lblBN.Text = bn.ToString();
            lblPN.Text = pn;
            lblID.Text = id;
            lblSDate.Text = date;
            lblDesc.Text = descrip;
            lblMech.Text = mech;
        }   
        private void Clear()
        {
            txtParts.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtShop.Text = string.Empty;
            txtOR.Text = string.Empty;
        }
        private void addPrice()
        {
            decimal asd=0;
            foreach(ListViewItem item in listView1.Items)
            {
                    asd += Convert.ToDecimal(item.SubItems[1].Text);
                                 
            }
            lblTot.Text = asd.ToString();
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtParts.Text != string.Empty
                && txtPrice.Text != string.Empty
                && txtShop.Text != string.Empty
                && txtOR.Text != string.Empty)
            {
                ListViewItem AddItem = listView1.Items.Add(txtParts.Text);
                AddItem.SubItems.Add(txtPrice.Text);
                AddItem.SubItems.Add(txtShop.Text);
                AddItem.SubItems.Add(txtOR.Text);
                addPrice();
            }
            else
            {
                MessageBox.Show("Please Complete Details!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            if (listView1.Items.Count != 0)
            {
                btnSave.Visible = true;
                btnRemove.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
                btnSave.Visible = false;
            }
            Clear();
           
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                listView1.Items[listView1.Items.Count - 1].Remove();
                btnRemove.Enabled = true;
                btnSave.Visible = true;
            }
            else
            { }
            if(listView1.Items.Count<1)
            {
                btnRemove.Enabled = false;
                btnSave.Visible = false;
            }
            addPrice();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Manage = new classSaveFinish();
            DialogResult Diag = new DialogResult();
            if (listView1.Items.Count != 0)
            {
                Diag = MessageBox.Show("Do you want to Save? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Diag == DialogResult.Yes)
                {
                    if (Manage.AddFinishOrder(int.Parse(lblBN.Text), lblPN.Text, lblSDate.Text, lblDesc.Text, lblMech.Text, dtFDate.Text) && Manage.DeleteJobOrder(int.Parse(lblID.Text)))
                    {
                        MessageBox.Show("Save!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    foreach (ListViewItem item in listView1.Items)
                    {
                        if (Manage.AddTruckFile(int.Parse(lblBN.Text), lblPN.Text, lblSDate.Text, lblDesc.Text, item.SubItems[0].Text, decimal.Parse(item.SubItems[1].Text), item.SubItems[2].Text, item.SubItems[3].Text, lblMech.Text, dtFDate.Text))
                        { }
                    }
                }
                else if (Diag == DialogResult.No)
                {
                    listView1.Items.Clear();
                    Clear();
                }
            }
            else
            {
                MessageBox.Show("Please Add Details!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
