using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;

namespace PhoneDirectory {
    public partial class PDirectory : Form {
        public PDirectory() { InitializeComponent(); sqlServerName = null; }
        static string name;
        private void Form1_Load(object sender, EventArgs e) {
            welcome well = new welcome();
            well.ShowDialog();
            user = well.return_user().ToString().ToUpper();
            this.Text = "Digital Phone Directory" + " (" + " " + user + " " + ")";
            if (well.isSucs()) {
                    well.label1_Click(null, null);
                    well.Close();
                    well.Dispose();
                    loadData();
            }
        }

        private void loadData() {
            //count++;
            //welcome well = new welcome(); 
            //well.ShowDialog();
            //user = well.return_user().ToString().ToUpper();
            //this.Text = "Digital Phone Directory" + " (" + " " + user + " " + ")";
            //MessageBox.Show(well.isSucs().ToString() + "     " + well.return_user().ToString());
            using (SqlConnection conn = new SqlConnection(@"Data Source=" + COMPUTER_NAME.ToString().ToUpper() + ";Initial Catalog=PhoneDirectory;Integrated Security=true")) {
                using (SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT Name,Nickname,PhoneNumber,MobileNumber,EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount FROM DETAILS_ABOUT_USERS WHERE Remarks = '' AND FK_USERNAME = '" 
                    + user + "'", conn)) {
                    try {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                    }catch(SqlException _) { 
                        DialogResult result = MessageBox.Show("ensure the database is up and running!\n" 
                            + _.Message.ToString(), "warning", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Information);
                        if (result == System.Windows.Forms.DialogResult.Abort) Application.Exit();
                        else if (result == System.Windows.Forms.DialogResult.Retry) { 
                            /**/ // let the sqlconnection object create the database
                            
                        } else if (result == System.Windows.Forms.DialogResult.Cancel) { Application.Exit(); }
                    }
                }
            }
        }

        private void loadData(string searcher, string field) {
            name = searcher;
            if (comboBox1.Text == "") {
                try {
                    using (SqlConnection conn = new SqlConnection(
                                            @"Data Source=" 
                                            + COMPUTER_NAME.ToString().ToUpper() + ";Initial Catalog=PhoneDirectory;Integrated Security=true")) {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(
                                           "SELECT Name,Nickname,PhoneNumber,MobileNumber,EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount  FROM DETAILS_ABOUT_USERS WHERE FK_USERNAME = '" + PDirectory.user.ToUpper() + "' AND ( Name LIKE '%" 
                                            + name +
                            "%' or Nickname LIKE '%"+name+
                            "%' or PhoneNumber LIKE '%" + name +
                            "%' or MobileNumber LIKE '%" + name +
                            "%' or EmailAddress LIKE '%" + name +
                            "%' or HomeAddress LIKE '%" + name +
                            "%' or Company LIKE '%" + name +
                            "%' or Position LIKE '%" + name +
                            "%' or GroupName LIKE '%" + name +
                            "%' or Website LIKE '%" + name +
                            "%' or FacebookAccount LIKE '%" + name + "%' )", conn)) {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                } catch (Exception er) { }
            }
            else {
                try {
                    using (SqlConnection conn = new SqlConnection(
                            @"Data Source=" + COMPUTER_NAME.ToString().ToUpper()
                            + ";Initial Catalog=PhoneDirectory;Integrated Security=true")) {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(
                            "SELECT Name,Nickname,PhoneNumber,MobileNumber,EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount  FROM DETAILS_ABOUT_USERS WHERE "
                             + " FK_USERNAME = '" + PDirectory.user.ToUpper() + "' AND ( " + field + " LIKE '%" + textBox1.Text + "%' )", conn)) {
                            DataSet ds = new DataSet();
                            adapter.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];
                        }
                    }
                } catch (Exception er) { }
            }

        }

        private void button1_Click(object sender, EventArgs e) {
            loadData();
            textBox1.Text= "";
            comboBox1.Text = "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            PD_dev a = new PD_dev();
            a.ShowDialog();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e) { loadData(textBox1.Text, comboBox1.Text); }

        static string Name1;
        static string Nickname;
        static string PhoneNumber;
        static string MobileNumber;
        static string EmailAddress;
        static string HomeAddress;
        static string Company;
        static string Position;
        static string GroupName;
        static string Website;
        static string FacebookAccount;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                Name1 = selectedRow.Cells[0].Value.ToString();
                Nickname = selectedRow.Cells[1].Value.ToString();
                PhoneNumber = selectedRow.Cells[2].Value.ToString();
                MobileNumber = selectedRow.Cells[3].Value.ToString();
                EmailAddress = selectedRow.Cells[4].Value.ToString();
                HomeAddress = selectedRow.Cells[5].Value.ToString();
                Company = selectedRow.Cells[6].Value.ToString();
                Position = selectedRow.Cells[7].Value.ToString();
                GroupName = selectedRow.Cells[8].Value.ToString();
                Website = selectedRow.Cells[9].Value.ToString();
                FacebookAccount = selectedRow.Cells[10].Value.ToString();

                PD_prev a = new PD_prev(Name1,Nickname,PhoneNumber,MobileNumber,EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount);
                a.ShowDialog();
                loadData();

            } catch (Exception er) { }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            PD_add a = new PD_add();
            //MessageBox.Show(dataGridView1.RowCount.ToString());
            a.ShowDialog();
            loadData();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e) {
            PD_dev a = new PD_dev();
            a.ShowDialog();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show("Close this form?", "Please Verify",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            e.Cancel = (result == DialogResult.No);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            this.Hide();
            welcome well = new welcome();
            well.ShowDialog();
            this.Text = "Digital Phone Directory (" + well.return_user() + ")";
            user = well.return_user();
            loadData();
            this.Show();
        }
    }
}
