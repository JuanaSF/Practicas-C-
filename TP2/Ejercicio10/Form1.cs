using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio10
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
                string binario = textBox1.Text;
                int dec = binarioADecimal(binario, binario.Length-1);

                label1.Text = $"{dec}";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int binarioADecimal(string bin, int p, int i = 0)
        {
            int r;

            if (p == 0) return int.Parse(bin[i].ToString());

            int a = int.Parse(bin[i].ToString());

            r = a * (int) Math.Pow(2, p) + binarioADecimal(bin, p - 1, i+1);

            return r;
        }
    }
}
