using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THA_W7_Felicia.S
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(textBoxInput.Text);
            if (int.TryParse(textBoxInput.Text, out num) && num > 3)
            {
                Form2 form2 = new Form2(num);
                form2.Show();
            }
            else
            {
                MessageBox.Show("Please enter a valid number", "Invalid Input", MessageBoxButtons.OK);
            }
        }
    }
}
