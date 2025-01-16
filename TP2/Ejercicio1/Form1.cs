using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
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
                label1.Text = suma(int.Parse(textBox1.Text)).ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int suma(int n)
        {
            int res = 0;

            if(n == 0) return 0;
            else res = n + suma(n-1);

            return res;
        }
    }
}
