using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W7_Felicia.S
{
    public partial class Form2 : Form
    {
        public Button[,] button;
        int input;
        string[] keyboard;
        int x = 350;
        int y = 50;
        int a = 0;
        int b = 0;
        string jawaban = "";
        List<string> words = new List<string>();
        public Form2(int numTries)
        {
            InitializeComponent();
            input = numTries;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string list = "Wordle Word List.txt";
            string[] word = File.ReadAllLines(list);
            foreach (string a in word)
            {
                words.AddRange(a.Split(','));
            }
            jawaban = words[new Random().Next(words.Count)];
            
            button = new Button[5, input];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    button[i, j] = new Button();
                    button[i, j].Location = new Point(50 * (i + 1), 50 * (j + 1));
                    button[i, j].Size = new Size(50, 50);
                    button[i, j].BackColor = Color.Transparent;
                    this.Controls.Add(button[i, j]);
                }
            }
            keyboard = new string[28] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Enter", "Z", "X", "C", "V", "B", "N", "M", "Delete" };
            foreach (string a in keyboard)
            {
                Button kibor = new Button();
                if (a == "A")
                {
                    x = 375;
                    y = y + 50;
                }
                else if (a == "Enter")
                {
                    x = 355;
                    y = y + 50;
                }
                kibor.Location = new Point(x, y);
                if (a == "Enter")
                {
                    kibor.Click += buttonEnter_Click;
                    kibor.Size = new Size(70, 50);
                    x += 70;
                }
                else if (a == "Delete")
                {
                    kibor.Click += buttonDelete_Click;
                    kibor.Size = new Size(70, 50);
                    x += 70;
                }
                else
                {
                    kibor.Size = new Size(50, 50);
                    x += 50;
                    kibor.Click += kibor_Click;
                }
                kibor.Text = a;
                this.Controls.Add(kibor);
            }
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            int menang = 0;
            string kata = "";
            if (a != 5)
            {
                MessageBox.Show("Character must be 5");
            }
            else if (a == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    kata += button[i, b].Text;
                }
                if (!words.Contains(kata.ToLower()))
                {
                    MessageBox.Show("Word is not exist");
                }
                else
                {
                    b++;
                    int j = 0;
                    menang = 0;
                    foreach (char a in kata)
                    {
                        if (jawaban.Contains(a.ToString().ToLower()))
                        {
                            button[j, b - 1].BackColor = Color.Yellow;
                            if (a.ToString().ToLower() == jawaban[j].ToString())
                            {
                                button[j, b - 1].BackColor = Color.LightGreen;
                                menang++;
                            }
                        }
                        j++;
                    }
                    a = 0;
                }
            }

            if (menang == 5)
            {
                MessageBox.Show("YOU WIN!!");
            }
            else if (b == input && menang < 5)
            {
                MessageBox.Show("YOU LOSE, the word is " + jawaban);
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (a > 0)
            {
                a--;
                button[a, b].Text = "";
            }
        }
        private void kibor_Click(object sender, EventArgs e)
        {
            var klik = sender as Button;
            if (a != 5)
            {
                button[a, b].Text = klik.Text;
                a++;
            }
        }
    }
}
