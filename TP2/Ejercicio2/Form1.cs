using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
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
                label1.Text = string.Empty;
                pares(int.Parse(textBox1.Text));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int pares(int n)
        {
            int x = 0;

            if(n == 0) return x;
            else x = x+2 + pares(n-1);

            label1.Text += $"{x}    ";

            return x;
        }
    }
}
