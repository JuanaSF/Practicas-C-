using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.VisualBasic;

namespace Reflec2
{
    public partial class Form1 : Form
    {
        List<Object> objCreados;
        string nombreAsm;

        public Form1()
        {
            InitializeComponent();
            objCreados = new List<Object>();
            radioButton1.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            nombreAsm = asm.GetName().Name;

            Type[] types = asm.GetTypes();

            foreach (Type type in types)
            {

                if (type.CustomAttributes.Any(x => x.AttributeType.Name.Equals("AuthorAttribute")))
                {
                    listBox1.Items.Add(type.Name);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0) return;
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            string nombreTipo = listBox1.SelectedItem.ToString();

            Type tipo = Assembly.GetExecutingAssembly().GetType($"{nombreAsm}.{nombreTipo}");

            if (tipo != null)
            {
                PropertyInfo[] campos = tipo.GetProperties();

                foreach (PropertyInfo campo in campos)
                {
                    listBox2.Items.Add(campo.Name);
                }

                MethodInfo[] metodos = tipo.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

                foreach (MethodInfo metodo in metodos)
                {
                    if (!metodo.IsSpecialName) listBox3.Items.Add(metodo.Name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreTipo = listBox1.SelectedItem.ToString();
            string nombrePropiedad = listBox2.SelectedItem.ToString();

            Type tipo = Assembly.GetExecutingAssembly().GetType($"{nombreAsm}.{nombreTipo}");

            Assembly asm = tipo.Assembly;

            Object obj;

            if(radioButton1.Checked)
            {
                obj = asm.CreateInstance(tipo.FullName);
                //Guardo el objeto
                objCreados.Add(obj);

                mostrarListBox4(nombreTipo);
            }
            else
            {
                obj = objCreados[listBox4.SelectedIndex];
            }

            PropertyInfo propiedad = asm.GetType(tipo.FullName).GetProperty(nombrePropiedad);

            if(propiedad.PropertyType == typeof(int))
            {
                propiedad.SetValue(obj, int.Parse(Interaction.InputBox("Ingrese valor de la propiedad: ")));
            }
            else
            {
                propiedad.SetValue(obj, Interaction.InputBox("Ingrese valor de la propiedad: "));
            }
        }

        private void mostrarListBox4(string nombreTipo)
        {
            listBox4.Items.Add($"{nombreTipo} {objCreados.Count}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox4.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un objecto");
                return;
            }

            Object obj = objCreados[listBox4.SelectedIndex];

            if (obj == null)
            {
                MessageBox.Show("No hay objetos creados para leer!!");
                return;
            }

            string nombreTipo = listBox1.SelectedItem.ToString();
            string nombrePropiedad = listBox2.SelectedItem.ToString();

            Type tipo = Assembly.GetExecutingAssembly().GetType($"{nombreAsm}.{nombreTipo}");

            Assembly asm = tipo.Assembly;

            PropertyInfo propiedad = asm.GetType(tipo.FullName).GetProperty(nombrePropiedad);

            if(propiedad.GetValue(obj) == null)
            {
                MessageBox.Show("No se cargaron datos!!");
            }
            else
            {
                MessageBox.Show(propiedad.GetValue(obj).ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un objecto");
                return;
            }

            Object obj = objCreados[listBox4.SelectedIndex];

            string nombreTipo = listBox1.SelectedItem.ToString();
            string nombreMetodo = listBox3.SelectedItem.ToString();

            Type tipo = Assembly.GetExecutingAssembly().GetType($"{nombreAsm}.{nombreTipo}");

            Assembly asm = tipo.Assembly;

            MethodInfo metodo = asm.GetType(tipo.FullName).GetMethod(nombreMetodo);

            ParameterInfo[] parametrosInfo = metodo.GetParameters();

            if(parametrosInfo.Count() == 0)
            {
                MessageBox.Show(metodo.Invoke(obj, null).ToString());
                return;
            }

            Object[] valoresParam = new object[parametrosInfo.Count()];

            foreach(ParameterInfo param in parametrosInfo)
            {
                if(param.ParameterType == typeof(string))
                {
                    valoresParam[param.Position] = Interaction.InputBox($"Ingrese un {param.ParameterType.Name} para el parametro {param.Position + 1}:");
                }
                else
                {
                    valoresParam[param.Position] = int.Parse(Interaction.InputBox($"Ingrese un {param.ParameterType.Name} para el parametro {param.Position + 1}:"));
                }
            }

            MessageBox.Show(metodo.Invoke(obj, valoresParam).ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una propiedad");
                return;
            }

            string nombreTipo = listBox1.SelectedItem.ToString();
            string nombrePropiedad = listBox2.SelectedItem.ToString();

            Type tipo = Assembly.GetExecutingAssembly().GetType($"{nombreAsm}.{nombreTipo}");

            Assembly asm = tipo.Assembly;

            PropertyInfo propiedad = asm.GetType(tipo.FullName).GetProperty(nombrePropiedad);

            MessageBox.Show($"Esta es una propiedad de tipo: {propiedad.PropertyType.Name}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un metodo");
                return;
            }

            string nombreTipo = listBox1.SelectedItem.ToString();
            string nombreMetodo = listBox3.SelectedItem.ToString();

            Type tipo = Assembly.GetExecutingAssembly().GetType($"{nombreAsm}.{nombreTipo}");

            Assembly asm = tipo.Assembly;

            MethodInfo metodo = asm.GetType(tipo.FullName).GetMethod(nombreMetodo);

            string info = $"Nombre: {metodo.Name}{Environment.NewLine}";
            info += $"{Environment.NewLine}Base: {metodo.GetBaseDefinition()}{Environment.NewLine}";

            ParameterInfo retornoInfo = metodo.ReturnParameter;
            info += $"{Environment.NewLine}Valor de retorno: {retornoInfo.ParameterType.Name}{Environment.NewLine}";
            ParameterInfo[] parametrosInfo = metodo.GetParameters();

            foreach (ParameterInfo param in parametrosInfo)
            {
                info += $"{Environment.NewLine}Parametro {param.Position}, Tipo: {param.ParameterType.Name}";
            }

            MessageBox.Show(info);
        }
    }

    [Author("Juana Susacaire")]
    public class Cliente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }

        public string Saludar()
        {
            return $"Hola me llamo {Nombre}";
        }

        public string CumplirAnio()
        {
            Edad++;
            return "Cumpli un año mas!";
        }

        public string Comprar(string producto)
        {
            return $"Acabo de comprar {producto}";
        }

        public string MyMetodo(int num, string str1, string str2)
        {
            return $"Valores cargados: {num}, {str1}, {str2}";
        }
    }

    [Author("Juana Sucasaire")]
    public class Proveedor
    {
        public string RazonSocial { get; set; }
        public string Productos { get; set; }

        public int stock { get; set; }

        public string MostrarProductos()
        {
            if (Productos == null) return null;

            string[] prod = Productos.Split(',');
            string lista = "Productos:";

            foreach (string p in prod)
            {
                lista += $"{Environment.NewLine}{p}";
            }

            return lista;
        }

        public int AumentarStock(int nuevasUnidades) 
        {
            stock = stock + nuevasUnidades;
            return stock;
        }
    }

    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)]
    public class AuthorAttribute : System.Attribute
    {
        private string name;
        public double version;

        public AuthorAttribute(string name)
        {
            this.name = name;
            version = 1.0;
        }
    }
}
