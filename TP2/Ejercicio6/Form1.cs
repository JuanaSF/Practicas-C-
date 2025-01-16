using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio6
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
                int res = sumaParesDesde(int.Parse(textBox1.Text));

                label1.Text = res == 0 ? "Error. Ingrese un numero par" : res.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private int sumaParesDesde(int desde)
        {
            if (desde % 2 != 0)
            {
                return 0;
            }

            if (desde == 0) return 0;

            desde += sumaParesDesde(desde - 2);

            return desde;
        }
    }
}
