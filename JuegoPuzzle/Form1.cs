using SbsSW.SwiPlCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JuegoPuzzle
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer tiempo = new System.Windows.Forms.Timer();
        int z = 0;
        List<string> filtro;
        public Form1()
        {
            InitializeComponent();
            tiempo.Tick += Tiempo_Tick;
            tiempo.Interval= 1500;
        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {
            tiempo.Stop();
            if (z == filtro.Count)
            {
                tiempo.Stop();
                MessageBox.Show("Se termino la aminación","Información",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBox19.Text = filtro[z];
                textBox20.Text = filtro[z + 1];
                textBox21.Text = filtro[z + 2];
                textBox22.Text = filtro[z + 3];
                textBox23.Text = filtro[z + 4];
                textBox24.Text = filtro[z + 5];
                textBox25.Text = filtro[z + 6];
                textBox26.Text = filtro[z + 7];
                textBox27.Text = filtro[z + 8];
                z = z + 9;
                tiempo.Start();
            }

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Environment.SetEnvironmentVariable("Path", @"C:\\Program Files (x86)\\swipl\bin");
            string[] p = { "-q", "-f", @"Puzle2.pl" };
            PlEngine.Initialize(p);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string e1 = textBox1.Text, e2 = textBox2.Text, e3 = textBox3.Text;
            string e4 = textBox4.Text, e5 = textBox5.Text, e6 = textBox6.Text;
            string e7 = textBox7.Text, e8 = textBox8.Text, e9 = textBox9.Text;

            string s1 = textBox10.Text, s2 = textBox11.Text, s3 = textBox12.Text;
            string s4 = textBox13.Text, s5 = textBox14.Text, s6 = textBox15.Text;
            string s7 = textBox16.Text, s8 = textBox17.Text, s9 = textBox18.Text;

            string entrada = "[" + e1 + "," + e2 + "," + e3 + "," + e4 + "," + e5 + "," + e6 + "," + e7 + "," + e8 + "," + e9 + "]";
            string salida = "[" + s1 + "," + s2 + "," + s3 + "," + s4 + "," + s5 + "," + s6 + "," + s7 + "," + s8 + "," + s9 + "]";

            LimpiarSolucion();

            PlQuery cargar = new PlQuery("cargar('Puzle2.bd')");
            cargar.NextSolution();

            if (radioButton1.Checked == true)
            {
                PlQuery consulta1 = new PlQuery("resolveramp(" + entrada + "," + salida + ")");
                consulta1.NextSolution();
                MessageBox.Show("Se termino el proceso de prolog", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton2.Checked == true)
            {
                PlQuery consulta2 = new PlQuery("resolverpro(" + entrada + "," + salida + ")");
                consulta2.NextSolution();
                MessageBox.Show("Se termino el proceso de prolog", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            List<string> solucion = LeerArchivo();
            filtro = Filtrar(solucion);
            tiempo.Start();
        }
        
        private List<string> Filtrar(List<string> solucion)
        {
            char[] seps = new char[] { '[', ']', ',' };
            List<string> numbers = solucion[0].Split(seps).ToList<string>();
            List<string> numbers2 = new List<string>();
            foreach (var i in numbers)
            {
                if (i != "")
                {
                    numbers2.Add(i);
                }
            }
            return numbers2;
        }

        private List<string> LeerArchivo()
        {
            StreamReader sr = null;
            string entrada;
            List<string> entradas = new List<string>();
            try
            {
                sr = new StreamReader(@"C:\\Users\\EliteBook\\salida.txt");
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

        private void LimpiarSolucion()
        {
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
        }
    }
}
