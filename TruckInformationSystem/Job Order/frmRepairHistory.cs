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
    public partial class frmRepairHistory : Form
    {
        classViewRepair Manage;
        public frmRepairHistory()
        {
            InitializeComponent();
        }

        private void frmRepairHistory_Load(object sender, EventArgs e)
        {
            FillList();
        }
        private void FillList()
        {
            Manage = new classViewRepair();
            Manage.fillData(listView1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnExit.Text == "Cancel")
            {
                DialogResult Diag = new DialogResult();
                Diag = MessageBox.Show("Do you want to Cancel? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Diag == DialogResult.Yes)
                {
                    listView1.CheckBoxes = false;
                    btnDelete.Text = "Confirm";
                    btnExit.Text = "Exit";

                }
                else if (Diag == DialogResult.No)
                { }
                
            }
            else if (btnExit.Text == "Exit")
            {
                this.Close();

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnDelete.Text == "Remove")
            {
                listView1.CheckBoxes = true;
                btnDelete.Text = "Confirm";
                btnExit.Text = "Cancel";
            }
            else if (btnDelete.Text == "Confirm")
            {
                DialogResult Diag = new DialogResult();
                Manage = new classViewRepair();
                if (listView1.CheckedItems.Count != 0)
                {
                    Diag = MessageBox.Show("Do you want to delete Selected item? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (Diag == DialogResult.Yes)
                    {
                        if (Manage.delHistory(listView1))
                        {
                            MessageBox.Show("Success!", "");
                        }
                    }
                    else if (Diag == DialogResult.No)
                    { }
                }
                else
                {
                    MessageBox.Show("Please choose item!");
                }
                FillList();
                listView1.CheckBoxes = false;
                btnDelete.Text = "Remove";
                btnExit.Text = "Exit";
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Manage = new classViewRepair();
            listView1.Items.Clear();
            if (Manage.SearchParam(listView1, dtSDate, dtFDate))
            { }
        }
    }
}
