using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace TruckInformationSystem
{
    public partial class frmBackup : Form
    {
        int ctr=0;
        public frmBackup()
        {
            InitializeComponent();
        }
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string dbFilePath = System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "TruckDB.sdf");
            string fName = saveFileDialog1.FileName;
            File.Copy(dbFilePath, fName, true);
            saveFileDialog1.Dispose();
            MessageBox.Show("Backup Successful!","Ok",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
                if (txtPass.Text == "1234")
                {
                    saveFileDialog1.Filter = "Backup Files (*.bak)|*.bak";
                    saveFileDialog1.Title = "Save to";
                    saveFileDialog1.FileName = "TruckDB";
                    saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.ShowDialog();
                }
                else
                {
                    txtPass.Text = string.Empty;
                    btnBackup.Visible = false;
                    ctr++;
                    MessageBox.Show("Wrong Password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);    
                }
                if (ctr == 3)
                {
                    ctr = 0;
                    this.Close();
                }
            }
        

        private void txtPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPass.Text))
            {
                btnBackup.Visible = false;
            }
            else
            {
                btnBackup.Visible = true;
            }
        }
    }
}
