using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio17
{
    public partial class Form1 : Form
    {
        Cola impresoraPares;
        Cola impresoraImpares;

        int impresos1 = 0; 
        int impresos2 = 0;

        Random random;
        int id = 0;

        public Form1()
        {
            InitializeComponent();

            impresoraImpares = new Cola();
            impresoraPares = new Cola();
            random = new Random();

            timerCreador.Enabled = true;
            timer1.Enabled = true;
            timer2.Enabled = true;

            timer1.Interval = 500;
            timer2.Interval = 500;

            timer1.Stop();
            timer2.Stop();

            timerCreador.Start();
            timerCreador.Interval = 3000;
        }

        private void timerCreador_Tick(object sender, EventArgs e)
        {
            int cantPag = GenerarCantDePaginas();
            id++;

            if(cantPag % 2 == 0)
            {
                impresoraPares.Encolar(id.ToString(), cantPag);
                Mostrar(impresoraPares, listBox1, label1, label2, impresos1);
            }
            else
            {
                impresoraImpares.Encolar(id.ToString(), cantPag);
                Mostrar(impresoraImpares, listBox2, label5, label6, impresos2);
            }

        }

        private void Mostrar(Cola cola, ListBox listBox, Label lAImprimir, Label lImpresos, int cantImpresos)
        {
            Cola aux = new Cola();
            listBox.Items.Clear();

            int cantAImprimir = 0;

            while (cola.Ver() != null)
            {
                Nodo nAux = cola.Desencolar();
                listBox.Items.Add($"Id: {nAux.Id}, Cantidad de paginas: {nAux.CantidadDePaginas}");
                aux.Encolar(nAux);
                cantAImprimir++;
            }

            while (aux.Ver() != null)
            {
                cola.Encolar(aux.Desencolar());
            }

            lAImprimir.Text = $"Trabajos a Imprimir: {cantAImprimir}";
            lImpresos.Text = $"Trabajos Impresos: {cantImpresos}";
        }

        private int GenerarCantDePaginas()
        {
            return random.Next(10, 200);
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

        public void Encolar(string id, int cantPag)
        {
            Nodo nuevoNodo = new Nodo(id, cantPag);

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
            return new Nodo(centinelaP.Siguiente.Id, centinelaP.Siguiente.CantidadDePaginas);
        }
    }

    public class Nodo
    {
        public string Id { get; set; }
        public Nodo Siguiente { get; set; }

        public int CantidadDePaginas { get; set; }

        public Nodo(string id = "", int cantPag = 0)
        {
            Id = id;
            Siguiente = null;
            CantidadDePaginas = cantPag;
        }
    }
}
