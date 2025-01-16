using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio11
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
                string strIng = textBox1.Text;
                string str = strIng.Replace(" ", String.Empty).ToUpper();

                bool esPalindromo = palindromo(str, 0, str.Length - 1);

                string mensaje = esPalindromo ? $"{strIng} es un palindromo" : $"{strIng} no es un palindromo";

                label1.Text = $"{mensaje}";
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private bool palindromo(string s, int i, int j, bool esPalindromo = false)
        {
            esPalindromo = s[i].Equals(s[j]);

            if (!esPalindromo) return false;

            if (i == j || i == j - 1) return true;

            return palindromo(s, i+1, j-1, esPalindromo);
        }
    }
}
