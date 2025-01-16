using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Ejercicio9;

/*
    11. Realizar un programa que utilizando pilas logre invertir un número ingresado
    por el usuario.
 */

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
                string num = textBox1.Text;

                if (!Information.IsNumeric(num)) throw new Exception("Ingrese un numero!");

                InvertirNumero(num);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void InvertirNumero(string num)
        {
            Pila numInvertido = new Pila();

            for(int i = 0; i < num.Length; i++)
            {
                numInvertido.Apilar(num[i].ToString());
            }

            MostrarPila(numInvertido);
        }

        private void MostrarPila(Pila pila)
        {
            while (pila.Ver() != null)
            {
                label1.Text += pila.Desapilar().Id;
            }
        }
    }
}
