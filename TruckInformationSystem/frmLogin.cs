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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "Admin" && txtPass.Text == "1234")
            {
                MessageBox.Show("Access Granted!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                var form2 = new frmMain();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Access Denied!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Text = string.Empty;
                txtPass.Text = string.Empty;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
               // MessageBox.Show("Pressed enter.");
                btnLog.PerformClick();
            }    
        }
    }
}
