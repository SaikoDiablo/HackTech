using System;
using System.Windows.Forms;

namespace MathGame
{
    public partial class Form2 : Form
    {
        private MathGameEngine game;
        private Timer timer;
        private int secondsTaken;

        public Form2()
        {
            InitializeComponent();
            game = new MathGameEngine();
            SetupTimer();
            DisplayQuestion();

            textBox1.Enabled = false;
        }

        private void SetupTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            secondsTaken++;
            label4.Text = "Time: " + secondsTaken + " sec";
        }

        private void DisplayQuestion()
        {
            label2.Text = $"{game.Number1} {game.Operator} {game.Number2}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "START")
            {
                secondsTaken = 0;
                textBox1.Enabled = true;
                textBox1.Clear();
                textBox1.Focus();
                DisplayQuestion();
                timer.Start();
                button1.Text = "STOP";
            }
            else
            {
                timer.Stop();
                textBox1.Enabled = false;
                button1.Text = "START";
                MessageBox.Show("Game stopped.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!textBox1.Enabled) return;

            if (int.TryParse(textBox1.Text, out int userAnswer))
            {
                if (game.CheckAnswer(userAnswer))
                {
                    timer.Stop();
                    listBox1.Items.Add($"Answered in {secondsTaken} seconds");
                    secondsTaken = 0;
                    label4.Text = "Time: 0 sec";
                    textBox1.Clear();
                    DisplayQuestion();
                    game.GenerateNewQuestion();
                    timer.Start();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}
