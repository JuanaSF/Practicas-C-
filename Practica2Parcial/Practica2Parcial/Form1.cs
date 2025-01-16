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

namespace Practica2Parcial
{
    public partial class Form1 : Form
    {
        List<Producto> productos;

        public Form1()
        {
            InitializeComponent();

            productos = new List<Producto>();
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            radioButton1.Checked = true;
        }

        private void FuncionVencidos(object sender, VencidosEventArgs e)
        {
            MessageBox.Show(e.Datos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _id = Interaction.InputBox("Id: ");
                if (!Information.IsNumeric(_id)) throw new Exception("El valor del Id es inválido !!!");
                string _descri = Interaction.InputBox("Descripción: ");
                string _fechaVto = Interaction.InputBox("Fecha de Venciimiento: ");
                if (!Information.IsDate(_fechaVto)) throw new Exception("El valor del fecha de vencimiento es inválido !!!");
                string _costo = Interaction.InputBox("Costo: ");
                if (!Information.IsNumeric(_costo)) throw new Exception("El valor del costo es inválido !!!");
                Producto _aux = null;
                if (radioButton1.Checked)
                {
                    _aux = new ProductoA(decimal.Parse(_costo)) { Id = int.Parse(_id), Descripcion = _descri, FechaVto = DateTime.Parse(_fechaVto) };
                }
                else
                {
                    _aux = new ProductoB(decimal.Parse(_costo)) { Id = int.Parse(_id), Descripcion = _descri, FechaVto = DateTime.Parse(_fechaVto) };
                }
                _aux.Vencidos += FuncionVencidos;
                productos.Add(_aux);
                Mostrar(dataGridView1, productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Mostrar(DataGridView pDGV, object pO)
        {
            dataGridView1.DataSource = null; dataGridView1.DataSource = pO;
            dataGridView2.DataSource = null; dataGridView2.DataSource = (from px in productos select new { Id = px.Id, Descripción = px.Descripcion, Vto = px.FechaVto, Costo = px.Costo, Tipo = px is ProductoA ? "Producto A" : "Producto B" }).ToList();
            var _aux = from px in productos select px.Costo;
            decimal _total = 0;
            foreach (var c in _aux) { _total += c; }
            textBox1.Text = _total.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay productos para borrar !!!");
                productos.Remove((dataGridView1.SelectedRows[0].DataBoundItem) as Producto);
                Mostrar(dataGridView1, productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay productos para modificar !!!");
                Producto _aux = (dataGridView1.SelectedRows[0].DataBoundItem) as Producto;
                string _id = Interaction.InputBox("Id: ", "", _aux.Id.ToString());
                if (!Information.IsNumeric(_id)) throw new Exception("El valor del Id es inválido !!!");
                string _descri = Interaction.InputBox("Descripción: ", "", _aux.Descripcion.ToString());
                string _fechaVto = Interaction.InputBox("Fecha de Venciimiento: ", "", _aux.FechaVto.ToShortDateString());
                if (!Information.IsDate(_fechaVto)) throw new Exception("El valor del fecha de vencimiento es inválido !!!");
                _aux.Id = int.Parse(_id);
                _aux.Descripcion = _descri;
                _aux.FechaVto = DateTime.Parse(_fechaVto);
                Mostrar(dataGridView1, productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(Producto p in productos)
            {
                p.ChequeoVencidos();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay producto seleccionado !!!");
                Producto _aux = (dataGridView1.SelectedRows[0].DataBoundItem) as Producto;
                MessageBox.Show($"El costo ajustado es: $ {_aux.AjusteCosto()}");

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }

    public class VencidosEventArgs : EventArgs
    {
        Producto _p;
        public VencidosEventArgs(Producto pProducto)
        {
            _p = pProducto;
        }
        public string Datos { get { return $"{_p.Id} {_p.Descripcion} ** Costo: {_p.Costo} ** Fecha de Vto: {_p.FechaVto.ToShortDateString()}"; } }
    }

    public abstract class Producto
    {
        // Eventos
        public event EventHandler<VencidosEventArgs> Vencidos;

        // Atributos
        decimal _costo;
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVto { get; set; }
        public decimal Costo { get { return _costo; } }

        // Constructor
        public Producto(decimal pCosto) { _costo = pCosto; }

        // Metodos
        public abstract decimal AjusteCosto();

        public void ChequeoVencidos()
        {
            if (FechaVto < DateTime.Today) Vencidos?.Invoke(this, new VencidosEventArgs(this));
        }
    }

    public class ProductoA : Producto
    {
        public ProductoA(decimal pCosto) : base(pCosto) { }

        public override decimal AjusteCosto()
        {
            int diasVto = (FechaVto - DateTime.Today).Days;
            decimal rdo = Costo;
            if (diasVto == 1) rdo = Costo * 0.8m;
            if (diasVto >= 2 && diasVto <= 7) rdo = Costo * 0.9m;
            return rdo;
        }
    }
    public class ProductoB : Producto
    {
        public ProductoB(decimal pCosto) : base(pCosto) { }
        public override decimal AjusteCosto()
        {
            int diasVto = (FechaVto - DateTime.Today).Days;
            decimal rdo = Costo;
            if (diasVto == 1) rdo = Costo * 0.5m;
            if (diasVto >= 2 && diasVto <= 7) rdo = Costo * 0.7m;
            return rdo;
        }
    }
}
