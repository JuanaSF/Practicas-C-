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

namespace Lista
{
    public partial class Form1 : Form
    {
        ListaDE lista;

        public Form1()
        {
            InitializeComponent();
            lista = new ListaDE();
        }

        private void Mostrar()
        {
            listBox1.Items.Clear();

            int cant = lista.Cantidad();

            if(cant > 0)
            {
                for(int i = 1; i <= cant; i++)
                {
                    listBox1.Items.Add(lista.BuscarPorPosicion(i).Id);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = Interaction.InputBox("ID: ");
                lista.Agregar(id);

                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string pos = Interaction.InputBox("Posicion: ");
                string id = Interaction.InputBox("ID: ");
                bool agregado = lista.InsertarPosN(int.Parse(pos), id);

                if (!agregado) throw new Exception("No se pudo insertar el nodo");

                Mostrar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(lista.Cantidad() == 0)
            {
                MessageBox.Show("No hay elementos en la lista");
                return;
            }

            MessageBox.Show(lista.ConsultarPrimero().Id);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lista.Cantidad() == 0)
            {
                MessageBox.Show("No hay elementos en la lista");
                return;
            }

            MessageBox.Show(lista.ConsultarUltimo().Id);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Cantidad de elementos: {lista.Cantidad()}");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (lista.Cantidad() == 0)
            {
                MessageBox.Show("No hay elementos en la lista");
                return;
            }

            string id = Interaction.InputBox("ID a buscar: ");

            Nodo buscado = lista.BuscarPorId(id);

            if (buscado == null)
            {
                MessageBox.Show($"No se encontro en elemento con id: {id}");
            }
            else
            {
                MessageBox.Show($"Encontre el id: {buscado.Id}");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string pos = Interaction.InputBox("Posicion: ");

                Nodo encontrado = lista.ConsultarPorPosicion(int.Parse(pos));

                if(encontrado == null)
                {
                    MessageBox.Show($"No se encontro el elemento en la posicion: {pos}");
                }
                else
                {
                    MessageBox.Show($"Encontre el elemento con id: {encontrado.Id}");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    public class ListaDE
    {
        Nodo CentinelaP;

        public ListaDE()
        {
            CentinelaP = new Nodo();
        }

        public void Agregar(string id)
        {
            // Si no hay nodos en la lista, simplemente se agrega el nuevo nodo en centinelaP.Siguiente()
            if(CentinelaP.Siguiente == null)
            {
                CentinelaP.Siguiente = new Nodo(id);
                return;
            }

            // Si hay nodos en la lista, debo buscar el ultimo nodo y agregarlo como siguiente de el
            Nodo ultimoNodo = UltimoNodo();
            ultimoNodo.Siguiente = new Nodo(id, null, ultimoNodo);
        }

        public Nodo UltimoNodo()
        {
            Nodo rta = null;

            if (CentinelaP.Siguiente != null)
            {
                rta = RecursivaUltimoNodo(CentinelaP);
            }

            return rta;
        }

        public Nodo RecursivaUltimoNodo(Nodo nodo)
        {
            Nodo ultimo = null;

            if(nodo.Siguiente == null)
            {
                ultimo = nodo;
            }
            else
            {
                ultimo = RecursivaUltimoNodo(nodo.Siguiente);
            }

            return ultimo;
        }

        public int Cantidad()
        {
            int rta = 0;

            if(CentinelaP.Siguiente != null)
            {
                rta = RecursivaCantidad(CentinelaP);
            }

            return rta;
        }

        public int RecursivaCantidad(Nodo nodo)
        {
            int cantidad = 0;

            if(nodo.Siguiente != null)
            {
                cantidad = 1 + RecursivaCantidad(nodo.Siguiente);
            }

            return cantidad;
        }

        public Nodo ConsultarPrimero()
        {
            Nodo nodo = null;

            if (CentinelaP.Siguiente != null)
            {
                nodo = new Nodo(CentinelaP.Siguiente.Id);
            }
            
            return nodo;
        }

        public Nodo ConsultarUltimo()
        {
            Nodo nodo = UltimoNodo();

            if(nodo == null)
            {
                return null;
            }

            return new Nodo(nodo.Id);
        }

        public Nodo BuscarPorId(string id)
        {
            Nodo rta = RecursivaBuscarPorId(CentinelaP, id);

            if (rta == null) return null;

            return new Nodo(rta.Id);
        }

        public Nodo RecursivaBuscarPorId(Nodo nodo, string id)
        {
            Nodo rta = null;

            if(nodo == null)
            {
                rta = null;
            }
            else if(nodo.Id == id)
            {
                rta = nodo;
            }
            else
            {
                rta = RecursivaBuscarPorId(nodo.Siguiente, id);
            }

            return rta;
        }

        public Nodo BuscarPorPosicion(int pos)
        {
            Nodo rta = null;

            if (pos <= Cantidad() && pos > 0)
            {
                rta = CentinelaP;

                for (int i = 0; i < pos; i++)
                {
                    rta = rta.Siguiente;
                }
            }

            return rta;
        }

        public Nodo ConsultarPorPosicion(int pos)
        {
            Nodo rta = BuscarPorPosicion(pos);

            if(rta == null) return null;

            return new Nodo(rta.Id);
        }

        public bool InsertarPosN(int pos, string id)
        {
            bool rta = false;

            if(pos > 0 && pos <= Cantidad()+1)
            {
                // Lista Vacia o que la posicion sea la ultima+1
                if(Cantidad()==0 || pos == Cantidad()+1)
                {
                    Agregar(id); // Lo agrega ultimo
                    return true;
                }
                else if(pos > 1)
                {
                    Nodo n = BuscarPorPosicion(pos);   //Busca al nodo que estaba en esa posicion
                    Nodo nuevoNodo = new Nodo(id, n, n.Anterior);

                    /* Graficamente  CentinelaP.Siguiente -> N1 -> N2 -> N3 -> null
                     * Creo nuevo nodo a insertar en la posicion 2
                     * CentinelaP.Siguiente -> N1 -> NuevoN -> N2 -> N3 -> null //se inserto nuevoN
                    */
                    n.Anterior.Siguiente = nuevoNodo;  
                    n.Anterior = nuevoNodo;

                    rta = true;
                }
                else // La posicion es igual a 1
                {
                    Nodo n = CentinelaP.Siguiente;
                    Nodo nuevoNodo = new Nodo(id, n, null);

                    /* Graficamente  CentinelaP.Siguiente -> N1 -> N2 -> N3 -> null
                     * Creo nuevo nodo a insertar en la posicion 1
                     * CentinelaP.Siguiente -> NuevoN -> N1 -> NuevoN -> N2 -> N3 -> null  //se inserto nuevoN
                    */

                    n.Anterior = nuevoNodo;
                    CentinelaP.Siguiente = nuevoNodo;

                    rta = true;
                }
            }

            return rta;
        }

        

    }

    public class Nodo
    {
        public Nodo(string id = "", Nodo siguiente = null, Nodo anterior = null)
        {
            Id = id;
            Siguiente = siguiente;
            Anterior = anterior;
        }

        public string Id { get; set; }
        public Nodo Siguiente { get; set; }
        public Nodo Anterior { get; set; }
    }
}
