﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodosOrdenamiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        Stopwatch tiempo = new Stopwatch();
        DateTime dt1, dt2=new DateTime();
        TimeSpan dt3 = new TimeSpan();
        vectorOrden generador=new vectorOrden();
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox4.Items.Clear();
            tiempo.Start();
            int p = int.Parse(textBox1.Text);
            generador.crear(p);

            tiempo.Stop();
            if (checkBox1.Checked && p < 60000)
            {
                for (int i = 0; i < p / 2; i++)
                {
                    listBox1.Items.Add(generador.elVector()[i].ToString());
                }
                for (int i = p / 2; i < p; i++)
                {
                    listBox4.Items.Add(generador.elVector()[i].ToString());
                }
            }
            else if (p >= 60000) { MessageBox.Show("el vector es muy grande para mostrar"); }
            
            listBox3.Items.Add(string.Format("Tiempo generando el vector: {0}", tiempo.Elapsed.TotalSeconds));
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsNumber(e.KeyChar)|| e.KeyChar == (char)8|| char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox5.Items.Clear();
            if (radioButton1.Checked) //burbuja
            {
                dt1 = DateTime.Now;
                generador.burbuja();
            }
            else if (radioButton2.Checked) //insercion ((muy parecido a burbuja)
            {
                dt1 = DateTime.Now;
                generador.Seleccion();
            }
            else if (radioButton3.Checked)//merge
            {
                dt1 = DateTime.Now;
                generador.MergeSort();
            }
            else if (radioButton4.Checked)
            {
                dt1 = DateTime.Now;
                generador.quickiterativo();
            }
            else if (radioButton5.Checked)
            {
                dt1 = DateTime.Now;
                generador.quick();
            }
            else if (radioButton6.Checked)
            {
                generador.burbuja();
                generador.quick();
                generador.quickiterativo();
                generador.Seleccion();
                generador.MergeSort();
            }
            dt2 = DateTime.Now;
            dt3 = dt2 - dt1;
           if (checkBox1.Checked && generador.elVector().Length < 50000)
            {
                for (int i = 0; i < generador.elVector().Length / 2; i++)
                {
                    listBox2.Items.Add(generador.elVector()[i].ToString());
                }
                for (int i = generador.elVector().Length / 2; i < generador.elVector().Length; i++)
                {
                    listBox5.Items.Add(generador.elVector()[i].ToString());
                }
            }
            else if (generador.elVector().Length < 50000) { MessageBox.Show("el vector es muy grande para mostrar"); }
           /* listBox3.Items.Add(string.Format("Tiempo Ordenando el vector: {0}", dt3.TotalSeconds));
            listBox3.Items.Add(string.Format("comparaciones {0} intercambios {1}",
                generador.Comparaciones[0], generador.Intercambios[0]));*/
            generador.calculotiempo();
            for(int i = 0; i < 5; i++)
            {
                if (i == 0) listBox3.Items.Add("BURBUJA");
                if (i == 1) listBox3.Items.Add("Seleccion");
                if (i == 2) listBox3.Items.Add("merge");
                if (i == 3) listBox3.Items.Add("QUICK ITERATIVO");
                if (i == 4) listBox3.Items.Add("QUICKSHORT RECURSIVO");
                listBox3.Items.Add(string.Format("tiempo ordenando "+ generador.Tiempos[i]));
                listBox3.Items.Add(string.Format("comparaciones "+ generador.Comparaciones[i]));

                listBox3.Items.Add(string.Format("intercambios " + generador.Intercambios[i]));
            }
        }
    }
}
