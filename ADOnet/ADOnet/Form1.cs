using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//importo sqlClient para coneccion con sql server
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ADOnet
{
    public partial class Form1 : Form
    {
        //Para conectar creo una instancia de SqlConnection
        SqlConnection cx;
        SqlCommand cm;
        SqlDataReader dr;
        List<Persona> personas;

        public Form1()
        {
            InitializeComponent();
            //Le paso la cadena de conexion al constructor de connection
            cx = new SqlConnection("Data Source=DESKTOP-899MV0O;Initial Catalog=Personas;Integrated Security=True");
            cx.StateChange += CambioDeEstado;
            cm = new SqlCommand("Select * from Persona", cx);
            cm.CommandType = CommandType.Text;
            personas = new List<Persona>();
        }

        private void CambioDeEstado(object sender, StateChangeEventArgs e)
        {
            if(e.CurrentState == ConnectionState.Open)
            {
                pictureBox1.BackColor = Color.Green;
            }
            else
            {
                pictureBox1.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cx.State != ConnectionState.Open)
                {
                    cx.Open();
                    CargarLista();
                    ActualizarDG(personas);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ActualizarDG(List<Persona> personas)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = personas;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cx.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void CargarLista()
        {
            try
            {
                cm.CommandText = "select * from Persona order by Legajo";
                dr = cm.ExecuteReader();
                personas.Clear();

                while(dr.Read())
                {
                    personas.Add(new Persona()
                    {
                        Legajo = int.Parse(dr.GetValue(0).ToString()),
                        Nombre = dr.GetValue(1).ToString(),
                        Apellido = dr.GetValue(2).ToString()
                    }) ;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                dr.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int legajo = int.Parse(Interaction.InputBox("Legajo"));
                string nombre = Interaction.InputBox("Nombre");
                string apellido = Interaction.InputBox("Apellido");

                // Insterto el comando para insertar un nuevo registro
                cm.CommandText = $"insert into Persona (Legajo, Nombre, Apellido) values ({legajo}, '{nombre}', '{apellido}')";
                // Ejecuta el comando seteado en commandText
                cm.ExecuteNonQuery();
                CargarLista();
                ActualizarDG(personas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay registros para borrar!");

                int legajo = (dataGridView1.SelectedRows[0].DataBoundItem as Persona).Legajo;

                cm.CommandText = $"delete from Persona where Legajo = {legajo}";
                cm.ExecuteNonQuery();

                CargarLista();
                ActualizarDG(personas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay registros para borrar!");

                Persona aux = dataGridView1.SelectedRows[0].DataBoundItem as Persona;

                int legajo = int.Parse(Interaction.InputBox("Legajo", "", aux.Legajo.ToString()));
                string nombre = Interaction.InputBox("Nombre", "", aux.Nombre);
                string apellido = Interaction.InputBox("Apellido", "", aux.Apellido);

                cm.CommandText = $"update Persona set Legajo = {legajo}, Nombre = '{nombre}', Apellido = '{apellido}' where Legajo = {aux.Legajo}";
                cm.ExecuteNonQuery();

                CargarLista();
                ActualizarDG(personas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class Persona
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
