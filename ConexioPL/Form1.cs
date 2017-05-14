using SbsSW.SwiPlCs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                // PlQuery consulta1 = new PlQuery("resolveramp("+ valor1 + ","+ valor2 +")");
                PlQuery consulta1 = new PlQuery("resolveramp(" + valor1 + "," + valor2 + ")");
                foreach (PlTermV z in consulta1.Solutions)
                {
                    listBox1.Items.Add(z[0].ToString());
                }
            }
            if (checkBox2.Checked == true)
            {
                PlQuery consulta2 = new PlQuery("resolverpro(" + valor1 + "," + valor2 + ")");
                foreach (PlQueryVariables z in consulta2.SolutionVariables)
                {
                    listBox1.Items.Add(z.ToString());
                }
            }
        }
    }
}
