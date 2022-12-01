using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Microsoft.VisualBasic;

namespace PracticaSubprocesosThreads
{
    public partial class Form1 : Form
    {
        List<Thread> hilos;
        List<CancellationTokenSource> cancellationTokenSources;
        public Form1()
        {
            InitializeComponent();
            hilos = new List<Thread>();
            cancellationTokenSources = new List<CancellationTokenSource>();
            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(ImprimirNumero);
            hilos.Add(t);

            string nombreHilo = Interaction.InputBox("Nombre del Hilo: ");
            listBox2.Items.Add(nombreHilo);
            InfoSubproceso info = new InfoSubproceso();
            info.nombreHilo = nombreHilo;
            info.indexCCToken = listBox2.Items.Count - 1;

            t.Start(info);
        }

        private void ImprimirNumero(Object obj)
        {
            int count = 1;
            InfoSubproceso info = obj as InfoSubproceso;

            CancellationTokenSource cc = new CancellationTokenSource();
            cancellationTokenSources.Add(cc);

            while (true)
            {
                listBox1.Items.Add($"{info.nombreHilo} : {count++}");
                System.Threading.Thread.Sleep(1000);
                if (cancellationTokenSources[info.indexCCToken].IsCancellationRequested == true) break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox2.SelectedItems.Count == 0) return;
            hilos[listBox2.SelectedIndex].Abort();
            hilos.Remove(hilos[listBox2.SelectedIndex]);
            listBox2.Items.Remove(listBox2.SelectedItem);
        }
    }

    public class InfoSubproceso
    {
        public int indexCCToken { get; set; }
        public string nombreHilo { get; set; }
    }
}
