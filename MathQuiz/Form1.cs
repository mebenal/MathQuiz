using System;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();
        int add1, add2, sub1, sub2, mul1, mul2, div1, div2, timeLeft;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congradulations!");

                // Try again
                startButton.Enabled = true;
            } else if (timeLeft > 0)
            {
                // Update seconds left
                timeLabel.Text = $"{--timeLeft} seconds";
            } else
            {
                timer1.Stop();
                timeLabel.Text = "Times up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");

                // Show correct values
                sum.Value = add1 + add2;
                difference.Value = sub1 - sub2;
                product.Value = mul1 * mul2;
                quotient.Value = div1 / div2;

                // Try again
                startButton.Enabled = true;
            }
            
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public Form1()
        {
            InitializeComponent();
            date.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }

        public void StartTheQuiz()
        {
            /*
             * Generate numbers for addition and assign them to
             * the correct labels. Set the sum to 0.
             */
            add1 = randomizer.Next(51);
            add2 = randomizer.Next(51);

            plusLeftLabel.Text = add1.ToString();
            plusRightLabel.Text = add2.ToString();

            sum.Value = 0;

            /*
             * Generate numbers for subtraction and assign them to
             * the correct labels. Set the difference to 0.
             */
            sub1 = randomizer.Next(1, 101);
            sub2 = randomizer.Next(1, sub1);
            
            minusLeftLabel.Text = sub1.ToString();
            minusRightLabel.Text= sub2.ToString();

            difference.Value = 0;

            /*
             * Generate numbers for multiplication and assign them to
             * the correct labels. Set the product to 0.
             */
            mul1 = randomizer.Next(2, 12);
            mul2 = randomizer.Next(2, 12);

            timesLeftLabel.Text = mul1.ToString();
            timesRightLabel.Text = mul2.ToString();

            product.Value = 0;

            /*
             * Generate numbers for division and assign them to
             * the correct labels. Set the quotient to 0.
             */
            div2 = randomizer.Next(1, 12);
            div1 = randomizer.Next(1, 12) * div2;

            dividedLeftLabel.Text = div1.ToString();
            dividedRightLabel.Text = div2.ToString();

            quotient.Value = 0;

            // Set time left and start timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            return (add1 + add2 == sum.Value)
                && (sub1 - sub2 == difference.Value)
                && (mul1 * mul2 == product.Value)
                && (div1 / div2 == quotient.Value);
        }
    }
}
