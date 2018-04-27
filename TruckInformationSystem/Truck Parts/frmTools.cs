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
    public partial class frmTools : Form
    {
        classTools Manage;
        public int bnum;
        public frmTools(int bnam, string passDriv, string plate)
        {
            InitializeComponent();
            bnum = bnam;
            lblBN.Text = bnum.ToString();
            lblDriver.Text = passDriv;
            cbPN.Text = plate;
        }

        private void frmTools_Load(object sender, EventArgs e)
        {
            fillD();
            CheckCB();
        }
        private void fillD()
        {
            Manage = new classTools();
            if (Manage.FillDatas(txtTC,txtTW,txtOP,txtJack,txtEWD,dtTC,dtTW,dtOP,dtJack,dtEWD,int.Parse(lblBN.Text)))
            { }
        }
        private void CheckCB()
        {
            if (txtTC.Text != string.Empty)
            { cbTC.Checked = true; }
            else{ cbTC.Checked = false;}

            if (txtTW.Text != string.Empty)
            { cbTW.Checked = true; }
            else { cbTW.Checked = false; }

            if (txtOP.Text != string.Empty)
            { cbOP.Checked = true; }
            else { cbOP.Checked = false; }

            if (txtJack.Text != string.Empty)
            { cbJack.Checked = true; }
            else { cbJack.Checked = false; }

            if (txtEWD.Text != string.Empty)
            { cbEWD.Checked = true; }
            else { cbEWD.Checked = false; }

        }
        private void EnBox()
        {
            txtEWD.Enabled = true;
            dtEWD.Enabled = true;
            txtJack.Enabled = true;
            dtJack.Enabled = true;
            txtOP.Enabled = true;
            dtOP.Enabled = true;
            txtTC.Enabled = true;
            dtTC.Enabled = true;
            txtTW.Enabled = true;
            dtTW.Enabled = true;
            btnCnl.Enabled = true;
        }
        private void DisBox()
        {
            txtEWD.Enabled = false;
            dtEWD.Enabled = false;
            txtJack.Enabled = false;
            dtJack.Enabled = false;
            txtOP.Enabled = false;
            dtOP.Enabled = false;
            txtTC.Enabled = false;
            dtTC.Enabled = false;
            txtTW.Enabled = false;
            dtTW.Enabled = false;
            btnCnl.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Manage = new classTools();
            if (btnSave.Text == "Update")
            {
                EnBox();
                btnSave.Text = "Save";
            }
            else if (btnSave.Text == "Save")
            {
                if (txtTC.Text != string.Empty
                    && txtTW.Text != string.Empty
                    && txtOP.Text != string.Empty
                    && txtJack.Text != string.Empty
                    && txtEWD.Text != string.Empty)
                {
                    if (Manage.EditData(txtTC.Text, txtTW.Text, txtOP.Text, txtJack.Text, txtEWD.Text, dtTC.Text, dtTW.Text, dtOP.Text, dtJack.Text, dtEWD.Text, int.Parse(lblBN.Text)))
                    {
                        MessageBox.Show("Save Done!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillD();
                        CheckCB();        
                    }
                }
                else
                {
                    MessageBox.Show("Please Complete Data!","", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                DisBox();
                btnSave.Text = "Update";
            }
        }

        private void btnCnl_Click(object sender, EventArgs e)
        {
            DisBox();
            btnSave.Text = "Update";
        }
    }
}
