namespace TruckInformationSystem
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfTrucksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfDriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truckRepairsReplacementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingJobOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishedJobOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.truckHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(886, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMaintenanceToolStripMenuItem,
            this.truckRepairsReplacementToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(886, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMaintenanceToolStripMenuItem
            // 
            this.fileMaintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfTrucksToolStripMenuItem,
            this.listOfDriversToolStripMenuItem});
            this.fileMaintenanceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileMaintenanceToolStripMenuItem.Name = "fileMaintenanceToolStripMenuItem";
            this.fileMaintenanceToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.fileMaintenanceToolStripMenuItem.Text = "File Maintenance";
            // 
            // listOfTrucksToolStripMenuItem
            // 
            this.listOfTrucksToolStripMenuItem.Name = "listOfTrucksToolStripMenuItem";
            this.listOfTrucksToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.listOfTrucksToolStripMenuItem.Text = "List of Trucks";
            this.listOfTrucksToolStripMenuItem.Click += new System.EventHandler(this.listOfTrucksToolStripMenuItem_Click);
            // 
            // listOfDriversToolStripMenuItem
            // 
            this.listOfDriversToolStripMenuItem.Name = "listOfDriversToolStripMenuItem";
            this.listOfDriversToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.listOfDriversToolStripMenuItem.Text = "List of Drivers";
            this.listOfDriversToolStripMenuItem.Click += new System.EventHandler(this.listOfDriversToolStripMenuItem_Click);
            // 
            // truckRepairsReplacementToolStripMenuItem
            // 
            this.truckRepairsReplacementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendingJobOrderToolStripMenuItem,
            this.finishedJobOrderToolStripMenuItem,
            this.truckHistoryToolStripMenuItem});
            this.truckRepairsReplacementToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truckRepairsReplacementToolStripMenuItem.Name = "truckRepairsReplacementToolStripMenuItem";
            this.truckRepairsReplacementToolStripMenuItem.Size = new System.Drawing.Size(238, 24);
            this.truckRepairsReplacementToolStripMenuItem.Text = "Truck Repair and  Replacement";
            // 
            // pendingJobOrderToolStripMenuItem
            // 
            this.pendingJobOrderToolStripMenuItem.Name = "pendingJobOrderToolStripMenuItem";
            this.pendingJobOrderToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.pendingJobOrderToolStripMenuItem.Text = "Pending Job Order";
            this.pendingJobOrderToolStripMenuItem.Click += new System.EventHandler(this.pendingJobOrderToolStripMenuItem_Click);
            // 
            // finishedJobOrderToolStripMenuItem
            // 
            this.finishedJobOrderToolStripMenuItem.Name = "finishedJobOrderToolStripMenuItem";
            this.finishedJobOrderToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.finishedJobOrderToolStripMenuItem.Text = "Finished Job Order";
            this.finishedJobOrderToolStripMenuItem.Click += new System.EventHandler(this.finishedJobOrderToolStripMenuItem_Click);
            // 
            // truckHistoryToolStripMenuItem
            // 
            this.truckHistoryToolStripMenuItem.Name = "truckHistoryToolStripMenuItem";
            this.truckHistoryToolStripMenuItem.Size = new System.Drawing.Size(221, 24);
            this.truckHistoryToolStripMenuItem.Text = "Truck Repair History";
            this.truckHistoryToolStripMenuItem.Click += new System.EventHandler(this.truckHistoryToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem});
            this.settingsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TruckInformationSystem.Properties.Resources.truck_profile;
            this.pictureBox2.Location = new System.Drawing.Point(521, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(433, 336);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TruckInformationSystem.Properties.Resources.wrench_md;
            this.pictureBox1.Location = new System.Drawing.Point(252, 283);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 292);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 31);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(234, 492);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "BodyNumber";
            this.columnHeader1.Width = 105;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Change Oil Date";
            this.columnHeader3.Width = 150;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(886, 548);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Truck Information System";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfTrucksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfDriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem truckRepairsReplacementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingJobOrderToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem truckHistoryToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem finishedJobOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}