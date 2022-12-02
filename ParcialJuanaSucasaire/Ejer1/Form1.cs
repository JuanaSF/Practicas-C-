using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ejer1
{
    public class Info
    {
        public int Index { get; set; }
        public TextBox textBox { get; set; }
    }

    public partial class Form1 : Form
    {
        List<Thread> threads;
        List<CancellationTokenSource> ccTokens;
        List<TextBox> textBoxes;
        int numTextBox = 1;
        int posicionYTxBox = 0;
        int posicionXTxBox = 400;
        int index;

        Random r;

        public Form1()
        {
            InitializeComponent();
            threads = new List<Thread>();
            ccTokens = new List<CancellationTokenSource>();
            textBoxes = new List<TextBox>();
            r = new Random();

            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreHilo = Interaction.InputBox("Ingrese nombre del Hilo: ");

                listBox1.Items.Add(nombreHilo);

                Thread thread = new Thread(CorrerSubproceso);
                threads.Add(thread);

                posicionYTxBox += 30;
                TextBox txBox = new TextBox();
                txBox.Name = $"TextBox{numTextBox++}";
                txBox.Location = new System.Drawing.Point(posicionXTxBox, posicionYTxBox);
                txBox.Size = new System.Drawing.Size(100, 20);
                txBox.TabIndex = 4;
                Controls.Add(txBox);
                textBoxes.Add(txBox);

                Info info = new Info();
                info.Index = listBox1.Items.Count - 1;
                info.textBox = txBox;

                thread.Start(info);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

        }

        private void CorrerSubproceso(Object infoProces)
        {
            Info info = infoProces as Info;

            CancellationTokenSource cctoken = new CancellationTokenSource();
            ccTokens.Add(cctoken);

            TextBox txBox = info.textBox;

            int red;
            int green;
            int blue;

            while (true)
            {
                red = r.Next(256);
                green = r.Next(256);
                blue = r.Next(256);

                txBox.BackColor = Color.FromArgb(red, green, blue);
                Thread.Sleep(1000);

                if (cctoken.IsCancellationRequested == true)
                {
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un proceso");
                return;
            }

            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No hay procesos para parar!");
                return;
            }

            ccTokens[listBox1.SelectedIndex].Cancel();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items == null || listBox1.SelectedItem == null)
                {
                    MessageBox.Show("No es posible borrar!");
                    return;
                }

                ccTokens.Remove(ccTokens[listBox1.SelectedIndex]);

                TextBox tBEliminar = textBoxes[listBox1.SelectedIndex];

                Controls.Remove(tBEliminar);
                textBoxes.Remove(tBEliminar);

                if(textBoxes.Count == 0)
                {
                    posicionYTxBox = 0;
                }

                listBox1.Items.Remove(listBox1.SelectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // textBox1

        //this.textBox1.BackColor = System.Drawing.SystemColors.Window;
        //     this.textBox1.Location = new System.Drawing.Point(412, 32);
        //     this.textBox1.Name = "textBox1";
        //     this.textBox1.Size = new System.Drawing.Size(100, 20);
        //     this.textBox1.TabIndex = 4;
    }
}
