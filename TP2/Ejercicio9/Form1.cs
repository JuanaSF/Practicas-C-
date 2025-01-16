using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = String.Empty;
            List<char> c = new List<char>();
            decimalABinario(c, int.Parse(textBox1.Text));

            label1.Text = new string(c.ToArray());
        }

        private void decimalABinario(List<char> binario, int n)
        {
            int x = n % 2;
            binario.Insert(0, char.Parse(x.ToString()));

            if (n < 2) return;
            
            decimalABinario(binario, n / 2);
        }
    }
}
