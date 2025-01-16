using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> x = textBox1.Text.Split(',').ToList();
                List<string> y = textBox2.Text.Split(',').ToList();

                textBox3.Text = String.Empty;

                aparear(x, y);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void aparear(List<string> x, List<string> y, int i = 0)
        {
            if(x.Count != y.Count)
            {
                textBox3.Text = "Estas dos listas no se pueden aparear!";
                return;
            }

            if (i == x.Count) return;

            textBox3.Text += $"({x[i]} , {y[i]}) {Environment.NewLine}";

            aparear(x, y, i + 1);
        }
    }
}
