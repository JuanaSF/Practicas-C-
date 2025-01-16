using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio12
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
                int x = int.Parse(textBox1.Text);

                int res = f(x);

                label1.Text = res.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int f(int x)
        {
            if (x > 100)
            {
                return (x - 10);
            }
            else
            {
                return f(f(x + 11));
            }
        }
    }
}
