using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio5
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
                int desde = int.Parse(textBox2.Text);

                label1.Text = $"Resultado: {sumaHasta(n, desde)}";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int sumaHasta(int n, int desde)
        {
            if (n == 0) return 0;

            desde = desde + sumaHasta(n - 1, desde + 1);

            return desde;
        }
    }
}
