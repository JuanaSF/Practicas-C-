using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*3.Genere un árbol binario balanceado de personas que poseen a otras dos personas a cargo. 
    El árbol posee 7 elementos. 
    La construcción del árbol déjela estática en el código (no se necesita ABM). 
    Las personas poseen DNI, Edad y Apellido. 

    Logre:

    a)	Validar el DNI para que no se permita ingresar clientes repetidos.
    b)	Dado el DNI de un cliente mostrar en pantalla todos los que dependen de él directa o indirectamente.
        p.e. Gomez, 33, 41.876.902

*/

namespace PracticaArbol
{
    public partial class Form1 : Form
    {
        Nodo nA, nB, nC, nD, nE, nF, nG;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            nG = new Nodo("G");
            nF = new Nodo("F");
            nE = new Nodo("E");
            nD = new Nodo("D");

            nC = new Nodo("C", nF, nG);
            nB = new Nodo("B", nD, nE);

            nA = new Nodo("A", nB, nC);

            MostrarArbol(nA);
        }

        private void MostrarArbol(Nodo raiz)
        {
            treeView1.Nodes.Clear();

            RecorrerArbolRecursiva(raiz, treeView1.Nodes);

            treeView1.ExpandAll();
        }


    }

    public class ArbolBinario
    {
        Nodo CentinelaRaiz;

        public ArbolBinario()
        {
            CentinelaRaiz = new Nodo();
        }


    }

    public class Nodo
    {
        public string Id { get; set; }
        public Nodo Izquierdo { get; set; }
        public Nodo Derecho { get; set; }

        public Nodo(string id = "", Nodo izq = null, Nodo der = null)
        {
            Id = id;
            Izquierdo = izq;
            Derecho = der;
        }
    }
}
