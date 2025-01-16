using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

    //14.Escribir una función que reciba una pila de enteros y retorne dos pilas una con
    //los números pares y otra con los impares. 

namespace Ejercicio14
{
    public partial class Form1 : Form
    {
        Pila enteros;
        Pila pares;
        Pila impares;

        public Form1()
        {
            InitializeComponent();
            enteros = new Pila();
            pares = new Pila();
            impares = new Pila();

            Llenar(enteros);
            SepararParesImpares();
        }

        private void SepararParesImpares()
        {
            Pila aux = new Pila();
            Vaciar(pares);
            Vaciar(impares);    

            while (enteros.Ver() != null)
            {
                aux.Apilar(enteros.Desapilar());
            }

            while (aux.Ver() != null)
            {
                Nodo nodo = aux.Desapilar();

                if(nodo.Valor % 2 == 0)
                {
                    pares.Apilar(new Nodo(nodo.Valor));
                }
                else
                {
                    impares.Apilar(new Nodo(nodo.Valor));
                }

                enteros.Apilar(nodo);
            }

            Mostrar(enteros, listBox1);
            Mostrar(pares, listBox2);
            Mostrar(impares, listBox3);
        }

        private void Llenar(Pila pila)
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(15, 20); i++)
            {
                pila.Apilar(random.Next(1, 100));
            }
        }

        private void Mostrar(Pila pila, ListBox listBox)
        {
            Pila aux = new Pila();
            listBox.Items.Clear();

            while (pila.Ver() != null)
            {
                aux.Apilar(pila.Desapilar());
                listBox.Items.Add(aux.Ver().Valor);
            }

            while (aux.Ver() != null)
            {
                pila.Apilar(aux.Desapilar());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Vaciar(enteros);
            Llenar(enteros);
            SepararParesImpares();
        }

        private void Vaciar(Pila pila)
        {
            while(pila.Ver() != null)
            {
                pila.Desapilar();
            }
        }
    }
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(int valor = 0)
        {
            Valor = valor; ;
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

        public void Apilar(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);

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
                return new Nodo(centinela.Siguiente.Valor);
            }

            return null;
        }
    }
}
