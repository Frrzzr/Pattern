using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneDirectory {
    class helpUser { /// help user by changing and sending comfirmation email

        public helpUser(string e) { 
            resetPass(e); 
            this.isSuss = true; 
            lst = new List<char>();
            lst.Add('`');
            lst.Add('{');
            lst.Add('}');
            lst.Add('|');
            lst.Add('\\');
            lst.Add('/');
            lst.Add('~');
            lst.Add('-');
            lst.Add('_');
            lst.Add('+');
            lst.Add('=');
            lst.Add('(');
            lst.Add(')');
            lst.Add('?');
            lst.Add('<');
            lst.Add('>');
            lst.Add('*');
            lst.Add('&');
            lst.Add('^');
            lst.Add('%');
            lst.Add('#');
            lst.Add('!');
            lst.Add('"');
            lst.Add('\'');
            lst.Add(';');
            lst.Add(':');
            lst.Add('$');
        }

        public bool sussess() { return this.isSuss == true; }
        private int resetPass(string email) {
            try {
                generatePass();
                composeEmail(email);
                commitChange();
            }catch (FormatException _) {
            }catch (Exception _) {
                // identify the problem first
                // then set the isSuss to false
            }
            return 0; 
        }


        // generate random seed
        private string generatePass() {
            // generate password for specified user 
            // and length
            // if we can't generate throw new Ex
            // use timestamp to seed randomly 
            return null;
        }


        private bool composeEmail(string toEmail) {
            // check the specified string is in correct format
            // and ensure the email address is working
            checkEmailValidation(toEmail);
            checkAvailability(toEmail.Substring(toEmail.IndexOf("@")));
            // compose Email mail To 
            // users mail address 
            // with new password text and
            // if we can't compose raise specific error 
            return true;
        }


        private bool checkEmailValidation(string email) {
            // return 0 if text in correct format
            // else report true
            // if supplied with non valid string
            // raise not valid email address warnning
            int size = 0;
            while (size < lst.Count) {
                if (email.Contains(lst[size])) throw new FormatException();
            }
            if (email.Contains(" ")) throw new FormatException(); // check first space between character
            else { // check availability of (@) and (.)
                if (!email.Contains("@") && !email.Contains(".")) throw new FormatException();
                else {  // check index occurence ratio
                    if (email.IndexOf("@") == -1 || email.IndexOf(".") == -1) throw new FormatException();
                    else {
                        string subAt = email.Substring(email.IndexOf(".")+1, email.Length - (email.IndexOf(".")+1));
                        if (subAt == string.Empty) throw new FormatException();;
                        if (subAt.Contains("@") || !subAt.Contains(".")) throw new FormatException();
                        else {
                            if (subAt[0].Equals('.')) throw new FormatException();
                            if (email.StartsWith(".") || email.EndsWith(".") || email.StartsWith("@")) throw new FormatException();
                        }
                    }
                }
            }
            return true;
        }


        private bool checkAvailability(string domain) {
            // return true if mail address are available in the wild
            // else false and report
            // check if the server respose with no error report
            // request http or smtp connection to the domain
            return true;
        }


        private bool commitChange() {
            // return 0 if successfully commited
            // else do something
            // if sqlexception occured throw 
            return true;
        }

        private bool isSuss;
        private List<char> lst;
    }
}
