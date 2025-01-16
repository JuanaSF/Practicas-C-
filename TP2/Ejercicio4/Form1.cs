using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio4
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
                label1.Text = String.Empty;

                fibonacci(int.Parse(textBox1.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void fibonacci(int n, int a = 0, int b = 1)
        {
            if (n == 0) return;

            label1.Text += $"{a}   ";

            fibonacci(n - 1, b, a+b); 
        }
    }
}
