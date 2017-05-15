using SbsSW.SwiPlCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexioPL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\bin");
            string[] p = { "-q", "-f", @"Puzle2.pl" };
            PlEngine.Initialize(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string valor1 = textBox1.Text;
            string valor2 = textBox2.Text;
            listBox1.Items.Clear();
            PlQuery cargar = new PlQuery("cargar('Puzle2.bd')");
            cargar.NextSolution();

            if (checkBox1.Checked == true)
            {
                PlQuery consulta1 = new PlQuery("resolveramp(" + valor1 + "," + valor2 + ")");
                consulta1.NextSolution();

                
            }
            if (checkBox2.Checked == true)
            {
                PlQuery consulta2 = new PlQuery("resolverpro(" + valor1 + "," + valor2 + ")");
                consulta2.NextSolution();
            }

            List<string> Entrada = LeerArchivo();
            char[] seps = new char[] { '[',']',',' };
            List<string> numbers = Entrada[0].Split(seps).ToList<string>();
            List<string> numbers2 = new List<string>();
            foreach (var i in numbers)
            {
                if (i != "")
                {
                    numbers2.Add(i);
                }
            }
        }

        private List<string> LeerArchivo()
        {
            StreamReader sr = null;
            string entrada;
            List<string> entradas = new List<string>();
            try
            {
                sr = new StreamReader(@"C:\\Users\\EliteBook\\Documents\\Prolog\\salida.txt");
                entrada = sr.ReadLine();
                while (entrada != null)
                {
                    entradas.Add(entrada);
                    entrada = sr.ReadLine();
                }
                return entradas;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
        }
    }
}
