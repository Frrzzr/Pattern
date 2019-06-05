using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneDirectory
{
    public partial class PD_prev : Form
    {

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

        public PD_prev(string name, string nickname, string phonenumber,string mobilenumber,string emailadd,string homeadd,string comp,string post,string group,string web,string fb)
        {
            Name1 =name;
            Nickname  = nickname;
            PhoneNumber= phonenumber;
            MobileNumber=mobilenumber;
            EmailAddress=emailadd;
            HomeAddress = homeadd ;
            Company = comp;
            Position= post;
            GroupName=group;
            Website= web;
            FacebookAccount=fb;

            InitializeComponent();
        }

        private void frm_prev_Load(object sender, EventArgs e)
        {
            label1.Text = "Name : " + Name1;
            label2.Text = "Nickname : " + Nickname;
            label3.Text = "Phone Number : " + PhoneNumber;
            label4.Text = "Mobile Number : " + MobileNumber;
            label5.Text = "Email Address : " + EmailAddress;
            label6.Text = "Home Address : " + HomeAddress;
            label7.Text = "Company : " + Company;
            label8.Text = "Position : " + Position;
            label9.Text = "Group : " + GroupName;
            label10.Text = "Website : " + Website;
            label11.Text = "Facebook Account : " + FacebookAccount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PD_update a = new PD_update(Name1, Nickname, PhoneNumber, MobileNumber, EmailAddress, HomeAddress, Company, Position, GroupName, Website, FacebookAccount);
            a.ShowDialog();
            this.Close();
        }
    }
}
