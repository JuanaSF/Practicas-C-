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

/*
    9. Realizar un programa que constituya una pila e implemente las acciones de
    apilar, desapilar y mirar el elemento a desapilar.
 */

namespace Ejercicio9
{
    public partial class Form1 : Form
    {
        Pila pila;

        public Form1()
        {
            InitializeComponent();
            pila = new Pila();
            listBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Interaction.InputBox("Ingrese Id: ");
                pila.Apilar(id);
                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Mostrar()
        {
            Pila aux = new Pila();
            listBox1.Items.Clear();

            while (pila.Ver() != null)
            {
                aux.Apilar(pila.Desapilar());
                listBox1.Items.Add(aux.Ver().Id);
            }

            while (aux.Ver() != null)
            {
                pila.Apilar(aux.Desapilar());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Nodo d = pila.Desapilar();
                if (d == null)
                {
                    MessageBox.Show("No hay nodos para desapilar !!!");
                }
                else
                {
                    MessageBox.Show($"Se desapiló el Nodo --> Id: {d.Id}");
                }
                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Nodo d = pila.Ver();
                if (d == null)
                {
                    MessageBox.Show("No hay nodos para ver !!!");
                }
                else
                {
                    MessageBox.Show($"El Nodo que está para ser desapilado es --> Id: {d.Id}");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    public class Nodo
    {
        public string Id { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(string id = "")
        {
            Id = id; ;
            Siguiente = null;
        }
    }

    public class Pila
    {
        Nodo centinela;

        public Pila()
        {
            centinela = new Nodo();
        }

        public void Apilar(string id)
        {
            Nodo nuevoNodo = new Nodo(id);

            nuevoNodo.Siguiente = centinela.Siguiente;
            centinela.Siguiente = nuevoNodo;
        }

        public void Apilar(Nodo nuevoNodo)
        {
            nuevoNodo.Siguiente = centinela.Siguiente;
            centinela.Siguiente = nuevoNodo;
        }

        public Nodo Desapilar()
        {
            Nodo desapilado = centinela.Siguiente;
            if (centinela.Siguiente != null)
            {
                Nodo aux = desapilado.Siguiente;
                desapilado.Siguiente = null;
                centinela.Siguiente = aux;
            }

            return desapilado;
        }

        public Nodo Ver()
        {
            if (centinela.Siguiente != null)
            {
                return new Nodo(centinela.Siguiente.Id);
            }

            return null;
        }
    }
}
