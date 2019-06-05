using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace PhoneDirectory {
    public partial class PD_dev : Form {
        public PD_dev() {
            InitializeComponent();
            this.connectionString = @"Data Source=" + PhoneDirectory.PDirectory.COMPUTER_NAME.ToUpper() // + server name
                                    + ";Initial Catalog=PhoneDirectory;Integrated Security=true";
            this.sqlInput = @"SELECT * FROM Developers";
            loadData();
        }

        private void loadData() {
            try {
                using (SqlConnection sqlconn = new SqlConnection(this.connectionString)) {
                    sqlconn.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(sqlInput, sqlconn)) {
                        DataSet DS = new DataSet();
                        //sda.SelectCommand = sqlInput;
                        sda.Fill(DS);
                        this.dataGridView1.DataSource = DS.Tables[0];
                    }
                }
            }catch(Exception _) { MessageBox.Show(_.Message.ToString()); }
        }
        private string connectionString;
        private string sqlInput;
    }
}
