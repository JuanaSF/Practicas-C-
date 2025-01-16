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

    //15.Realizar un programa que constituya una cola e implemente las acciones de
    //encolar, desencolar y mirar el elemento a desencolar.

namespace Ejercicio15
{
    public partial class Form1 : Form
    {
        Cola cola;
        public Form1()
        {
            InitializeComponent();
            cola = new Cola();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cola.Encolar(Interaction.InputBox("Ingrese el ID: "));
                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Mostrar()
        {
            Cola aux = new Cola();
            listBox1.Items.Clear();

            while (cola.Ver() != null)
            {
                Nodo nAux = cola.Desencolar();
                listBox1.Items.Add(nAux.Id);
                aux.Encolar(nAux);
            }

            cola = aux;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cola.Ver() == null) throw new Exception("No hay nodos para desencolar!!");
                MessageBox.Show($"Se desencolo el nodo con ID: {cola.Desencolar().Id}");
                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (cola.Ver() == null) throw new Exception("No hay nodos para ver!!");
                MessageBox.Show($"El nodo que sera desencolado es --> ID: {cola.Ver().Id}");
                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    public class Cola
    {
        Nodo centinelaP;
        Nodo centinelaU;

        public Cola()
        {
            centinelaP = new Nodo();
            centinelaU = new Nodo();
        }

        public void Encolar(string id)
        {
            Nodo nuevoNodo = new Nodo(id);

            if (centinelaP.Siguiente == null)
            {
                centinelaP.Siguiente = nuevoNodo;
            }
            else
            {
                centinelaU.Siguiente.Siguiente = nuevoNodo;
            }

            centinelaU.Siguiente = nuevoNodo;
        }

        public void Encolar(Nodo nuevoNodo)
        {
            if (centinelaP.Siguiente == null)
            {
                centinelaP.Siguiente = nuevoNodo;
            }
            else
            {
                centinelaU.Siguiente.Siguiente = nuevoNodo;
            }

            centinelaU.Siguiente = nuevoNodo;
        }

        public Nodo Desencolar()
        {
            Nodo aDesencolar = centinelaP.Siguiente;
            if (aDesencolar != null)
            {
                Nodo Aux = centinelaP.Siguiente.Siguiente;
                aDesencolar.Siguiente = null;
                centinelaP.Siguiente = Aux;

                if (centinelaP.Siguiente == null) centinelaU.Siguiente = null;
            }

            return aDesencolar;
        }

        public Nodo Ver()
        {
            if (centinelaP.Siguiente == null) return null;
            return new Nodo(centinelaP.Siguiente.Id);
        }
    }

    public class Nodo
    {
        public string Id { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(string id = "")
        {
            Id = id;
            Siguiente = null;
        }
    }
}
