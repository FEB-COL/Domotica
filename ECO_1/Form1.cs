using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
namespace ECO_1
{
    public partial class Form1 : Form
    {
        bool config = false;

        public Form1()
        {
            
            InitializeComponent();
            inicializarPropiedades();
        }
        public static void borrar()
        {
            /*
            string myString = textBox1.Text;
            if (myString == string.Empty)
            {
                myString = "";
            }
             */
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Posibles_Puertos();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (textBox1.Text != null)
            {
                textBox1.Text = "";
            }
        }
        private void inicializarPropiedades()
        {
            try
            {
                #region inicializar BaudRate
                for (int i = 0; i < comboBox2.Items.Count; i++)
                {
                    if (int.Parse(comboBox2.Items[i].ToString()) == serialPort1.BaudRate)
                    {
                        comboBox2.SelectedIndex = i;
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Posibles_Puertos()
        {
            for (int i = 0; i < 20; i++)
            {
                serialPort1.PortName = "COM" + i;
                try
                {
                    serialPort1.Open();
                    comboBox1.Items.Add("COM" + i);
                    serialPort1.Close();
                }
                catch (Exception) { }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (button1.Text.Equals("Abrir"))
            {

                if (comboBox1.SelectedIndex != -1)
                {
                    serialPort1.PortName = comboBox1.SelectedItem.ToString();
                    try
                    {
                        serialPort1.Open();
                        inicializarPropiedades();
                        config = true;
                        comboBox1.Enabled = false;
                        button1.Text = "Cerrar";

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el puerto que desea abrir");
                }

            }
            else
            {
                try
                {
                    serialPort1.Close();
                    comboBox1.Items.Clear();
                    Posibles_Puertos();
                    comboBox1.Enabled = true;
                    button1.Text = "Abrir";
                    config = false;

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }


            }
            this.Cursor = Cursors.Default;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort1.BaudRate = Convert.ToInt32(comboBox2.SelectedItem.ToString());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
