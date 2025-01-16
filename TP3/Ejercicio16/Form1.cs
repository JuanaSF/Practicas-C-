using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    16. Realizar un programa que simule la cola de clientes por cobrar en una caja de
    supermercado. Los clientes poseen Id y el importe que han comprado. Se
    desea poder encolar clientes y desencolar los clientes a los que se les va
    cobrando. En todo momento se desea saber cuanto dinero hay por cobrar,
    cuanto dinero se cobro, cuantos clientes aún no se les ha cobrado, cuantos
    clientes ya se les ha cobrado.
 */

namespace Ejercicio16
{
    public partial class Form1 : Form
    {
        ColaSuper cACobrar;
        ColaSuper cCobrados;
        Random random;
        int numId;


        public Form1()
        {
            InitializeComponent();

            random = new Random();
            numId = 0;

            cACobrar = new ColaSuper();
            cCobrados = new ColaSuper();

            for(int i = 1; i < 5; i++)
            {
                numId++;
                cACobrar.Encolar(numId.ToString(), GenerarImporte());
            }

            Mostrar(cACobrar, listBox1, label1, label2);
            Mostrar(cCobrados, listBox2, label3, label4);
        }

        private int GenerarImporte()
        {
            return random.Next(500, 5000);
        }

        private void Mostrar(ColaSuper cola, ListBox listBox, Label lCantidad, Label lMonto)
        {
            ColaSuper aux = new ColaSuper();
            listBox.Items.Clear();

            int cantidadClientes = 0;
            int montoAcumulado = 0;

            while (cola.Ver() != null)
            {
                Nodo nAux = cola.Desencolar();
                listBox.Items.Add($"Id: {nAux.Id}, Importe: $ {nAux.Importe}");
                aux.Encolar(nAux);
                cantidadClientes++;
                montoAcumulado += nAux.Importe;
            }

            while (aux.Ver() != null)
            {
                cola.Encolar(aux.Desencolar());
            }

            lCantidad.Text = $"Cantidad: {cantidadClientes}";
            lMonto.Text = $"Monto Total: $ {montoAcumulado}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cACobrar.Ver() == null)
            {
                MessageBox.Show("No hay mas clientes para cobrar!!");
                return;
            }
                
            cCobrados.Encolar(cACobrar.Desencolar());

            Mostrar(cACobrar, listBox1, label1, label2);
            Mostrar(cCobrados, listBox2, label3, label4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numId++;
            cACobrar.Encolar(numId.ToString(), GenerarImporte());
            Mostrar(cACobrar, listBox1, label1, label2);
        }
    }
    public class ColaSuper
    {
        Nodo centinelaP;
        Nodo centinelaU;

        public ColaSuper()
        {
            centinelaP = new Nodo();
            centinelaU = new Nodo();
        }

        public void Encolar(string id, int importe)
        {
            Nodo nuevoNodo = new Nodo(id, importe);

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
            return new Nodo(centinelaP.Siguiente.Id, centinelaP.Siguiente.Importe);
        }
    }

    public class Nodo
    {
        public string Id { get; set; }
        public Nodo Siguiente { get; set; }

        public int Importe { get; set; }

        public Nodo(string id = "", int importe = 0)
        {
            Id = id;
            Siguiente = null;
            Importe = importe;
        }
    }
}
