using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio9;

/*
    12. Realizar un programa que utilizando pilas logre invertir una palabra ingresada
    por el usuario.
 */

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
                string palabra = textBox1.Text;

                if (string.IsNullOrWhiteSpace(palabra)) throw new Exception("Ingrese una palabra!");

                InvertirPalabra(palabra);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void InvertirPalabra(string palabra)
        {
            Pila palabraInvertida = new Pila();

            for (int i = 0; i < palabra.Length; i++)
            {
                palabraInvertida.Apilar(palabra[i].ToString());
            }

            MostrarPila(palabraInvertida);
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