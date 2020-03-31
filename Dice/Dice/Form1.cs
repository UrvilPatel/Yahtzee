using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Globals.Dice[0] = 11;
            //Globals.Dice[1] = 111;
            //Globals.Dice[2] = 211;
            //Globals.Dice[3] = 311;
            //Globals.Dice[4] = 411;
        }
        public static class Globals
        {
            public static int RollCounter = 0; // this shows that the roll counter will start at 0
            public static int[] Dice = new int[5]; //int 5 is the integer therefore there are 5 numbers generated
             //int One = 0;
             //int Two = 0;
             //int Three = 0;
             //int Four = 0;
             //int Five = 0;
             //int Six = 0;
        }

        private void lblDie2_Click(object sender, EventArgs e)
        {

        }

        private void btnRoll_Click(object sender, EventArgs e)
        {
            Random random = new Random(); //this generates a random number

            Globals.RollCounter += 1; //roll counter is increased by one and rounded to the nearest whole number
            if (Globals.RollCounter == 3) // is the roll button has been pressed 3 times then the roll button is disabled
            {
                btnRoll.Enabled = false; //if the roll button is enabled 3 times then it is then disabled
            }

            if (chk1.Checked == false) //if this box is checked then the number can not be changed, if it is not checked then another number is randomly generated
            {
                Globals.Dice[0] = random.Next(1, 7);
                lblDie1.Text = Convert.ToString(Globals.Dice[0]);
            }
            if (chk2.Checked == false)
            {
                Globals.Dice[1] = random.Next(1, 7);
                lblDie2.Text = Convert.ToString(Globals.Dice[1]);
            }
            if (chk3.Checked == false)
            {
                Globals.Dice[2] = random.Next(1, 7);
                lblDie3.Text = Convert.ToString(Globals.Dice[2]);
            }
            if (chk4.Checked == false)
            {
                Globals.Dice[3] = random.Next(1, 7);
                lblDie4.Text = Convert.ToString(Globals.Dice[3]);
                //the 4th dice will generate a random number which is between 1 and 6
            }
            if (chk5.Checked == false)
            {
                Globals.Dice[4] = random.Next(1, 7);
                lblDie5.Text = Convert.ToString(Globals.Dice[4]);
                //the 5th dice will randomly generate a number betwwen 1 and 6 if the 5th box is not checked
            }

            lblRollCounter.Text = Convert.ToString(Globals.RollCounter);
        }

        private void btnEndRoll_Click(object sender, EventArgs e)
        {
            lblDie1.Text = "-";
            lblDie2.Text = "-";
            lblDie3.Text = "-";
            lblDie4.Text = "-";
            lblDie5.Text = "-";
            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;
            chk4.Checked = false;
            chk5.Checked = false;
            btnRoll.Enabled = true;
            lblRollCounter.Text = "0";
            Globals.RollCounter = 0;
        }

        private void btn3k_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[1] == Globals.Dice[2] ||
            Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[2] == Globals.Dice[3] ||
            Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[3] == Globals.Dice[4])
                lbl3k.Text = Convert.ToString(Globals.Dice[0] + Globals.Dice[1] + Globals.Dice[2] + Globals.Dice[3] + Globals.Dice[4]);
            //this is the criteria for 3 of a kind          
            else lbl3k.Text = "0";
            btn3k.Enabled = false;
            btnEndRoll.PerformClick();
        }

        private void btn4k_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[2] == Globals.Dice[3] ||
            Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[3] == Globals.Dice[4])
                lbl4k.Text = Convert.ToString(Globals.Dice[0] + Globals.Dice[1] + Globals.Dice[2] + Globals.Dice[3] + Globals.Dice[4]);
            //this is the criteria required for a 4 of a kind
            else lbl4k.Text = "0";
            btn4k.Enabled = false;
            btnEndRoll.PerformClick();
        }

        private void btnFH_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[3] == Globals.Dice[4] ||
            Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[3] == Globals.Dice[4])
                lblFH.Text = Convert.ToString(25);
            // need to add total into the LHTotal
            //criteria for full house
            else lblFH.Text = "0";
            btnFH.Enabled = false;
            btnEndRoll.PerformClick();
        }

        private void btnSS_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[2] == Globals.Dice[1] + 1 && Globals.Dice[3] == Globals.Dice[2] + 1 && Globals.Dice[4] == Globals.Dice[3] + 1 ||
                Globals.Dice[0] == Globals.Dice[1] - 1 && Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[3] == Globals.Dice[2] + 1 && Globals.Dice[4] == Globals.Dice[3] + 1 ||
                Globals.Dice[0] == Globals.Dice[1] - 1 && Globals.Dice[1] == Globals.Dice[0] + 1 && Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[4] == Globals.Dice[3] + 1 ||
                Globals.Dice[0] == Globals.Dice[1] - 1 && Globals.Dice[1] == Globals.Dice[0] + 1 && Globals.Dice[2] == Globals.Dice[1] + 1 && Globals.Dice[3] == Globals.Dice[4] ||
                Globals.Dice[0] == Globals.Dice[1] - 1 && Globals.Dice[1] == Globals.Dice[0] + 1 && Globals.Dice[2] == Globals.Dice[1] + 1 && Globals.Dice[3] == Globals.Dice[2] + 1 && Globals.Dice[4] == Globals.Dice[3] + 1)
                lblSS.Text = Convert.ToString(30);
            //criteria for short straight
            else lblSS.Text = "0";
            btnSS.Enabled = false;
            btnEndRoll.PerformClick();
        }

        private void btnLS_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[1] == Globals.Dice[0] + 1 && Globals.Dice[2] == Globals.Dice[1] + 1 && Globals.Dice[3] == Globals.Dice[2] + 1 && Globals.Dice[4] == Globals.Dice[3] + 1)
                lblLS.Text = Convert.ToString(40);
            //criteria for long straight
            else lblLS.Text = "0";
            btnLS.Enabled = false;
            btnEndRoll.PerformClick();
        }

        private void btnY_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[3] == Globals.Dice[4])
                lblY.Text = Convert.ToString(50);
            //criteria for a yahtzee
            else lblY.Text = "0";
            btnY.Enabled = false;
            btnBY.Enabled = true;
            btnEndRoll.PerformClick();
        }

        private void btnCh_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            lblCh.Text = Convert.ToString(Globals.Dice[0] + Globals.Dice[1] + Globals.Dice[2] + Globals.Dice[3] + Globals.Dice[4]);
            btnCh.Enabled = false;
            btnEndRoll.PerformClick();
        }

        private void btnBY_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[3] == Globals.Dice[4])
                lblY.Text = Convert.ToString(100);
            //criteria for a bonus yahtzee
            else lblBY.Text = "0";
            btnBY.Enabled = false;
            btnEndRoll.PerformClick();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice)
            {
                if (i == 1)
                {
                    Globals.One += 1;
                    lbl1.Text = Convert.ToString(Globals.One);
                    btn1.Enabled = false;
                }
             

            }

            btn1.Enabled = false;

            btnEndRoll.PerformClick();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice)
            {
                if (i == 2)
                {
                    Globals.Two += 2;
                    lbl2.Text = Convert.ToString(Globals.Two);
                    btn2.Enabled = false;
                }
              

            }

            btn2.Enabled = false;

            btnEndRoll.PerformClick();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice)
            {
                if (i == 3)
                {
                    Globals.Three += 3;
                    lbl3.Text = Convert.ToString(Globals.Three);
                    btn3.Enabled = false;
                }
               

            }

            btn3.Enabled = false;

            btnEndRoll.PerformClick();
        }

        private void btn4_Click(object sender, EventArgs e)
        {

            foreach (int i in Globals.Dice)
            {
                if (i == 4)
                {
                    Globals.Four += 4;
                    lbl4.Text = Convert.ToString(Globals.Four);
                    btn4.Enabled = false;
                }
              

            }

            btn4.Enabled = false;

            btnEndRoll.PerformClick();

        }

        public void btn5_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice)
            {
                if (i == 5)
                {
                    Globals.Five += 5;
                    lbl5.Text = Convert.ToString(Globals.Five);
                    btn5.Enabled = false;
                }
               

            }

            btn5.Enabled = false;

            btnEndRoll.PerformClick();
        }

        public void btn6_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice)
            {
                if (i == 6)
                {
                    Globals.Six += 6;
                    lbl6.Text = Convert.ToString(Globals.Six);
                    btn6.Enabled = false;
                }
               

            }

            btn6.Enabled = false;

            btnEndRoll.PerformClick();
        }

        public void btnUHT_Click(object sender, EventArgs e)
        {
            int uhb = 0;
            try
            {
                int u1 = int.Parse(lbl1.Text);
                int u2 = int.Parse(lbl2.Text);
                int u3 = int.Parse(lbl3.Text);
                int u4 = int.Parse(lbl4.Text);
                int u5 = int.Parse(lbl5.Text);
                int u6 = int.Parse(lbl6.Text);
                int uht = u1 + u2 + u3 + u4 + u5 + u6;
                lblUHT.Text = Convert.ToString(uht);

                if(uht>=63)
                {
                    uhb = 35;
                    lblUHB.Text = Convert.ToString(uhb);
                }
                else
                {
                    lblUHB.Text = Convert.ToString(uhb);
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine("Exception:" + e1);
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLHT_Click(object sender, EventArgs e)
        {
            try
            {
                int l1 = int.Parse(lbl3k.Text);
                int l2 = int.Parse(lbl4k.Text);
                int l3 = int.Parse(lblFH.Text);
                int l4 = int.Parse(lblSS.Text);
                int l5 = int.Parse(lblLS.Text);
                int l6 = int.Parse(lblCh.Text);
                int l7 = int.Parse(lblY.Text);
                int l8 = int.Parse(lblBY.Text);
                int lht = l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8;
                lblLHT.Text = Convert.ToString(lht);

           
            }
            catch (Exception e1)
            {
                Console.WriteLine("Exception:" + e1);
            }

        }

        private void btnGT_Click(object sender, EventArgs e)
        {
            try
            {
                int uht = Convert.ToInt32(lblUHT.Text);
                int lht = Convert.ToInt32(lblLHT.Text);
                int uhb = Convert.ToInt32(lblUHB.Text);
               
                int gt = 0;

                if (uht >= 0 && uhb >= 0 && lht >= 0)
                {
                    gt = uht + uhb + lht;
                    lblGT.Text = Convert.ToString(gt);
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine("Exception : "+e1);
            }
        }
    }

   
}
