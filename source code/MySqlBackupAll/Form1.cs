﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
using System.IO;
using System.Threading;

namespace MySqlBackupAll
{
    public partial class Form1 : Form
    {
        BackgroundWorker bw = new BackgroundWorker();
        bool isBackup = true;
        int count = 0;
        string folder = "";
        string server = "";
        string user = "";
        string pwd = "";
        DateTime timeProcessStart = DateTime.Now;
        bool hasError = false;
        string errmsg = "";
        string constr = "";

        Task mySchedulerTask;

        bool schedulerIsRunning;
        bool scheduledTaskIsAllowed = false;

        public Form1()
        {
            InitializeComponent();
            bw.WorkerReportsProgress = true;
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.ProgressChanged += Bw_ProgressChanged;
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            txtProgress.AppendText(e.UserState + "");
            txtProgress.Select(txtProgress.Text.Length - 1, 0);
            txtProgress.ScrollToCaret();
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DateTime timeProcessEnd = DateTime.Now;

            var timeTotal = timeProcessEnd - timeProcessStart;

            this.SuspendLayout();

            txtProgress.Text = txtProgress.Text + "\r\nProcess End at " + timeProcessEnd.ToString("yyyy-MM-dd HH:mm:ss ffff") + "\r\n\r\nTotal time elapsed: " + string.Format("{0} h {1} m {2} s {3} ms", timeTotal.Hours, timeTotal.Minutes, timeTotal.Seconds, timeTotal.Milliseconds);

            if (hasError)
            {
                txtProgress.AppendText("\r\nError:\r\n\r\n");
                txtProgress.AppendText(errmsg);
            }

            txtProgress.Select(txtProgress.Text.Length - 1, 0);
            txtProgress.ScrollToCaret();

            this.ResumeLayout();
            this.PerformLayout();

            //if (isBackup)
            //    MessageBox.Show($"{count} databases exported at\r\n\r\n{lbFolder.Text}");
            //else
            //    MessageBox.Show($"{count} databases imported from\r\n\r\n{lbFolder.Text}");
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (isBackup)
                    DoBackup();
                else
                    DoRestore();

                if (schedulerIsRunning)
                {
                    this.Invoke(new Action(() =>
                    {
                        if (radioButtonDaily.Checked)
                            dateTimePicker1.Value = DateTime.Now.AddDays(1);
                        else if (radioButtonWeekly.Checked)
                            dateTimePicker1.Value = DateTime.Now.AddDays(7);
                    }));
                    schedulerIsRunning = false;


                }
            }
            catch (Exception ex)
            {
                hasError = true;
                errmsg = ex.ToString();
            }
        }

        void DoRestore()
        {
            string[] files = Directory.GetFiles(folder);

            DateTime timeProcessStart = DateTime.Now;

            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    foreach (string file in files)
                    {
                        string db = Path.GetFileNameWithoutExtension(file);

                        DateTime dateStart = DateTime.Now;

                        string appendText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  Restore " + db + "....";
                        bw.ReportProgress(0, appendText);

                        cmd.CommandText = "create database if not exists `" + db + "`";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = $"use `{db}`";
                        cmd.ExecuteNonQuery();

                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            mb.ImportFromFile(file);
                        }

                        DateTime dateEnd = DateTime.Now;

                        var timeElapsed = dateEnd - dateStart;

                        appendText = $" completed ({timeElapsed.Hours} h {timeElapsed.Minutes} m {timeElapsed.Seconds} s {timeElapsed.Milliseconds} ms)\r\n";
                        bw.ReportProgress(0, appendText);

                        count++;
                    }

                    conn.Close();
                }
            }
        }

        void DoBackup()
        {
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    conn.Open();
                    cmd.Connection = conn;

                    DataTable dt = GetTable(cmd, "show databases;");

                    foreach (DataRow dr in dt.Rows)
                    {
                        string db = dr[0] + "";

                        switch (db)
                        {
                            case "sys":
                            case "performance_schema":
                            case "mysql":
                            case "information_schema":
                                continue;
                        }

                        DateTime dateStart = DateTime.Now;

                        string appendText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  Backup " + db + "....";
                        bw.ReportProgress(0, appendText);

                        cmd.CommandText = $"use `{db}`";
                        cmd.ExecuteNonQuery();

                        string file = Path.Combine(lbFolder.Text, $"{db}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}.sql");

                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            mb.ExportInfo.ExportTableStructure = cbExportTableStructure.Checked;
                            mb.ExportInfo.ExportRows = cbExportRows.Checked;
                            mb.ExportToFile(file);
                        }

                        DateTime dateEnd = DateTime.Now;

                        var timeElapsed = dateEnd - dateStart;

                        appendText = $" completed ({timeElapsed.Hours} h {timeElapsed.Minutes} m {timeElapsed.Seconds} s {timeElapsed.Milliseconds} ms)" + "\r\n";
                        bw.ReportProgress(0, appendText);

                        count++;
                    }

                    conn.Close();
                }
            }
        }

        bool LoadData()
        {
            GC.Collect();
            hasError = false;
            errmsg = "";
            folder = lbFolder.Text;
            constr = txtConnStr.Text;
            count = 0;
            timeProcessStart = DateTime.Now;
            txtProgress.Text = "Start at " + timeProcessStart.ToString("yyyy-MM-dd HH:mm:ss ffff") + "\r\n\r\n";
            this.Refresh();



            if (constr.Length == 0)
            {
                MessageBox.Show("Connection string is not set. Cannot continue.");
                return false;
            }

            return true;
        }

        private void btRestore_Click(object sender, EventArgs e)
        {
            if (lbFolder.Text.Length == 0)
            {
                MessageBox.Show("Folder is not set");
                return;
            }

            if (!Directory.Exists(lbFolder.Text))
            {
                MessageBox.Show("Selected folder is not existed.");
                return;
            }

            isBackup = false;

            if (!LoadData())
            {
                return;
            }

            bw.RunWorkerAsync();
        }

        private void btBackup_Click(object sender, EventArgs e)
        {
            if (lbFolder.Text.Length == 0)
            {
                MessageBox.Show("Folder is not set");
                return;
            }

            if (!Directory.Exists(lbFolder.Text))
            {
                MessageBox.Show("Selected folder is not existed.");
                return;
            }

            isBackup = true;

            if (!LoadData())
            {
                return;
            }

            bw.RunWorkerAsync();
        }

        private void btSetFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if (fb.ShowDialog() == DialogResult.OK)
            {
                lbFolder.Text = fb.SelectedPath;
            }
        }

        DataTable GetTable(MySqlCommand cmd, string sql)
        {
            cmd.CommandText = sql;
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        void Backup()
        {
            string connstr = "server=localhost;user=root;pwd=1234;sslmode=none;convertdatetime=true;";

            using (MySqlConnection conn = new MySqlConnection(connstr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        conn.Open();
                        cmd.Connection = conn;

                        cmd.CommandText = "show databases;";
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        DataTable dtDbList = new DataTable();
                        da.Fill(dtDbList);

                        string defaultFolder = "C:\\backup_folder";


                        string defaultBackupFolder = "C:\\backup_folder";
                        string[] files = System.IO.Directory.GetFiles(defaultBackupFolder);

                        foreach (string file in files)
                        {
                            if (file.ToLower().EndsWith(".sql"))
                            {
                                string dbName = System.IO.Path.GetFileNameWithoutExtension(file);

                                cmd.CommandText = "create database if not exists `" + dbName + "`";
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "use `" + dbName + "`";
                                cmd.ExecuteNonQuery();

                                mb.ImportFromFile(file);
                            }
                        }

                        conn.Close();
                    }
                }
            }
        }

        private void btnTurnAutomaticServiceOn_Click(object sender, EventArgs e)
        {
            if (lbFolder.Text.Length == 0)
            {
                MessageBox.Show("Folder is not set");
                return;
            }

            if (!Directory.Exists(lbFolder.Text))
            {
                MessageBox.Show("Selected folder is not existed.");
                return;
            }
            btnTurnAutomaticServiceOn.Enabled = false;
            dateTimePicker1.Enabled = false;
            scheduledTaskIsAllowed = true;

            //hack, when a radiobutton group's button gets disabled, the group selects the next button as checked
            bool radioButtonDailyChecked = radioButtonDaily.Checked;
            bool radioButtonWeeklyChecked = radioButtonWeekly.Checked;
            radioButtonDaily.Enabled = false;
            radioButtonWeekly.Enabled = false;
            radioButtonDaily.Checked = radioButtonDailyChecked;
            radioButtonWeekly.Checked = radioButtonWeeklyChecked;

            var originalColor = labelServiceIsRunning.BackColor;
            labelServiceIsRunning.BackColor = Color.LimeGreen;
            labelServiceIsRunning.Enabled = true;
            btnStopAutomaticService.Enabled = true;

            mySchedulerTask = Task.Factory.StartNew(() =>
            {
                while (scheduledTaskIsAllowed)
                {
                    if (!schedulerIsRunning)
                    {
                        int result = DateTime.Compare(DateTime.Now, dateTimePicker1.Value);
                        
                        if (result == 1 && !schedulerIsRunning)
                        {
                            schedulerIsRunning = true;
                            isBackup = true;

                            this.Invoke(new Action(() =>
                            {
                                btnStopAutomaticService.Enabled = true;
                                if (!LoadData())
                                {
                                    return;
                                }

                                bw.RunWorkerAsync();
                            }));
                        }

                    }
                    Thread.Sleep(100);
                }
                this.Invoke(new Action(() =>
                {
                    btnTurnAutomaticServiceOn.Enabled = true;
                    btnStopAutomaticService.Enabled = false;
                    dateTimePicker1.Enabled = true;
                    radioButtonDaily.Enabled = true;
                    radioButtonWeekly.Enabled = true;
                    labelServiceIsRunning.BackColor = originalColor;
                    labelServiceIsRunning.Enabled = false;
                }));
            });

            

        }

        private void btnStopAutomaticService_Click(object sender, EventArgs e)
        {
            scheduledTaskIsAllowed = false;
        }
    }
}