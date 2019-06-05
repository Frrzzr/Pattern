using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace PhoneDirectory {
    public partial class welcome : Form {
        public welcome() {
            errorValue = createDatabasePd.EROR();
            createDatabasePd cdbPd = new createDatabasePd(errorValue);
            InitializeComponent();
            this.button3.Enabled = false;
            this.button3.Hide();
            this.button4.Enabled = false;
            this.button4.Hide();
        }

        public void label1_Click(object sender, EventArgs e) { if (this.isSucs()) this.Close(); else Application.Exit(); }

        private void button1_Click(object sender, EventArgs e) {
            this.button2.Text = "SIGN UP";
            this.label10.Hide();
            this.label10.Enabled = false;
            this.textBox3.Enabled = false;
            this.textBox3.Hide();
            this.label9.Enabled = false;
            this.label9.Hide();
            // if either of one of three textbox is empty raise null error
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("")) {
                if (textBox1.Text.Equals("")) { this.label6.ForeColor = Color.Red; label6.Text = "username field can not be empty"; }
                //if (textBox3.Text.Equals("") && textBox3.Enabled) { this.label10.ForeColor = Color.Red; label10.Text = "email field can not be empty"; }
                if (textBox2.Text.Equals("")) { this.label7.ForeColor = Color.Red; label7.Text = "password field can not be empty"; }
            }
            else {
                string connectionString = @"Data Source=" + PhoneDirectory.PDirectory.COMPUTER_NAME.ToUpper() + ";Initial Catalog=PhoneDirectory;Integrated Security=true"; 
                using (SqlConnection sqlconn = new SqlConnection(connectionString)) {
                    try { sqlconn.Open(); }
                    catch (SqlException _) { MessageBox.Show(_.Message.ToString()); errorValue = createDatabasePd.EROR(); createDatabasePd cdbPd = new createDatabasePd(errorValue); }
                    string sqlInput = "SELECT USERNAME, PASS FROM USERS WHERE USERNAME='" + textBox1.Text.ToUpper() + "' AND PASS = '" + textBox2.Text.ToUpper() + "'" ;
                    using (SqlDataAdapter sqa = new SqlDataAdapter(sqlInput, sqlconn)) {
                        DataTable DS = new DataTable();
                        try { sqa.Fill(DS); }catch(SqlException _) {/*create the database and entire thing thast is neccessery for the program*/
                            errorValue = createDatabasePd.EROR(); createDatabasePd cdbPd = new createDatabasePd(errorValue); // MessageBox.Show("can not create the databse refere to README.txt"); 
                        }
                        if (DS.Rows.Count == 1) { MessageBox.Show("welcome " + textBox1.Text.ToUpper()); isSuccess = true; this.label1_Click(null, null); }
                        else { MessageBox.Show(textBox1.Text.ToUpper() + " not found "); if (count == 2) Application.Exit(); count += 1; }
                    }
                    sqlconn.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            this.label7.ForeColor = Color.White;
            this.label6.ForeColor = Color.White;
            label6.Text = "";
            this.label10.ForeColor = Color.White;
            this.label10.Text = "";
            label7.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            this.label7.ForeColor = Color.White;
            this.label6.ForeColor = Color.White;
            label6.Text = "";
            this.label10.ForeColor = Color.White;
            this.label10.Text = "";
            label7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e) {
            if (this.button2.Text == "SIGN UP") {
                this.button2.Text = "SIGN ME UP";
                this.textBox2.Text = "";
                this.textBox1.Text = "";
                this.textBox3.Enabled = true;
                this.textBox3.Show();
                this.label9.Enabled = true;
                this.label9.Show();
                this.counter++;
            }
            else {
                //this.button2.Text = "SIGN UP";
                //this.textBox3.Enabled = true;
                //this.textBox3.Show();
                //this.label9.Enabled = true;
                //this.label9.Show();
            

                if (/*counter % 2 == 0 && */(this.button2.Text == "SIGN ME UP")) {
                    if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("")) {
                        if (textBox1.Text.Equals("")) { this.label6.ForeColor = Color.Red; label6.Text = "username field can not be empty"; }
                        if (textBox3.Text.Equals("") && textBox3.Enabled) { this.label10.Enabled = true; this.label10.Show(); this.label10.ForeColor = Color.Red; label10.Text = "email field can not be empty"; }
                        if (textBox2.Text.Equals("")) { this.label7.ForeColor = Color.Red; label7.Text = "password field can not be empty"; }
                    }
                    else {
                        // do the registretion
                        // FIRST CHECK WHETHER THE FIELD IS REGIDSTERED BEFORE
                        string connectionString = @"Data Source=" + PhoneDirectory.PDirectory.COMPUTER_NAME.ToUpper() + ";Initial Catalog=PhoneDirectory;Integrated Security=true";
                            try {
                                using (SqlConnection sqlconn = new SqlConnection(connectionString)) {
                                    sqlconn.Open();
                                    string sqlInput = @"INSERT INTO USERS (USERNAME, PASS, EMAIL) VALUES ('" + textBox1.Text.ToUpper() + "', '" + textBox2.Text.ToUpper() + "', '" + textBox3.Text.ToUpper() + "')";
                                    using (SqlCommand sqlcmd = new SqlCommand(sqlInput, sqlconn)) {
                                        try{
                                            sqlcmd.ExecuteNonQuery();
                                            MessageBox.Show("REGISTERED SUCCESSFULLY");
                                            //RESETV();
                                        }catch(SqlException _) {MessageBox.Show(_.Message.ToString());  errorValue = createDatabasePd.EROR(); createDatabasePd cdbPd = new createDatabasePd(errorValue);// MessageBox.Show("can not create the databse refere to README.txt");
                                        }
                                 }
                             }
                         } catch (Exception _) { MessageBox.Show(_.Message.ToString()); }
                     }
                }
                else {

                }
                //this.button2.Text = "SIGN UP";
             }
        }

        private void welcome_Load(object sender, EventArgs e) {
            this.textBox3.Enabled = false;
            this.textBox3.Hide();
            this.label9.Enabled = false;
            this.label9.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) { textBox2_TextChanged(sender, e); }

        public string return_user() { return textBox1.Text.ToUpper(); }
        public bool isSucs() { return isSuccess; }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            if (checkBox1.Checked) textBox2.PasswordChar = '\0';
            else textBox2.PasswordChar = '*';
        }

        private void RESETV() {
            textBox3.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
            label10.Text = "";
            label6.Text = "";
            label7.Text = "";
            label9.Enabled = false;
            label9.Hide();
            label8.Text = "";
            label9.Text = "";
            textBox3.Enabled = false;
            textBox3.Hide();
        }
            // if not aware of anything pop up new form which
            // contain detail information about the project

            // if lost password 
            // use the python imap module for email retrieval
            // to send new generated password phrase in base64_encoded format

        private void fORGOTPASSWORDToolStripMenuItem_Click(object sender, EventArgs e) {
            LockUnlock lockInOut = new LockUnlock(ref button1, ref button2, ref button3, ref button4,
                ref textBox1, ref textBox2, ref textBox3, ref checkBox1,
                ref label10, ref label7, ref label6, ref label5, ref label4, ref label9);
            lockInOut.Lock(); // desable all the fields for the purpose of data entry
        }


        private void aBOUTASToolStripMenuItem_Click(object sender, EventArgs e) {
            PD_dev fd = new PD_dev();
            fd.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e) {
            if (textBox3.Text.Equals("")) {// raise null warning
                this.label10.Enabled = true;
                this.label10.Show();
                this.label10.ForeColor = Color.Red; label10.Text = "email field can not be empty";
            }
            else {
                helpUser help = new helpUser(textBox3.Text.ToLower());
                if (!help.sussess()) MessageBox.Show("can not help at the moment ");
                // if it Success
                else {
                    // call button4_Click(sender, e);
                    MessageBox.Show("check you Inbox");
                    button4_Click(sender, e);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            LockUnlock lockInOut = new LockUnlock(ref button1, ref button2, ref button3, ref button4,
                ref textBox1, ref textBox2, ref textBox3, ref checkBox1, 
                ref label10, ref label7, ref label6, ref label5, ref label4, ref label9);
            // resume to old state 
            lockInOut.unLock();
            this.label6.Text = "";
            this.label7.Text = "";
            // dispose helper
        }
    }
}

