using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//13.Desarrollar los siguientes algoritmos, utilizando sólo las operaciones primitivas
//de pila:
//a.Imprimir el contenido de una pila de enteros sin cambiar su contenido.
//b. Colocar en el fondo de una pila un nuevo elemento.
//c. Calcular el número de elementos de una pila sin modificar su contenido.
//d. Eliminar de una pila todas las ocurrencias de un elemento dado.
//e. Intercambiar los valores del tope y el fondo de una pila.
//f. Duplicar el contenido de una pila.
//g. Verificar si el contenido de una pila de caracteres es un palíndromo.
//h. Calcular la suma de una pila de enteros sin modificar su contenido.
//i. Calcular el máximo de una pila de números reales. 

namespace Ejercicio13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Pila pila1;
        Pila pila2;

        public class Pila
        {
            Nodo centinela;
            public Pila()
            {
                centinela = new Nodo();
            }
            public void Apilar(int tam)
            {
                Nodo aux = new Nodo(tam);
                if (centinela.Siguiente == null)
                {
                    centinela.Siguiente = aux;
                }
                else
                {
                    aux.Siguiente = centinela.Siguiente;
                    centinela.Siguiente = aux;
                }
            }
            public void Apilar(Nodo pNodo)
            {
                Nodo aux = pNodo;
                if (centinela.Siguiente == null)
                {
                    centinela.Siguiente = aux;
                }
                else
                {
                    aux.Siguiente = centinela.Siguiente;
                    centinela.Siguiente = aux;
                }
            }
            public Nodo Desapilar()
            {
                Nodo nodoRta = centinela.Siguiente;
                if (centinela.Siguiente != null)
                {
                    Nodo aux = nodoRta.Siguiente;
                    nodoRta.Siguiente = null;
                    centinela.Siguiente = aux;
                }
                return nodoRta;
            }
            public Nodo Ver()
            {
                Nodo nodoRta = null;
                if (centinela.Siguiente != null)
                {
                    nodoRta = new Nodo(centinela.Siguiente.Tam);
                }
                return nodoRta;
            }
        }
        public class Nodo
        {
            public Nodo(int intTam = 0) { Tam = intTam; Siguiente = null; }
            public int Tam { get; }
            public Nodo Siguiente { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pila1 = new Pila();
            pila2 = new Pila();
        }
        private void llenar(Pila pila)
        {
            Random random = new Random();
            for (int i = 0; i < random.Next(10, 20); i++)
            {
                pila.Apilar(random.Next(1, 4));
            }
        }
        private void llenarPalindromo(Pila pila)
        {
            string numero = "0123443210";
            for (int i = 0; i < numero.Length; i++)
            {
                pila.Apilar(int.Parse(numero[i].ToString()));
            }
        }
        private void vaciar(Pila pila)
        {
            while (pila.Ver() != null)
            {
                pila.Desapilar();
            }
        }
        private void Mostrar(Pila pila, ListBox listBox)
        {
            Pila aux = new Pila();
            listBox.Items.Clear();
            while (pila.Ver() != null)
            {
                aux.Apilar(pila.Desapilar());
                listBox.Items.Add(aux.Ver().Tam.ToString());
            }
            while (aux.Ver() != null)
            {
                pila.Apilar(aux.Desapilar());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            llenar(pila1);
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            llenar(pila1);
            Pila aux = new Pila();
            while (pila1.Ver() != null)
            {
                aux.Apilar(pila1.Desapilar());
            }
            pila2.Apilar(20);
            while (aux.Ver() != null)
            {
                Nodo nodo = aux.Desapilar();
                pila1.Apilar(nodo.Tam);
                pila2.Apilar(nodo.Tam);
            }
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            llenar(pila1);
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
            Pila aux = new Pila();
            int tam = 0;
            while (pila1.Ver() != null)
            {
                aux.Apilar(pila1.Desapilar());
                tam++;
            }
            while (aux.Ver() != null)
            {
                pila1.Apilar(aux.Desapilar());
            }
            label1.Text = tam.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            llenar(pila1);
            Pila aux = new Pila();
            Random ran = new Random();
            int fil = ran.Next(1, 4);
            label1.Text = fil.ToString();
            while (pila1.Ver() != null)
            {
                aux.Apilar(pila1.Desapilar());
            }
            while (aux.Ver() != null)
            {
                Nodo nodo = aux.Desapilar();
                if (nodo.Tam != fil)
                {
                    pila2.Apilar(nodo.Tam);
                }
                pila1.Apilar(nodo.Tam);
            }
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            llenar(pila1);
            Pila aux = new Pila();
            Nodo nodoTop = pila1.Desapilar();
            Nodo nodoBottom = new Nodo();
            while (pila1.Ver() != null)
            {
                Nodo nodo = pila1.Desapilar();
                if (pila1.Ver() != null)
                {
                    aux.Apilar(nodo.Tam);
                }
                else
                {
                    nodoBottom = nodo;
                }
            }
            pila1.Apilar(nodoBottom.Tam);
            pila2.Apilar(nodoTop.Tam);
            while (aux.Ver() != null)
            {
                Nodo nodo = aux.Desapilar();
                pila2.Apilar(nodo.Tam);
                pila1.Apilar(nodo.Tam);
            }
            pila1.Apilar(nodoTop.Tam);
            pila2.Apilar(nodoBottom.Tam);
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            llenar(pila1);
            Pila aux = new Pila();
            while (pila1.Ver() != null)
            {
                aux.Apilar(pila1.Desapilar());
            }
            while (aux.Ver() != null)
            {
                Nodo nodo = aux.Desapilar();
                pila2.Apilar(nodo.Tam);
                pila1.Apilar(nodo.Tam);
            }
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            Random ran = new Random();
            if (ran.Next(0, 2) == 0)
            {
                llenar(pila1);
            }
            else
            {
                llenarPalindromo(pila1);
            }
            Pila aux = new Pila();
            Pila aux2 = new Pila();
            while (pila1.Ver() != null)
            {
                Nodo nodo = pila1.Desapilar();
                aux.Apilar(nodo.Tam);
                aux2.Apilar(nodo.Tam);
            }
            while (aux2.Ver() != null)
            {
                pila1.Apilar(aux2.Desapilar());
            }
            bool flag = true;
            while (pila1.Ver() != null)
            {
                Nodo nodo = pila1.Desapilar();
                Nodo nodo1 = aux.Desapilar();
                if (nodo.Tam != nodo1.Tam)
                {
                    flag = false;
                }
                aux2.Apilar(nodo.Tam);
            }
            while (aux2.Ver() != null)
            {
                pila1.Apilar(aux2.Desapilar());
            }
            if (flag)
            {
                label1.Text = "Es un palindromo";
            }
            else
            {
                label1.Text = "No es un Palindromo";
            }
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            llenar(pila1);
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
            Pila aux = new Pila();
            int sum = 0;
            while (pila1.Ver() != null)
            {
                Nodo nodo = pila1.Desapilar();
                aux.Apilar(nodo.Tam);
                sum += nodo.Tam;
            }
            while (aux.Ver() != null)
            {
                pila1.Apilar(aux.Desapilar());
            }
            label1.Text = sum.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            vaciar(pila1);
            vaciar(pila2);
            llenar(pila1);
            Mostrar(pila1, listBox1);
            Mostrar(pila2, listBox2);
            Pila aux = new Pila();
            int max = 0;
            while (pila1.Ver() != null)
            {
                Nodo nodo = pila1.Desapilar();
                aux.Apilar(nodo.Tam);
                if (max < nodo.Tam) max = nodo.Tam;
            }
            while (aux.Ver() != null)
            {
                pila1.Apilar(aux.Desapilar());
            }
            label1.Text = max.ToString();
        }
    }

}