using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol
{
    public partial class Form1 : Form
    {
        Nodo nA, nB, nC, nD, nE, nF;

        private void Form1_Load(object sender, EventArgs e)
        {
            nF = new Nodo("F");
            nE = new Nodo("E");
            nD = new Nodo("D");
            nC = new Nodo("C", nE, nF);
            nB = new Nodo("B", null, nD);
            nA = new Nodo("A", nB, nC);

            treeView1.ExpandAll();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Clear();
                PreOrdenRecursiva(nA, textBox1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PreOrdenRecursiva(Nodo nodo, TextBox textBox)
        {
            if (nodo != null)
            {
                textBox.Text += $"{nodo.Id} ";
                PreOrdenRecursiva(nodo.Izquierdo, textBox);
                PreOrdenRecursiva(nodo.Derecho, textBox);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Clear();
                InOrdenRecursiva(nA, textBox2);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void InOrdenRecursiva(Nodo nodo, TextBox textBox)
        {
            if (nodo != null)
            {
                InOrdenRecursiva(nodo.Izquierdo, textBox);
                textBox.Text += $"{nodo.Id} ";
                InOrdenRecursiva(nodo.Derecho, textBox);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Clear();
                PosOrdenRecursiva(nA, textBox3);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void PosOrdenRecursiva(Nodo nodo, TextBox textBox)
        {
            if(nodo != null)
            {
                PosOrdenRecursiva(nodo.Izquierdo, textBox);
                PosOrdenRecursiva(nodo.Derecho, textBox);

                textBox.Text += $"{nodo.Id} ";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Clear();
                AmplitudRecursiva(new List<Nodo> {nA}, textBox4);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void AmplitudRecursiva(List<Nodo> lNodos, TextBox textBox)
        {
            if(lNodos.Exists(x => x.Id!= "@"))
            {
                List<Nodo> auxNodos = new List<Nodo>();

                foreach(Nodo n in lNodos)
                {
                    textBox.Text += $"{n.Id} ";
                    auxNodos.Add(n.Izquierdo != null ? n.Izquierdo : new Nodo("@"));
                    auxNodos.Add(n.Derecho != null ? n.Derecho : new Nodo("@"));
                }

                AmplitudRecursiva(auxNodos, textBox);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                treeView2.Nodes.Clear();

                if (textBox5.TextLength == 0) throw new Exception("No hay nodos!");

                string nodosTotales = textBox5.Text;

                string raiz = nodosTotales.Substring(0, 1);

                treeView2.Nodes.Add(raiz);

                // Quito raiz de los nodos totales
                nodosTotales = nodosTotales.Substring(1);

                //Guardo lo ultimo agregado al treeView
                List<TreeNode> ultimoAgregado = new List<TreeNode>() { treeView2.Nodes[0] };

                while(nodosTotales.Length > 0)
                {
                    List<TreeNode> auxUltimoAgregado = new List<TreeNode>();

                    foreach (TreeNode tNode in ultimoAgregado)
                    {
                        // Recorto de a 2 los caracteres de nodosTotales
                        string nodosHoja = nodosTotales.Substring(0, 2);

                        //Cuelgo un nodo en la Izquierda y lo guardo en la lista aux de agregados
                        tNode.Nodes.Add(nodosHoja[0].ToString());
                        auxUltimoAgregado.Add(tNode.Nodes[0]);

                        //Cuelgo un nodo en la derecha y lo guardo en la lista aux de agregados
                        tNode.Nodes.Add(nodosHoja[1].ToString());
                        auxUltimoAgregado.Add(tNode.Nodes[1]);

                        //Quito de nodosTotales los nodos utilizados
                        nodosTotales = nodosTotales.Substring(2);
                    }

                    ultimoAgregado = auxUltimoAgregado;
                }

                treeView2.ExpandAll();

            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
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
