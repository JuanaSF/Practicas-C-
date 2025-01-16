using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//Agrego libreria IO para manejo de files
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace XML
{
    public partial class Form1 : Form
    {
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
            ds = new DataSet("Datos");

            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarDataSet();

            ActualizarDG();
        }

        private void AgregarDatos()
        {
            DataRow dr = ds.Tables[0].NewRow();

            dr.ItemArray = new object[] { 1, "Juana", "Sucasaire"};

            ds.Tables[0].Rows.Add(dr);

            dr = ds.Tables[0].NewRow();

            dr.ItemArray = new object[] { 2, "Franco", "Rojas" };

            ds.Tables[0].Rows.Add(dr);
        }

        private void CargarDataSet()
        {
            try
            {
                if(!File.Exists("Datos.xml"))
                {
                    CrearArchivoXML();
                }
                else
                {
                    ds.ReadXml("Datos.xml");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CrearArchivoXML()
        {
            DataTable dt = new DataTable("Personas");

            //Creo la estructura de la tabla, columna a columna, con nombre columna y tipo de dato
            dt.Columns.Add("Legajo", typeof(int));
            dt.Columns.Add("Nombre", typeof (string));
            dt.Columns.Add("Apellido", typeof(string));

            //Seteo la primary key de la tabla
            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };

            //Agrego dataTable al DataSet
            ds.Tables.Add(dt);

            //Cargo algunas personas
            AgregarDatos();

            GrabarDatos();
        }

        private void GrabarDatos()
        {
            ds.WriteXml("Datos.xml", XmlWriteMode.WriteSchema);
        }

        private void ActualizarDG()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(Interaction.InputBox("Legajo"));
                string nombre = Interaction.InputBox("Nombre");
                string apellido = Interaction.InputBox("Apellido");

                DataRow dr = ds.Tables[0].NewRow();

                dr.ItemArray = new object[] { legajo, nombre, apellido };

                ds.Tables[0].Rows.Add(dr);

                GrabarDatos();
                ActualizarDG();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay registros para borrar");

                int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                DataRow dr = ds.Tables[0].Rows.Find(legajo);

                ds.Tables[0].Rows.Remove(dr);

                GrabarDatos();
                ActualizarDG();
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
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay registros para modificar!");

                int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());

                DataRow dr = ds.Tables[0].Rows.Find(legajo);

                string nombre = Interaction.InputBox("Nombre", "", dr.ItemArray[1].ToString());
                string apellido = Interaction.InputBox("Apellido", "", dr.ItemArray[2].ToString());

                dr.SetField<string>(1, nombre);
                dr.SetField<string>(2, apellido);

                GrabarDatos();
                ActualizarDG();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
