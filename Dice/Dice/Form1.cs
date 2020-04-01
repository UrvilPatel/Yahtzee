using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            Globals.Dice[0] = 11;//removes any errors the occur within the code
            Globals.Dice[1] = 111;
            Globals.Dice[2] = 211;
            Globals.Dice[3] = 311;
            Globals.Dice[4] = 411;

            btnBY.Enabled = false;// the yahtzee bonus button is disabled

        }
        public static class Globals
        {
            public static int RollCounter = 0; // this shows that the roll counter will start at 0
            public static int[] Dice = new int[5]; //int 5 is the integer therefore there are 5 numbers generated
            public static int One = 0; 
            public static int Two = 0;
            public static int Three = 0;
            public static int Four = 0;
            public static int Five = 0;
            public static int Six = 0;
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
                Globals.Dice[0] = random.Next(1, 7);//a random number is selected onto the first dice
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
            //when the end roll button is pressed all the labels will reset
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
            //when end roll button is pressed all the labels will reset

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn3k_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);//the dice are sorted
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[1] == Globals.Dice[2] || 
            Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[2] == Globals.Dice[3] ||
            Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[3] == Globals.Dice[4]) //3 of kind criteria
                lbl3k.Text = Convert.ToString(Globals.Dice[0] + Globals.Dice[1] + Globals.Dice[2] + Globals.Dice[3] + Globals.Dice[4]); 
            //this is the criteria for 3 of a kind          
            else lbl3k.Text = "0";// if it is not fulfilled the label will be 0
            btn3k.Enabled = false; // the 3 of a kind button is disabled
            btnEndRoll.PerformClick();//Dice is reset
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
            //if the criteria is not fullfilled than it will disable the button
        }

        private void btnFH_Click(object sender, EventArgs e)
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[3] == Globals.Dice[4]||
            Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[3] == Globals.Dice[4])
                lblFH.Text = Convert.ToString(25);
            // need to add total into the Lower House Total
            //criteria for full house
            else lblFH.Text = "0";// if the criteria required is not fulfilled then the Full house button will be disabled
            btnFH.Enabled = false;
            btnEndRoll.PerformClick();            
        }

        private void btnSS_Click(object sender, EventArgs e)//code this again according to the new algorithm
        {
            Array.Sort(Globals.Dice);
            if (Globals.Dice[0] == Globals.Dice[1] && Globals.Dice[2] == Globals.Dice[1] + 1 && Globals.Dice[3] == Globals.Dice[2] + 1 && Globals.Dice[4] == Globals.Dice[3] + 1||
                Globals.Dice[0] == Globals.Dice[1] - 1 && Globals.Dice[1] == Globals.Dice[2] && Globals.Dice[3] == Globals.Dice[2] + 1 && Globals.Dice[4] == Globals.Dice[3] + 1||
                Globals.Dice[0] == Globals.Dice[1] - 1 && Globals.Dice[1] == Globals.Dice[0] + 1 && Globals.Dice[2] == Globals.Dice[3] && Globals.Dice[4] == Globals.Dice[3] + 1||
                Globals.Dice[0] == Globals.Dice[1] - 1 && Globals.Dice[1] == Globals.Dice[0] + 1 && Globals.Dice[2] == Globals.Dice[1] + 1 && Globals.Dice[3] == Globals.Dice[4]||
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
            else lblLS.Text = "0"; //if criteria is not met the label will have a 0
            btnLS.Enabled = false;
            btnEndRoll.PerformClick(); //resets the dice when endroll button is pressed

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
            foreach (int i in Globals.Dice) // every integer in the dice will go through this
            {
               if (i == 1)//if the integer is 1
               {
                    Globals.One += 1; //adds sum of ones
                    lbl1.Text = Convert.ToString(Globals.One); //the summ will be added on lbl1
                    btn1.Enabled = false; //the count of one button is disabled
               }
                            
            }

            btn1.Enabled = false;

            btnEndRoll.PerformClick(); //end roll button is reset
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice) // every integer in the dice will go through this
            {
                if (i == 2) //if the integer is 2
                {
                    Globals.Two += 2; // the sum of 2s 
                    lbl2.Text = Convert.ToString(Globals.Two);// sum will be added onto lbl2
                    btn2.Enabled = false;//btn2 is disabled 
                }

            }

            btn2.Enabled = false;

            btnEndRoll.PerformClick();//end roll button is reset
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice)// every integer in the dice will go through this
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
            foreach (int i in Globals.Dice)// every integer in the dice will go through this
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

        private void btn5_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice)// every integer in the dice will go through this
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

        private void btn6_Click(object sender, EventArgs e)
        {
            foreach (int i in Globals.Dice)// every integer in the dice will go through this
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

        private void btnUHT_Click(object sender, EventArgs e)
        {
            int uhb = 0;
            try
            {
                int u1 = int.Parse(lbl1.Text); // this indicates that u1 is a variable storing the information of label 1
                int u2 = int.Parse(lbl2.Text);
                int u3 = int.Parse(lbl3.Text);
                int u4 = int.Parse(lbl4.Text);
                int u5 = int.Parse(lbl5.Text);
                int u6 = int.Parse(lbl6.Text);
                int uht = u1 + u2 + u3 + u4 + u5 + u6; // all the six labels are added into the upper house total
                lblUHT.Text = Convert.ToString(uht);

                if (uht >= 63) // if the upper house total is 63 or more  
                {
                    uhb = 35; //then 35 will be added to the upper house total
                    lblUHB.Text = Convert.ToString(uhb); //new variable 
                }
                else
                {
                    lblUHB.Text = Convert.ToString(uhb); //if the condition is not fullfilled then no bonus points 
                }
            }
            catch (Exception e1) //this handles the exception that occurs in the programe
            {
                Console.WriteLine("Exception:" + e1); //it goes into the console to allow us to edit it
            }
        }

        private void btnLHT_Click(object sender, EventArgs e)
        {
            try
            {
                int l1 = int.Parse(lbl3k.Text); // l1 is a variable which stores the information from the 3 of a kind label
                int l2 = int.Parse(lbl4k.Text); // this is the key - 12 is a short form for the 4 of a kind label
                int l3 = int.Parse(lblFH.Text); // this is the key - 13 is a short form for the 3 of a kind label
                int l4 = int.Parse(lblSS.Text);
                int l5 = int.Parse(lblLS.Text);
                int l6 = int.Parse(lblCh.Text);
                int l7 = int.Parse(lblY.Text);
                int l8 = int.Parse(lblBY.Text);
                int lht = l1 + l2 + l3 + l4 + l5 + l6 + l7 + l8; // sum of all variables 
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
                int uht = Convert.ToInt32(lblUHT.Text);//it converts the text value into the integer value for further addition
                int lht = Convert.ToInt32(lblLHT.Text);//
                int uhb = Convert.ToInt32(lblUHB.Text);//

                int gt = 0;//answer stored into gt (grand total) value

                if (uht >= 0 && uhb >= 0 && lht >= 0)//value has to be 0 or more 
                {
                    gt = uht + uhb + lht; // the values are added and stored into the gt
                    lblGT.Text = Convert.ToString(gt);//the stored information is converted into the grand total label
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("Exception : " + e1);
            }
        }
    }
}