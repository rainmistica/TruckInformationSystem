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
    public partial class frmDriverHistory : Form
    {
        classDriver Manage;
        public int bnum;
        public frmDriverHistory(int bnam, string plate)
        {
            InitializeComponent();
            bnum = bnam;
            lblBN.Text = bnum.ToString();
            lblPN.Text = plate;
        }
        private void frmDriverHistory_Load(object sender, EventArgs e)
        {
            fillDriver();
        }
        private void fillDriver()
        {
            Manage = new classDriver();
            listView1.Items.Clear();
            if(Manage.fillDriverHistory(listView1,bnum))
            {}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (btnRemove.Text == "Modify")
            {
                btnRemove.Text = "Delete";
                listView1.CheckBoxes = true;
            }
            else if (btnRemove.Text == "Delete")
            {
                Manage = new classDriver();
                if (Manage.DeleteDriverHistory(listView1))
                {
                    MessageBox.Show("History Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                fillDriver();
                btnRemove.Text = "Modify";
                listView1.CheckBoxes = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
