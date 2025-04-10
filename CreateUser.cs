using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MathGame
{
    public class CreateUser
    {
        public string note = "users.txt";

        public bool UserExists(string username)
        {
            if (!File.Exists(note)) return false;

            string[] lines = File.ReadAllLines(note);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');

                if (parts.Length == 2 && parts[0] == username)
                {
                    return true;
                }
            }

            return false;
        }

        public string GetPassword(string username)
        {
            if (!File.Exists(note)) return "";

            string[] lines = File.ReadAllLines(note);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(',');

                if (parts.Length == 2 && parts[0] == username)
                {
                    return parts[1];
                }
            }

            return "";
        }

        public bool Create(string username, string password)
        {
            if (username == "" || password == "")
            {
                MessageBox.Show("Username or password cannot be empty.");
                return false;
            }

            if (UserExists(username))
            {
                MessageBox.Show("User already exists.");
                return false;
            }

            string userRecord = username + "," + password;

            FileStream fs = new FileStream(note, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(userRecord);

            sw.Close();
            fs.Close();

            MessageBox.Show("New user was added.");

            return true;
        }
    }
}
