namespace MySqlBackupAll
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btSetFolder = new System.Windows.Forms.Button();
            this.lbFolder = new System.Windows.Forms.Label();
            this.btBackup = new System.Windows.Forms.Button();
            this.btRestore = new System.Windows.Forms.Button();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.cbExportTableStructure = new System.Windows.Forms.CheckBox();
            this.cbExportRows = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnTurnAutomaticServiceOn = new System.Windows.Forms.Button();
            this.btnStopAutomaticService = new System.Windows.Forms.Button();
            this.lblNextBackup = new System.Windows.Forms.Label();
            this.radioButtonDaily = new System.Windows.Forms.RadioButton();
            this.radioButtonWeekly = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelServiceIsRunning = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSetFolder
            // 
            this.btSetFolder.Location = new System.Drawing.Point(20, 33);
            this.btSetFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btSetFolder.Name = "btSetFolder";
            this.btSetFolder.Size = new System.Drawing.Size(109, 36);
            this.btSetFolder.TabIndex = 0;
            this.btSetFolder.Text = "Select Folder";
            this.btSetFolder.UseVisualStyleBackColor = true;
            this.btSetFolder.Click += new System.EventHandler(this.btSetFolder_Click);
            // 
            // lbFolder
            // 
            this.lbFolder.AutoSize = true;
            this.lbFolder.Location = new System.Drawing.Point(136, 41);
            this.lbFolder.Name = "lbFolder";
            this.lbFolder.Size = new System.Drawing.Size(127, 20);
            this.lbFolder.TabIndex = 1;
            this.lbFolder.Text = "No Folder Selected";
            // 
            // btBackup
            // 
            this.btBackup.Location = new System.Drawing.Point(20, 109);
            this.btBackup.Margin = new System.Windows.Forms.Padding(4);
            this.btBackup.Name = "btBackup";
            this.btBackup.Size = new System.Drawing.Size(188, 36);
            this.btBackup.TabIndex = 2;
            this.btBackup.Text = "Backup All Databases";
            this.btBackup.UseVisualStyleBackColor = true;
            this.btBackup.Click += new System.EventHandler(this.btBackup_Click);
            // 
            // btRestore
            // 
            this.btRestore.Location = new System.Drawing.Point(216, 109);
            this.btRestore.Margin = new System.Windows.Forms.Padding(4);
            this.btRestore.Name = "btRestore";
            this.btRestore.Size = new System.Drawing.Size(189, 36);
            this.btRestore.TabIndex = 3;
            this.btRestore.Text = "Restore Databases";
            this.btRestore.UseVisualStyleBackColor = true;
            this.btRestore.Click += new System.EventHandler(this.btRestore_Click);
            // 
            // txtProgress
            // 
            this.txtProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProgress.Location = new System.Drawing.Point(20, 228);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ReadOnly = true;
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtProgress.Size = new System.Drawing.Size(730, 352);
            this.txtProgress.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "This program will backup and restore all databases.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "MySQL Connection String:";
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(188, 73);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(562, 26);
            this.txtConnStr.TabIndex = 11;
            // 
            // cbExportTableStructure
            // 
            this.cbExportTableStructure.AutoSize = true;
            this.cbExportTableStructure.Checked = true;
            this.cbExportTableStructure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExportTableStructure.Location = new System.Drawing.Point(388, 8);
            this.cbExportTableStructure.Name = "cbExportTableStructure";
            this.cbExportTableStructure.Size = new System.Drawing.Size(170, 24);
            this.cbExportTableStructure.TabIndex = 13;
            this.cbExportTableStructure.Text = "Export Table\'s Structure";
            this.cbExportTableStructure.UseVisualStyleBackColor = true;
            // 
            // cbExportRows
            // 
            this.cbExportRows.AutoSize = true;
            this.cbExportRows.Checked = true;
            this.cbExportRows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbExportRows.Location = new System.Drawing.Point(564, 8);
            this.cbExportRows.Name = "cbExportRows";
            this.cbExportRows.Size = new System.Drawing.Size(104, 24);
            this.cbExportRows.TabIndex = 14;
            this.cbExportRows.Text = "Export Rows";
            this.cbExportRows.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(519, 150);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(231, 26);
            this.dateTimePicker1.TabIndex = 15;
            // 
            // btnTurnAutomaticServiceOn
            // 
            this.btnTurnAutomaticServiceOn.Location = new System.Drawing.Point(422, 184);
            this.btnTurnAutomaticServiceOn.Name = "btnTurnAutomaticServiceOn";
            this.btnTurnAutomaticServiceOn.Size = new System.Drawing.Size(161, 36);
            this.btnTurnAutomaticServiceOn.TabIndex = 16;
            this.btnTurnAutomaticServiceOn.Text = "Backup Automagically";
            this.btnTurnAutomaticServiceOn.UseVisualStyleBackColor = true;
            this.btnTurnAutomaticServiceOn.Click += new System.EventHandler(this.btnTurnAutomaticServiceOn_Click);
            // 
            // btnStopAutomaticService
            // 
            this.btnStopAutomaticService.Enabled = false;
            this.btnStopAutomaticService.Location = new System.Drawing.Point(589, 184);
            this.btnStopAutomaticService.Name = "btnStopAutomaticService";
            this.btnStopAutomaticService.Size = new System.Drawing.Size(161, 36);
            this.btnStopAutomaticService.TabIndex = 17;
            this.btnStopAutomaticService.Text = "Stop Automagic Backup";
            this.btnStopAutomaticService.UseVisualStyleBackColor = true;
            this.btnStopAutomaticService.Click += new System.EventHandler(this.btnStopAutomaticService_Click);
            // 
            // lblNextBackup
            // 
            this.lblNextBackup.AutoSize = true;
            this.lblNextBackup.Location = new System.Drawing.Point(425, 153);
            this.lblNextBackup.Name = "lblNextBackup";
            this.lblNextBackup.Size = new System.Drawing.Size(88, 20);
            this.lblNextBackup.TabIndex = 18;
            this.lblNextBackup.Text = "Next backup:";
            // 
            // radioButtonDaily
            // 
            this.radioButtonDaily.AutoSize = true;
            this.radioButtonDaily.Checked = true;
            this.radioButtonDaily.Location = new System.Drawing.Point(3, 12);
            this.radioButtonDaily.Name = "radioButtonDaily";
            this.radioButtonDaily.Size = new System.Drawing.Size(56, 24);
            this.radioButtonDaily.TabIndex = 20;
            this.radioButtonDaily.TabStop = true;
            this.radioButtonDaily.Text = "Daily";
            this.radioButtonDaily.UseVisualStyleBackColor = true;
            // 
            // radioButtonWeekly
            // 
            this.radioButtonWeekly.AutoSize = true;
            this.radioButtonWeekly.Location = new System.Drawing.Point(64, 13);
            this.radioButtonWeekly.Name = "radioButtonWeekly";
            this.radioButtonWeekly.Size = new System.Drawing.Size(72, 24);
            this.radioButtonWeekly.TabIndex = 21;
            this.radioButtonWeekly.TabStop = true;
            this.radioButtonWeekly.Text = "Weekly";
            this.radioButtonWeekly.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonDaily);
            this.groupBox1.Controls.Add(this.radioButtonWeekly);
            this.groupBox1.Location = new System.Drawing.Point(429, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 43);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // labelServiceIsRunning
            // 
            this.labelServiceIsRunning.Enabled = false;
            this.labelServiceIsRunning.Location = new System.Drawing.Point(595, 112);
            this.labelServiceIsRunning.Name = "labelServiceIsRunning";
            this.labelServiceIsRunning.Size = new System.Drawing.Size(140, 32);
            this.labelServiceIsRunning.TabIndex = 23;
            this.labelServiceIsRunning.Text = "Service is running";
            this.labelServiceIsRunning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 592);
            this.Controls.Add(this.labelServiceIsRunning);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblNextBackup);
            this.Controls.Add(this.btnStopAutomaticService);
            this.Controls.Add(this.btnTurnAutomaticServiceOn);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cbExportRows);
            this.Controls.Add(this.cbExportTableStructure);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProgress);
            this.Controls.Add(this.btRestore);
            this.Controls.Add(this.btBackup);
            this.Controls.Add(this.lbFolder);
            this.Controls.Add(this.btSetFolder);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "MySql Backup Restore All - www.mysqlbackup.net";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSetFolder;
        private System.Windows.Forms.Label lbFolder;
        private System.Windows.Forms.Button btBackup;
        private System.Windows.Forms.Button btRestore;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.CheckBox cbExportTableStructure;
        private System.Windows.Forms.CheckBox cbExportRows;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnTurnAutomaticServiceOn;
        private System.Windows.Forms.Button btnStopAutomaticService;
        private System.Windows.Forms.Label lblNextBackup;
        private System.Windows.Forms.RadioButton radioButtonDaily;
        private System.Windows.Forms.RadioButton radioButtonWeekly;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelServiceIsRunning;
    }
}

