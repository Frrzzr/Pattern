using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PhoneDirectory {
    class LockUnlock {
        public LockUnlock(ref Button  BtnOne,    ref Button  BtnTwo,    ref Button  BtnThree,    ref Button BtnFour,
                          ref TextBox TxtBoxOne, ref TextBox TxtBoxTwo, ref TextBox TxtBoxThree, ref CheckBox ChkBoxOne,
                          ref Label   LblOne,    ref Label   LblTwo,    ref Label   LblThree,    ref Label LblFour,
                          ref Label LblFive, ref Label LblSix) {

            //Button[] button = new Button[4];
            //TextBox[] textBox = new TextBox[3];
            //Label[] label = new Label[3];

            try {
                for (int index = 0; index < 4; index++) button[index] = new Button();
                for (int index = 0; index < 3; index++) textBox[index] = new TextBox();
                for (int index = 0; index < 5; index++) label[index] = new Label();
            } catch (IndexOutOfRangeException _) { MessageBox.Show(_.Message.ToString()); }

            this.button[0] = BtnOne;
            this.button[1] = BtnTwo;
            this.button[2] = BtnThree;
            this.button[3] = BtnFour;

            this.textBox[0] = TxtBoxOne;
            this.textBox[1] = TxtBoxTwo;
            this.textBox[2] = TxtBoxThree;

            this.label[0] = LblOne;
            this.label[1] = LblTwo;
            this.label[2] = LblThree;
            this.label[3] = LblFour;
            this.label[4] = LblFive;
            this.label[5] = LblSix;

            this.checkbox = ChkBoxOne;
        }


        public void Lock() {
            try{
                for (int index = 0; index < 2; index++) { button[index].Enabled = false; button[index].Hide(); }
                for (int index = 0; index < 2; index++) { textBox[index].Enabled = false; textBox[index].Hide(); }
                for (int index = 0; index < 5; index++) { label[index].Enabled = false; label[index].Hide(); }
                if (button[2].Enabled && button[3].Enabled) { /*keep property to default*/}
                else for (int index = 2; index < 4; index++) { button[index].Enabled = true; button[index].Show(); }
                this.textBox[2].Enabled = this.label[5].Enabled = true;
                this.textBox[2].Show();
                this.label[5].Show();
                //this.label[2].Text = "";
            }catch (IndexOutOfRangeException _) {MessageBox.Show(_.Message.ToString());}
            this.checkbox.Enabled = false;
            this.checkbox.Hide();
        }


        public void unLock() {
            try {
                for (int index = 0; index < 2; index++) { button[index].Enabled = true; button[index].Show(); }
                for (int index = 0; index < 3; index++) { textBox[index].Enabled = true; textBox[index].Show(); }
                for (int index = 0; index < 5; index++) { label[index].Enabled = true; label[index].Show(); }
                if (button[2].Enabled == false && button[3].Enabled == false) { /*keep property to default*/}
                else for (int index = 2; index < 4; index++) { button[index].Enabled = false; button[index].Hide(); }
                this.textBox[2].Enabled = this.label[5].Enabled = this.label[0].Enabled  = false;
                this.textBox[2].Hide();
                this.label[0].Hide();
                this.label[5].Hide();
            }catch (IndexOutOfRangeException _) {MessageBox.Show(_.Message.ToString());}
            this.checkbox.Enabled = true;
            this.checkbox.Show();
        }


        private Button[]  button   = new Button[4];
        private TextBox[] textBox  = new TextBox[3];
        private Label[]   label    = new Label[6];
        private CheckBox  checkbox = new CheckBox();
    }
}
