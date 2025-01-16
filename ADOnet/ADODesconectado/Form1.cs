using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//Agrego sql client
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ADODesconectado
{
    public partial class Form1 : Form
    {
        DataSet ds;
        SqlDataAdapter da;
        SqlCommandBuilder cb;

        public Form1()
        {
            InitializeComponent();
            //Paso un commandText y el string de conexion al crear dataAdapter
            da = new SqlDataAdapter("select * from Persona order by Legajo", "Data Source=DESKTOP-899MV0O;Initial Catalog=Personas;Integrated Security=True");
            ds = new DataSet();
            cb = new SqlCommandBuilder(da);

            //Insertamos comandos al dataAdapter
            da.InsertCommand = cb.GetInsertCommand();
            da.UpdateCommand = cb.GetUpdateCommand();
            da.DeleteCommand = cb.GetDeleteCommand();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // El dataAdapter agrega las filas de la db al dataSet
            da.Fill(ds);
            // Seteo la primaryKey del dataTable. en este caso sera la primera columna del dataTable
            ds.Tables[0].PrimaryKey = new DataColumn[] { ds.Tables[0].Columns[0] };

            RefrescarDG();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string legajo = Interaction.InputBox("Legajo");
                if (!Information.IsNumeric(legajo)) throw new Exception("Valor invalido!");

                string nombre = Interaction.InputBox("Nombre");
                string apellido = Interaction.InputBox("Apellido");

                //Creo un dataRow para guardar un registro
                DataRow dr = ds.Tables[0].NewRow();

                //Le seteo los datos a guardar al dataRow
                dr.ItemArray = new Object[] { int.Parse(legajo), nombre, apellido };

                //La agrego al dataTable
                ds.Tables[0].Rows.Add(dr);

                //Actualizo este cambio en la db
                da.Update(ds);

                RefrescarDG();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void RefrescarDG()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay registros para borrar!");

                int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                ds.Tables[0].Rows.Find(legajo).Delete();

                da.Update(ds);
                RefrescarDG();
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
                if (dataGridView1.Rows.Count == 0) throw new Exception("No hay regristros para modificar");

                int legajo = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                DataRow dr = ds.Tables[0].Rows.Find(legajo);

                dr.SetField<string>(1, Interaction.InputBox("Nombre", "", dr.ItemArray[1].ToString()));
                dr.SetField<string>(2, Interaction.InputBox("Apellido", "", dr.ItemArray[2].ToString()));

                da.Update(ds);
                RefrescarDG();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
