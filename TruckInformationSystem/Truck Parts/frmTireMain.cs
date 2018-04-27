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
    public partial class frmTireMain : Form
    {
        classTire Manage;
        public int bnum;
        public frmTireMain(int bnam,string passDriv,string plate)
        {
            InitializeComponent();
            bnum = bnam;
            lblDriver.Text = passDriv;
            cbPN.Text = plate;
            lblBN.Text = bnum.ToString();
        }
        private void btnHist_Click(object sender, EventArgs e)
        {
                Height = 505;
                Width = 683;
                gbMod.Enabled = false;
                FillOTire();
        }

        private void frmTireMain_Load(object sender, EventArgs e)
        {
            FillNTire();
            Height = 364; Width = 344;
        }
        private void FillNTire()
        {
            Manage = new classTire();
            listView1.Items.Clear();
            if (Manage.FillCurrentTire(listView1,bnum))
            { lblTot.Text = listView1.Items.Count.ToString(); }
            
        }
        private void FillOTire()
        {
            Manage = new classTire();
            listView2.Items.Clear();
            if (Manage.FillOldTire(listView2, bnum))
            {}
        }
        private void ClearInfo()
        {
            txtBrand.Text = string.Empty;
            txtSerial.Text = string.Empty;
            txtComp.Text = string.Empty;
            txtRemark.Text = string.Empty;
        }

        private void btnRep_Click(object sender, EventArgs e)
        {
            if (btnRep.Text == "Replace Tires")
            {
                listView1.Items.Clear();
                Height = 505; Width=344;
                btnRep.Text ="Save";
                btnMod.Text = "Cancel";
                btnMod.Enabled = true;
                btnHist.Enabled = false;
            }
            else if (btnRep.Text == "Save")
            {
                Manage = new classTire();

                if (listView1.Items.Count == 0)
                {}
                else if (listView1.Items.Count != 0)
                {
                    if (Manage.DeleteCurrentTire(int.Parse(lblBN.Text)) && 
                       (Manage.AddCurrentTire(listView1, lblBN.Text, lblDriver.Text) &&
                       (Manage.AddOldTire(listView1, lblBN.Text, lblDriver.Text))))
                    {

                        MessageBox.Show("Data Saved");
                    }
                }
                btnRep.Enabled = true;
                Height = 364; Width = 344;
                btnRep.Text = "Replace Tires";
                btnMod.Enabled = false;
                btnHist.Enabled = true;
                //btnHist_Click(new object(),new EventArgs());
                FillNTire();
            }
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
                FillNTire();
                btnRep.Enabled = true;
                Height = 364; Width = 344;
                btnRep.Text = "Replace Tires";
                btnMod.Enabled = false;
                btnHist.Enabled = true;
                ClearInfo();     
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text!= string.Empty
                && txtSerial.Text != string.Empty
                && txtComp.Text != string.Empty
                && txtSerial.Text != string.Empty)
            {
                ListViewItem AddItem = listView1.Items.Add(txtBrand.Text);
                AddItem.SubItems.Add(txtSerial.Text);
                AddItem.SubItems.Add(txtComp.Text);
                AddItem.SubItems.Add(txtDI.Text);
                AddItem.SubItems.Add(txtRemark.Text);
                ClearInfo();
                lblTot.Text = listView1.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("Please Complete Details!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                listView1.Items[listView1.Items.Count - 1].Remove();
                lblTot.Text = listView1.Items.Count.ToString();
            }
            else
            { }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Height = 364;
            Width = 344;
            gbMod.Enabled = true;
            listView2.CheckBoxes = false;
        }

        private void btnRemoveHis_Click(object sender, EventArgs e)
        {
            Manage= new classTire();
            if (listView2.CheckBoxes == true && listView2.CheckedItems.Count!=0)
            {
                if (Manage.DeleteAllOldTire(listView2, int.Parse(lblBN.Text)))
                {
                    MessageBox.Show("Data Deleted!");
                }
                FillOTire();

            }
            else if (listView2.CheckBoxes == false)
            {
                listView2.CheckBoxes = true;
            }
        }
    }
}
