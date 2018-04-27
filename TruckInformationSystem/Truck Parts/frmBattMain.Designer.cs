namespace TruckInformationSystem
{
    partial class frmBattMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveTop = new System.Windows.Forms.Button();
            this.btnAddTop = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnHist = new System.Windows.Forms.Button();
            this.btnCnl = new System.Windows.Forms.Button();
            this.cbPN = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblDriver = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelHist = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveTop);
            this.groupBox1.Controls.Add(this.btnAddTop);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtRemark);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.txtBrand);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.btnHist);
            this.groupBox1.Controls.Add(this.btnCnl);
            this.groupBox1.Controls.Add(this.cbPN);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lblDriver);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblBN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Location = new System.Drawing.Point(2, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 244);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modify Data";
            // 
            // btnRemoveTop
            // 
            this.btnRemoveTop.FlatAppearance.BorderSize = 0;
            this.btnRemoveTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTop.Location = new System.Drawing.Point(81, 214);
            this.btnRemoveTop.Name = "btnRemoveTop";
            this.btnRemoveTop.Size = new System.Drawing.Size(67, 22);
            this.btnRemoveTop.TabIndex = 35;
            this.btnRemoveTop.Text = "Remove";
            this.btnRemoveTop.UseVisualStyleBackColor = true;
            this.btnRemoveTop.Visible = false;
            this.btnRemoveTop.Click += new System.EventHandler(this.btnRemoveTop_Click);
            // 
            // btnAddTop
            // 
            this.btnAddTop.FlatAppearance.BorderSize = 0;
            this.btnAddTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTop.Location = new System.Drawing.Point(10, 214);
            this.btnAddTop.Name = "btnAddTop";
            this.btnAddTop.Size = new System.Drawing.Size(59, 22);
            this.btnAddTop.TabIndex = 34;
            this.btnAddTop.Text = "Add";
            this.btnAddTop.UseVisualStyleBackColor = true;
            this.btnAddTop.Visible = false;
            this.btnAddTop.Click += new System.EventHandler(this.btnAddTop_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(190, 189);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 21);
            this.dtpDate.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 32;
            this.label8.Text = "Type:";
            // 
            // txtRemark
            // 
            this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRemark.Enabled = false;
            this.txtRemark.Location = new System.Drawing.Point(299, 175);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(100, 35);
            this.txtRemark.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(296, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "Remarks:";
            // 
            // txtType
            // 
            this.txtType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtType.Enabled = false;
            this.txtType.Location = new System.Drawing.Point(190, 162);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 21);
            this.txtType.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "Type:";
            // 
            // txtSerial
            // 
            this.txtSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerial.Enabled = false;
            this.txtSerial.Location = new System.Drawing.Point(48, 187);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(100, 21);
            this.txtSerial.TabIndex = 27;
            // 
            // txtBrand
            // 
            this.txtBrand.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrand.Enabled = false;
            this.txtBrand.Location = new System.Drawing.Point(48, 162);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(100, 21);
            this.txtBrand.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1, 187);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 25;
            this.label5.Text = "Serial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Brand:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader11,
            this.columnHeader12});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(4, 82);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(401, 77);
            this.listView1.TabIndex = 23;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Brand";
            this.columnHeader7.Width = 75;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Serial Number";
            this.columnHeader8.Width = 92;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Type";
            this.columnHeader9.Width = 44;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Date";
            this.columnHeader11.Width = 77;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Remark";
            this.columnHeader12.Width = 103;
            // 
            // btnHist
            // 
            this.btnHist.FlatAppearance.BorderSize = 0;
            this.btnHist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHist.Location = new System.Drawing.Point(268, 39);
            this.btnHist.Name = "btnHist";
            this.btnHist.Size = new System.Drawing.Size(121, 25);
            this.btnHist.TabIndex = 22;
            this.btnHist.Text = "View History";
            this.btnHist.UseVisualStyleBackColor = true;
            this.btnHist.Click += new System.EventHandler(this.btnHist_Click);
            // 
            // btnCnl
            // 
            this.btnCnl.Enabled = false;
            this.btnCnl.FlatAppearance.BorderSize = 0;
            this.btnCnl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCnl.Location = new System.Drawing.Point(227, 217);
            this.btnCnl.Name = "btnCnl";
            this.btnCnl.Size = new System.Drawing.Size(59, 22);
            this.btnCnl.TabIndex = 21;
            this.btnCnl.Text = "Cancel";
            this.btnCnl.UseVisualStyleBackColor = true;
            this.btnCnl.Click += new System.EventHandler(this.btnCnl_Click);
            // 
            // cbPN
            // 
            this.cbPN.FormattingEnabled = true;
            this.cbPN.Location = new System.Drawing.Point(112, 39);
            this.cbPN.Name = "cbPN";
            this.cbPN.Size = new System.Drawing.Size(121, 23);
            this.cbPN.TabIndex = 20;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(292, 216);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 25);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Replace Battery";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(108, 64);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(122, 15);
            this.lblDriver.TabIndex = 5;
            this.lblDriver.Text = "JUAN DELA CRUZ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Driver:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plate Number:";
            // 
            // lblBN
            // 
            this.lblBN.AutoSize = true;
            this.lblBN.Location = new System.Drawing.Point(109, 18);
            this.lblBN.Name = "lblBN";
            this.lblBN.Size = new System.Drawing.Size(31, 15);
            this.lblBN.TabIndex = 1;
            this.lblBN.Text = "000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Body Number:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelHist);
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(2, 249);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 268);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "History";
            // 
            // btnDelHist
            // 
            this.btnDelHist.FlatAppearance.BorderSize = 0;
            this.btnDelHist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelHist.Location = new System.Drawing.Point(146, 241);
            this.btnDelHist.Name = "btnDelHist";
            this.btnDelHist.Size = new System.Drawing.Size(123, 23);
            this.btnDelHist.TabIndex = 1;
            this.btnDelHist.Text = "Delete History";
            this.btnDelHist.UseVisualStyleBackColor = true;
            this.btnDelHist.Click += new System.EventHandler(this.btnDelHist_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.listView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(5, 21);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(401, 217);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Date";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Brand";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Serial";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Type";
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Driver";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Remark";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Bat_ID";
            this.columnHeader19.Width = 0;
            // 
            // frmBattMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(89)))), ((int)(((byte)(152)))));
            this.ClientSize = new System.Drawing.Size(414, 517);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBattMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Battery Management";
            this.Load += new System.EventHandler(this.frmBattMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Button btnDelHist;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbPN;
        private System.Windows.Forms.Button btnHist;
        private System.Windows.Forms.Button btnCnl;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRemoveTop;
        private System.Windows.Forms.Button btnAddTop;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
    }
}