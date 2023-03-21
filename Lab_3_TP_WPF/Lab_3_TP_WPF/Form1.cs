using Lab_3_TP_WPF.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_3_TP_WPF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void StartP(double a, double h)
        {
            double[] x = new double[1000];
            double c = 0;
            await Task.Run(() =>
            {
                
                for (int i = 0; i < 1000; i++)
                {
                    try
                    {
                        c = a + h*i;
                        x[i] = Class1.F1(c) + Class1.F2(c) + Class1.F3(c) + Class1.F4(c);
                        
                        
                    }
                    catch (Exception e)
                    {
                        string msg = e.ToString();
                        string caption = "Error Detected in Input";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(msg, caption, buttons);
                        if (result == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }
                }
            });
            for (int i = 0; i < 1000; i++)
            {
                listBox1.Items.Add("x" + a+h + "= " + x[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = 0;
            double b = 1000;

            try
            {
                double u = Math.Abs(a-b)/Int32.Parse(textBox1.Text);
                StartP(a, u);
            }
            catch (FormatException ex) 
            {
                string msg = ex.ToString();
                string caption = "Error Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(msg, caption, buttons);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {
                    textBox1.Focus();
                    textBox1.Text = "";
                }
                //textBox1.Text = ex.ToString();
            }
        }
    }
}
