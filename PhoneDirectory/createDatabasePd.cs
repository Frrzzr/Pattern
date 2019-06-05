using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace PhoneDirectory {
    class createDatabasePd {

        public createDatabasePd(int error) {
            try {
                errorValue = 0;
                errorValue = createDatabase(errorValue);
            }catch(Exception er) {
                if (Convert.ToInt32(er.Message.ToString()) == -1) createDatabase(-1);
                else if (Convert.ToInt32(er.Message.ToString()) == -2) createDatabase(-2);
                else if (Convert.ToInt32(er.Message.ToString()) == -3) createDatabase(-3);
                else if (Convert.ToInt32(er.Message.ToString()) == -4) createDatabase(-4);
                else if (Convert.ToInt32(er.Message.ToString()) == -5) createDatabase(-5);
                else if (Convert.ToInt32(er.Message.ToString()) == -6) createDatabase(-6);
                else if (Convert.ToInt32(er.Message.ToString()) == -7) createDatabase(-7);
                else throw;
            }
        }

        public static int EROR() { return errorValue; }
        private int createDatabase(int error) {
            StreamReader sr = null;
            string sqlInput = @"CREATE DATABASE PhoneDirectory", connectionString = @"Data Source=" + PhoneDirectory.PDirectory.COMPUTER_NAME.ToUpper() + ";Initial Catalog=master;Integrated Security=true";
            using (SqlConnection sqlconn = new SqlConnection(connectionString)) {
                // procced if the master databaaes are available
                try {
                    sqlconn.Open();
                    using (SqlCommand sqlcmd = new SqlCommand(sqlInput, sqlconn)) {
                        //error = -1;
                        if (error != -1) sqlcmd.ExecuteNonQuery();
                        using (SqlConnection sqlcon = new SqlConnection(
                                    @"Data Source=" + PhoneDirectory.PDirectory.COMPUTER_NAME.ToUpper()
                                    + ";Initial Catalog=PhoneDirectory;Integrated Security=true")) {
                            sqlconn.Close();
                            Thread.Sleep(1000);
                            sqlcon.Open();
                            using (SqlCommand sqlcomd = new SqlCommand(@"CREATE TABLE DETAILS_ABOUT_USERS ( Id INT NOT NULL PRIMARY KEY IDENTITY, Name VARCHAR(100) NOT NULL,
	                                    Nickname VARCHAR(100) NOT NULL, PhoneNumber VARCHAR(100) NOT NULL, MobileNumber VARCHAR(100) NOT NULL, EmailAddress VARCHAR(100) NOT NULL,
	                                    HomeAddress VARCHAR(100) NOT NULL, Company VARCHAR(100) NOT NULL, Position VARCHAR(100) NOT NULL, GroupName VARCHAR(100) NOT NULL, Website VARCHAR(100) NOT NULL,
                                        FacebookAccount VARCHAR(100) NOT NULL, Remarks VARCHAR(100) NOT NULL)", sqlcon)) {
                                //error = -2;
                                Thread.Sleep(1000);
                                if (error != -2) sqlcomd.ExecuteNonQuery();
                                sqlcomd.CommandText = @"CREATE TABLE USERS ( USERNAME VARCHAR(90) NOT NULL PRIMARY KEY, PASS VARCHAR(60) NOT NULL )";
                                //error = -3;
                                Thread.Sleep(1000);
                                if (error != -3) sqlcomd.ExecuteNonQuery();
                                sqlcomd.CommandText = @"ALTER TABLE DETAILS_ABOUT_USERS ADD FK_USERNAME VARCHAR(90) NOT NULL FOREIGN KEY REFERENCES USERS(USERNAME); ALTER TABLE USERS ADD EMAIL VARCHAR(90) DEFAULT NULL;";
                                //error = -4;
                                Thread.Sleep(1000);
                                if (error != -4) sqlcomd.ExecuteNonQuery();
                                sqlcomd.CommandText = @"CREATE TABLE Developers ( ID VARCHAR(12) NOT NULL PRIMARY KEY, NAME VARCHAR(50) NOT NULL, DEPARTMENT VARCHAR(90) NOT NULL DEFAULT 'INFORMATION SYSTEM',
	                                                    PHONE INT DEFAULT NULL, COURSE VARCHAR(100) NOT NULL DEFAULT 'EVENT DRIVEN PROGRAMMING', DUE_DATE DATE DEFAULT NULL,
	                                                    PROJECT_NAME VARCHAR(100) DEFAULT 'DIGITAL MULTI-USER PHONE DIRECTORY SYSTEM', WEBSITE VARCHAR(100) DEFAULT NULL )";
                                if (error != -5) sqlcomd.ExecuteNonQuery();
                                // read insert values from file
                                //File = "values.irsv";
                                try {
                                    sr = new StreamReader(Directory.GetCurrentDirectory() + "\\values.irsv");
                                    sqlcomd.CommandText = sr.ReadToEnd();
                                    Thread.Sleep(1000);
                                    sqlcomd.ExecuteNonQuery();
                                    sr.Close();
                                    Thread.Sleep(1000);
                                    sqlcomd.CommandText = @"CREATE TRIGGER NO_MORE_INSERT ON Developers FOR INSERT AS BEGIN ROLLBACK TRANSACTION END";
                                    if (error != -7) sqlcomd.ExecuteNonQuery();
                                    Thread.Sleep(1000);
                                    sqlcomd.CommandText = @"CREATE TRIGGER NO_MORE_UPDATE ON Developers FOR UPDATE AS BEGIN ROLLBACK TRANSACTION END";
                                    if (error != -6) sqlcomd.ExecuteNonQuery();
                                    
                                } catch (Exception _0) { MessageBox.Show(_0.Message.ToString()); }
                            }
                        }
                    }
                }
                catch (Exception _) {
                    //MessageBox.Show(_.Message.ToString()); // for debug only
                    if (_.Message.ToString().Equals(@"Database 'PhoneDirectory' already exists. Choose a different database name.")) throw new Exception("-1");
                    else if (_.Message.ToString().Equals(@"There is an object named 'DETAILS_ABOUT_USERS' in the database.")) throw new Exception("-2");
                    else if (_.Message.ToString().Equals(@"There is an object named 'USERS' in the database.")) throw new Exception("-3");
                    else if (_.Message.ToString().Equals(@"There is an object named 'Developers' in the database.")) throw new Exception("-5");
                    else if (_.Message.ToString().Equals(@"There is already an object named 'NO_MORE_UPDATE' in the database.")) throw new Exception("-6");
                    else if (_.Message.ToString().Equals(@"There is already an object named 'NO_MORE_INSERT' in the database.")) throw new Exception("-7");
                    else if (_.Message.ToString().Equals(@"Column names in each table must be unique. Column name 'FK_USERNAME' in table 'DETAILS_ABOUT_USERS' is specified more than once.") ||
                        _.Message.ToString().Equals(@"Column names in each table must be unique. Column name 'EMAIL' in table 'USERS' is specified more than once.")) throw new Exception("-4");
                    //else throw;
                    //sr.Close();
                }
            }
            return 0;
        }
        private static int errorValue;
    }
}
