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
    public partial class PD_add : Form {
        public PD_add() { 
            InitializeComponent(); 
            this.label12.Enabled = this.label13.Enabled = false;
            this.label12.ForeColor = this.label13.ForeColor = Color.Red;
            this.label13.Hide();
            this.label12.Hide();
        }

        private void saveData() {
            SqlConnection connection = new SqlConnection(@"Data Source=" + PhoneDirectory.PDirectory.COMPUTER_NAME.ToUpper() + ";Initial Catalog=PhoneDirectory;Integrated Security=true");
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO DETAILS_ABOUT_USERS(Name,Nickname, PhoneNumber,MobileNumber, EmailAddress,HomeAddress,Company,Position,GroupName,Website,FacebookAccount,Remarks,FK_USERNAME) VALUES(@Name,@Nickname, @PhoneNumber,@MobileNumber, @EmailAddress,@HomeAddress,@Company,@Position,@GroupName,@Website,@FacebookAccount,@Remarks,@FK_USERNAME)";
            //cmd.Parameters.AddWithValue("@ID", PhoneDirectory.Form1.rowCount + 10000);
            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Nickname", textBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNumber", Convert.ToInt32(textBox3.Text));
            cmd.Parameters.AddWithValue("@MobileNumber", Convert.ToInt32(textBox4.Text));
            cmd.Parameters.AddWithValue("@EmailAddress", textBox5.Text);
            cmd.Parameters.AddWithValue("@HomeAddress", textBox6.Text);
            cmd.Parameters.AddWithValue("@Company", textBox7.Text);
            cmd.Parameters.AddWithValue("@Position", textBox8.Text);
            cmd.Parameters.AddWithValue("@GroupName", textBox9.Text);
            cmd.Parameters.AddWithValue("@Website", textBox10.Text);
            cmd.Parameters.AddWithValue("@FacebookAccount", textBox11.Text);
            cmd.Parameters.AddWithValue("@Remarks", "");
            cmd.Parameters.AddWithValue("@FK_USERNAME", PDirectory.user);

            if (!textBox1.Text.Equals("")  || !textBox2.Text.Equals("") || !textBox3.Text.Equals("") || 
                !textBox4.Text.Equals("")  || !textBox5.Text.Equals("") || !textBox6.Text.Equals("") ||
                !textBox7.Text.Equals("")  || !textBox8.Text.Equals("") || !textBox9.Text.Equals("") ||
                !textBox10.Text.Equals("") || !textBox11.Text.Equals("")) {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfully saved to directory", " System Notification");
            } else MessageBox.Show("can not add null value to the directory");

            if (connection != null) connection.Close();
        }

        private void button1_Click(object sender, EventArgs e) { 
            try { 
                saveData(); 
            }catch(FormatException _) {
                this.label12.Enabled = this.label13.Enabled = true;
                this.label12.ForeColor = this.label13.ForeColor = Color.Red;
                this.label13.Show();
                this.label12.Show();
            }catch (Exception er) {  MessageBox.Show(er.Message); } 
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
            this.label12.Enabled = this.label13.Enabled = false;
            this.label12.ForeColor = this.label13.ForeColor = Color.Red;
            this.label13.Hide();
            this.label12.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e) { textBox3_TextChanged(sender, e); }
    }
}
