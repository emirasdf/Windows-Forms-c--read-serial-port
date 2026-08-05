using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialRead
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGreen;
            button2.BackColor = Color.IndianRed;
            button3.BackColor = Color.GreenYellow;


            serialPort1.BaudRate = 9600;
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {

                comboBox1.Items.Add(port);  

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("Serial port not opened or already open!");
            }

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string veri = serialPort1.ReadLine();
            string veri2 = serialPort1.ReadLine();

            this.Invoke(new Action(() =>
            {
                textBox1.Text = ("Temp\u00B0C "+veri);
                textBox2.Text = ("Humidity "+veri2);

            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                textBox1.Clear();
                textBox2.Clear();
            }
            catch
            {
                MessageBox.Show("Error occurred while closing serial port or already closed!");
            }

        }

        private void button3_Click(object sender, EventArgs e) //Select serial port from combobox
        {

            try
            {
               if (comboBox1 != null)
                {
                    
                }
               else
                {
                    serialPort1.PortName = comboBox1.SelectedItem.ToString();

                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Please select a port!");
            }
        }
    }
}
