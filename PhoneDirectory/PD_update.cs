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
    public partial class PD_update : Form {
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

        public PD_update(
            string name, 
            string nickname, 
            string phonenumber, 
            string mobilenumber, 
            string emailadd, 
            string homeadd, 
            string comp, 
            string post, 
            string group, 
            string web, 
            string fb) {

            Name1 = name;
            Nickname = nickname;
            PhoneNumber = phonenumber;
            MobileNumber = mobilenumber;
            EmailAddress = emailadd;
            HomeAddress = homeadd;
            Company = comp;
            Position = post;
            GroupName = group;
            Website = web;
            FacebookAccount = fb;

            InitializeComponent();
        }

        private void frm_update_Load(object sender, EventArgs e) {
            textBox1.Text = Name1;
            textBox2.Text = Nickname;
            textBox3.Text = PhoneNumber;
            textBox4.Text = MobileNumber;
            textBox5.Text = EmailAddress;
            textBox6.Text = HomeAddress;
            textBox7.Text = Company;
            textBox8.Text = Position;
            textBox9.Text = GroupName;
            textBox10.Text = Website;
            textBox11.Text = FacebookAccount;
        }

        private void button1_Click(object sender, EventArgs e) {
              DialogResult result2 = MessageBox.Show(
                  "Are you sure you want to update "+textBox1.Text+"'s information?",
                  " System Notification",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
              if (result2 == DialogResult.OK) {
                  string connectionString = @"Data Source=" + PhoneDirectory.PDirectory.COMPUTER_NAME.ToUpper() + ";Initial Catalog=PhoneDirectory;Integrated Security=true";
                  SqlConnection connection = null;
                  try {
                      connection = new SqlConnection(connectionString);
                      connection.Open();
                      SqlCommand cmd = new SqlCommand();
                      cmd.Connection = connection;
                      cmd.CommandText = "UPDATE DETAILS_ABOUT_USERS SET Name = '" + textBox1.Text + "',Nickname = '" + textBox2.Text + "',PhoneNumber = '" 
                          + Convert.ToInt32(textBox3.Text) + "',MobileNumber = '" + Convert.ToInt32(textBox4.Text) + "',EmailAddress = '" + textBox5.Text + "',HomeAddress = '" + textBox6.Text 
                          + "',Company = '" + textBox7.Text + "',Position = '" + textBox8.Text + "',GroupName = '" 
                          + textBox9.Text + "',Website = '" + textBox10.Text + "',FacebookAccount = '" + textBox11.Text +
                          "' WHERE DETAILS_ABOUT_USERS.Name = '" + Name1 + "' and Nickname = '" + Nickname + "' and PhoneNumber = '" + PhoneNumber +
                          "' and MobileNumber = '" + MobileNumber + "' and EmailAddress = '" + EmailAddress + "' and HomeAddress = '" + HomeAddress +
                          "' and Company = '" + Company + "' and Position = '" + Position + "' and FacebookAccount = '" + FacebookAccount + "'";
                      cmd.ExecuteNonQuery();

                      if (connection != null) connection.Close();
                      MessageBox.Show("Information successfully updated", " System Informtaion");
                  } catch (SqlException er) { MessageBox.Show(er.Message); 
                  } catch(FormatException _) { MessageBox.Show("phone or mobile number cant be string");
                  }finally { if (connection != null) connection.Close(); }
              } this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e) {
              DialogResult result2 = MessageBox.Show(
                  "Are you sure you want to delete "+textBox1.Text+"'s information?",
                  " System Notification",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
              if (result2 == DialogResult.OK) {
                  string connectionString = @"Data Source=" + PhoneDirectory.PDirectory.COMPUTER_NAME.ToUpper() + ";Initial Catalog=PhoneDirectory;Integrated Security=true";
                  SqlConnection connection = null;
                  try {
                      connection = new SqlConnection(connectionString);
                      connection.Open();
                      SqlCommand cmd = new SqlCommand();
                      cmd.Connection = connection;
                      cmd.CommandText = "UPDATE DETAILS_ABOUT_USERS SET Remarks = 'Deleted' WHERE DETAILS_ABOUT_USERS.Name = '" + Name1 + 
                          "' and Nickname = '" + Nickname + 
                          "' and PhoneNumber = '" + PhoneNumber +
                          "' and MobileNumber = '" + MobileNumber + 
                          "' and EmailAddress = '" + EmailAddress + 
                          "' and HomeAddress = '" + HomeAddress +
                          "' and Company = '" + Company + 
                          "' and Position = '" + Position + 
                          "' and FacebookAccount = '" + FacebookAccount + "'";
                      cmd.ExecuteNonQuery();

                      if (connection != null) connection.Close();
                      MessageBox.Show("Information successfully updated", " System Informtaion");
                  } catch (Exception er) {  MessageBox.Show(er.Message); 
                  } finally { if (connection != null) connection.Close(); }
              }
              this.Close();
        }
    }
}
