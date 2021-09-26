using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class MathQuiz : Form
    {
        //generates random number into variable randomizer
        Random randomizer = new Random();

        //variables to hold random number for addition
        int addend1;
        int addend2;

        //variables to hold random number for subtraction
        int minuend;
        int subtrahend;

        //variables to hold random number for multiplication
        int multiplicend;
        int multiplier;

        //variables to hold random number for division
        int dividend;
        int divisor;

        //remaining time variable
        int timeLeft;


        //function to prep and start the quiz
        public void StartTheQuiz()
        {
            //sets current date
            currentDate.Text = getDate();

            //generate random numbers for each addition variable
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //display the random number by converting to a string
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            sum.Value = 0;

            //generate and display subtraction problem.
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //generate and display multiplication problem.
            multiplicend = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicend.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //generate and display division problem.
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;


            // timer start
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        //function to check if answers correct
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value) 
                && (minuend - subtrahend == difference.Value)
                &&(multiplicend * multiplier == product.Value)
                &&(dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }



        public MathQuiz()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeLabel.BackColor = Color.White;
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                    "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";

                if (timeLeft <= 5)
                    timeLabel.BackColor = Color.Red;
                else if (timeLeft <= 10)
                    timeLabel.BackColor = Color.Yellow;
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicend * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void sum_Enter(object sender, EventArgs e)
        {
            //auto select current number in slot to overwrite
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void difference_Enter(object sender, EventArgs e)
        {
            //auto select current number in slot to overwrite
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void product_Enter(object sender, EventArgs e)
        {
            //auto select current number in slot to overwrite
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void quotient_Enter(object sender, EventArgs e)
        {
            //auto select current number in slot to overwrite
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (addend1 + addend2 == sum.Value)
            {
                SystemSounds.Exclamation.Play();
            }

        }

        private void difference_ValueChanged(object sender, EventArgs e)
        {
            if (minuend - subtrahend == difference.Value)
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void product_ValueChanged(object sender, EventArgs e)
        {
            if (multiplicend * multiplier == product.Value)
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private void quotient_ValueChanged(object sender, EventArgs e)
        {
            if (dividend / divisor == quotient.Value)
            {
                SystemSounds.Exclamation.Play();
            }
        }

        private string getDate()
        {
            DateTime dt = DateTime.Parse(DateTime.Now.ToString());
            return ($"{dt:d MMMM, yyyy}");
        }

        private void currentDate_Click(object sender, EventArgs e)
        {

        }
    }
}
