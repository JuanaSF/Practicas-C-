using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio8
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
                mayusculas(textBox1.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void mayusculas(string s, int i = 0)
        {
            if (i == s.Length) return;

            char c;

            if(i == 0 || (i > 0 && s[i-1].Equals(' ')))
            {
                c = s.ToUpper()[i];
            }
            else
            {
                c = s[i];
            }

            label1.Text += $"{c}";

            mayusculas(s, i+1);
        }
    }
}
