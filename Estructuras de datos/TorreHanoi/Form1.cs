using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pila;

namespace TorreHanoi
{
    public partial class Form1 : Form
    {
        Hanoi hanoi;
        int cantidadMovimientos;

        public Form1()
        {
            InitializeComponent();
            hanoi = new Hanoi();

            MostrarTorre(hanoi.P1, listBox1);
            numericUpDown1.Value = 3;
            cantidadMovimientos = 0;
            MostrarMovimientos(cantidadMovimientos);
        }

        private void buttonJugar_Click(object sender, EventArgs e)
        {
            try
            {
                cantidadMovimientos = 0;
                int cantDiscos = int.Parse(numericUpDown1.Value.ToString());

                hanoi = new Hanoi(cantDiscos);

                MostrarTorre(hanoi.P1, listBox1);
                MostrarTorre(hanoi.P2, listBox2);
                MostrarTorre(hanoi.P3, listBox3);

                MostrarMovimientos(cantidadMovimientos);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void MostrarMovimientos(int cantidadMovimientos)
        {
            labelMovimientos.Text = $"Movimientos hechos: {cantidadMovimientos}";
        }

        private void MostrarTorre(Pila.Pila p, ListBox listBox)
        {
            Pila.Pila aux = new Pila.Pila();
            listBox.Items.Clear();


            while (p.Ver() != null)
            {
                aux.Apilar(p.Desapilar());
                //listBox.Items.Insert(0, aux.Ver().Id);
                listBox.Items.Add(aux.Ver().Id);
            }
            while (aux.Ver() != null)
            {
                p.Apilar(aux.Desapilar());
            }
        }

        private void t1Tot2_Click(object sender, EventArgs e)
        {
            HacerMovimiento(hanoi.P1, hanoi.P2, listBox1, listBox2);
        }

        private void t1Tot3_Click(object sender, EventArgs e)
        {
            HacerMovimiento(hanoi.P1, hanoi.P3, listBox1, listBox3);
        }

        private void t2Tot1_Click(object sender, EventArgs e)
        {
            HacerMovimiento(hanoi.P2, hanoi.P1, listBox2, listBox1);
        }

        private void t2Tot3_Click(object sender, EventArgs e)
        {
            HacerMovimiento(hanoi.P2, hanoi.P3, listBox2, listBox3);
        }

        private void t3Tot2_Click(object sender, EventArgs e)
        {
            HacerMovimiento(hanoi.P3, hanoi.P2, listBox3, listBox2);
        }

        private void t3Tot1_Click(object sender, EventArgs e)
        {
            HacerMovimiento(hanoi.P3, hanoi.P1, listBox3, listBox1);
        }

        private void HacerMovimiento(Pila.Pila pOrigen, Pila.Pila pDestino, ListBox listBoxOrigen, ListBox listBoxDestino)
        {
            try
            {
                cantidadMovimientos++;
                MostrarMovimientos(cantidadMovimientos);

                if (pOrigen.Ver() == null) throw new Exception("No hay discos para mover");

                if (pDestino.Ver() != null
                    && int.Parse(pDestino.Ver().Id) < int.Parse(pOrigen.Ver().Id)) throw new Exception("No se puede hacer este movimiento!");

                pDestino.Apilar(pOrigen.Desapilar());

                MostrarTorre(pDestino, listBoxDestino);
                MostrarTorre(pOrigen, listBoxOrigen);

                VerificarSiGano();
            }
            catch (System.Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void VerificarSiGano()
        {
            if (hanoi.P1.Ver() == null && hanoi.P2.Ver() == null)
            {
                MessageBox.Show($"Ganaste!!{Environment.NewLine}Cantidad de movimientos: {cantidadMovimientos}");

                buttonJugar_Click(null, null);
            }
        }

    }

    public class Hanoi
    {
        public Pila.Pila P1 { get; set; }
        public Pila.Pila P2 { get; set; }
        public Pila.Pila P3 { get; set; }

        public Hanoi(int cantDiscos = 3)
        {
            P1 = new Pila.Pila();
            P2 = new Pila.Pila();
            P3 = new Pila.Pila();

            //Cargo discos
            for (int i = cantDiscos; i > 0; i--)
            {
                P1.Apilar(i.ToString());
            }
        }
    }
}
