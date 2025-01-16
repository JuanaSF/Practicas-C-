using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interdaces
{
    public partial class Form1 : Form
    {
        List<Alumno> alumnos;
        DataSet ds;
        SqlDataAdapter da;
        SqlCommandBuilder cb;

        public Form1()
        {
            InitializeComponent();
            alumnos = new List<Alumno>();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Alumno", "Data Source=DESKTOP-899MV0O;Initial Catalog=Alumnos;Integrated Security=True");
            cb = new SqlCommandBuilder(da);

            da.InsertCommand = cb.GetInsertCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            da.DeleteCommand = cb.GetDeleteCommand();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            da.Fill(ds);

            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };

            CargarListaAlumnos();

            ActualizarDG();
        }

        private void CargarListaAlumnos()
        {
            alumnos.Clear();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Alumno a = new Alumno(int.Parse(dr.ItemArray[0].ToString()), dr.ItemArray[1].ToString(), int.Parse(dr.ItemArray[2].ToString()));
                a.Cumple18 += FuncionCumple;
                alumnos.Add(a);
            }
        }

        private void FuncionCumple(object sender, CumpleEventArgs e)
        {
            MessageBox.Show(e.Datos);
        }

        private void ActualizarDG()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = alumnos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(Alumno a in alumnos)
            {
                a.VerificarCumple();
            }
        }
    }

    public class CumpleEventArgs : EventArgs
    {
        Alumno a;

        public CumpleEventArgs(Alumno alumno)
        {
            this.a = alumno;
        }

        public string Datos { get { return $"**{a.Nombre} CUMPLIO {a.Edad} ANIOS**"; } }
    }

    public class Alumno
    {
        public event EventHandler<CumpleEventArgs> Cumple18;
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public Alumno(int dni, string nombre, int edad)
        {
            DNI = dni;
            Nombre = nombre;
            Edad = edad;
        }

        public void VerificarCumple()
        {
            if(Edad >= 18)
            {
                Cumple18?.Invoke(this, new CumpleEventArgs(this));
            }
        }
    }
}
