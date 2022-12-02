using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ParcialJuanaSucasaire
{
    public partial class Form1 : Form
    {
        List<Object> objetosCreados;
        string nombreEnsamblado;
        Type tipo;
        int count = 1;
        
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            objetosCreados = new List<Object>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly(); 
            nombreEnsamblado = asm.GetName().Name;

            Type[] Tipos = asm.GetTypes();

            foreach (Type t in Tipos)
            {
                if (t.CustomAttributes.Any(x => x.AttributeType.Name.Equals("AuthorAttribute")))
                {
                    tipo = t;
                }
            }

            PropertyInfo[] propiedades = tipo.GetProperties();

            foreach(PropertyInfo p in propiedades)
            {
                listBox1.Items.Add(p.Name);
            }

            MethodInfo[] metodos = tipo.GetMethods(BindingFlags.Instance|BindingFlags.Public|BindingFlags.DeclaredOnly);

            foreach(MethodInfo m in metodos)
            {
                if(!m.IsSpecialName)
                {
                    listBox2.Items.Add(m.Name);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un propiedad!");
                return;
            }

            Object objCreado;

            if(!radioButton1.Checked && listBox3.Items.Count == 0)
            {
                MessageBox.Show("No hay objetos para editar");
                return;
            }

            PropertyInfo propiedad = tipo.GetProperty(listBox1.SelectedItem.ToString());

            Assembly asm = tipo.Assembly;

            if (radioButton1.Checked)
            {
                objCreado = asm.CreateInstance(tipo.FullName);
                listBox3.Items.Add($"{tipo.Name} {count++}");
                objetosCreados.Add(objCreado);
            }
            else
            {
                objCreado = objetosCreados[listBox3.SelectedIndex];
            }

            if(propiedad.PropertyType == typeof(string))
            {
                propiedad.SetValue(objCreado, Interaction.InputBox($"Ingrese un {propiedad.PropertyType.Name} como valor de la propiedad: "));
            }
            else
            {
                propiedad.SetValue(objCreado, int.Parse(Interaction.InputBox($"Ingrese un {propiedad.PropertyType.Name} como valor de la propiedad: ")));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una propiedad!");
                return;
            }

            if (listBox3.Items.Count == 0)
            {
                MessageBox.Show("No hay objetos!!");
                return;
            }

            if(listBox3.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un objeto!");
                return;
            }

            Object objCreado = objetosCreados[listBox3.SelectedIndex];

            PropertyInfo propiedad = tipo.GetProperty(listBox1.SelectedItem.ToString());

            if (propiedad.GetValue(objCreado) == null)
            {
                MessageBox.Show("No hay un valor cargado!");
                return;
            }

            MessageBox.Show($"{propiedad.GetValue(objCreado)}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un metodo!");
                return;
            }

            if (listBox3.Items.Count == 0)
            {
                MessageBox.Show("No hay objetos!!");
                return;
            }

            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un objeto!");
                return;
            }

            Object objCreado = objetosCreados[listBox3.SelectedIndex];

            MethodInfo metodo = tipo.GetMethod($"{listBox2.SelectedItem}");

            ParameterInfo[] parametros = metodo.GetParameters();

            if(parametros.Length == 0)
            {
                MessageBox.Show(metodo.Invoke(objCreado, null).ToString());
                return;
            }

            Object[] parametrosCargados = new object[parametros.Length];

            foreach(ParameterInfo param in parametros)
            {
                if(param.ParameterType == typeof(string))
                {
                    parametrosCargados[param.Position] = Interaction.InputBox($"Ingrese un {param.ParameterType.Name} como parametro {param.Position}: ");
                }
                else
                {
                    parametrosCargados[param.Position] = int.Parse(Interaction.InputBox($"Ingrese un {param.ParameterType.Name} como parametro {param.Position}: "));
                }
            }

            MessageBox.Show(metodo.Invoke(objCreado, parametrosCargados).ToString());            
        }
    }

    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Struct)]
    public class AuthorAttribute : Attribute
    {
        string name;
        double version;

        public AuthorAttribute(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }

    [Author("Juana Sucasaire")]
    public class Alumno
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public int Anio { get; set; }

        public string Saludar()
        {
            return $"Hola {Nombre}!";
        }

        public string PasarDeAnio()
        {
            Anio++;
            return "Acabo de pasar de año!!";
        }

        public string MateriasARendir(string m1, string m2)
        {
            return $"Debe rendir {m1} y {m2}";
        }

        public string CalcularPromCuatri(int m1, int m2, int m3, int m4)
        {
            double promedio = (m1 + m2 + m3 + m4) / 4;
            return $"Promedio: {promedio}";
        }
    }
}
