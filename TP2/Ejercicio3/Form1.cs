using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
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
                int n = int.Parse(textBox1.Text);
                int p = int.Parse(textBox2.Text);  

                label1.Text = potencia(n, p).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int potencia(int n, int p)
        {
            int r = 1;

            if (p == 0) return r;
            else r = n * potencia(n, p-1);

            return r;
        }
    }
}
