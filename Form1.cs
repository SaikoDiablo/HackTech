using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MathGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text; string password = textBox2.Text;
            CreateUser user = new CreateUser();
            if (username.Trim() == "" || password.Trim() == "")
            {
                MessageBox.Show("Please enter both username and password."); return;
            }
            if (user.UserExists(username))
            {
                string correctPassword = user.GetPassword(username);
                if (password == correctPassword)
                {
                    MessageBox.Show("Login successful!");
                    textBox1.Clear(); textBox2.Clear();
                    Form2 frm = new Form2();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Incorrect password.");
                }
            }
            else
            {
                MessageBox.Show("User does not exist. Please create a new user first.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            CreateUser user = new CreateUser();

            if (username.Trim() == "")
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            if (user.UserExists(username))
            {
                string foundPassword = user.GetPassword(username);

                if (password == "" || password.Trim() == "")
                {
                    MessageBox.Show($"Your password is: {foundPassword}");
                }
                else
                {
                    MessageBox.Show($"This username is already taken. You cannot create the same user. Your name is {username}. Your password is {foundPassword}.");
                }
            }
            else
            {
                if (password == "" || password.Trim() == "")
                {
                    MessageBox.Show("User not found. Please enter a password to create new user.");
                    return;
                }

                if (user.Create(username, password))
                {
                    MessageBox.Show("User created successfully.");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Either your username nor password is wrong.");
                }
            }       
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
