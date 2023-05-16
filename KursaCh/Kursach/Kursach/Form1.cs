using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class Form1 : Form
    {

        DataBase dataBase = new DataBase();
        Func<double, double> f = x => x * x; //integral eq
        DateTime dateTime = DateTime.Now;
        string savePath = Environment.CurrentDirectory + $"\\log{DateTime.Now.ToString("dd/MM/yyyy")}.txt";
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        { 
            lbfuncShower.Text = "x * x";
            savePath = Environment.CurrentDirectory + $"\\log{dateTime.ToString("dd/MM/yyyy")}.txt";
            using (StreamWriter sw = new StreamWriter(savePath))
            {
                sw.WriteLine($"Programm Name: {System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName}" +
                    Environment.NewLine + "Function: x * x" + Environment.NewLine);
            }
        }




        private bool numb_cheker()
        {
            try
            {
                Convert.ToDouble(tAeq.Text);
                Convert.ToDouble(tBeq.Text);
                Convert.ToInt32(tNcount.Text);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Возможно одно из значений не соответствует требованиям");

                tAeq.Text = null;
                tBeq.Text = null;
                tNcount.Text = null;
                return false;
            }
        }

        
        private void butCheb_Click(object sender, EventArgs e)
        {
            if(f == null) return;
            else
            {
                if(tAeq !=null && tBeq !=null && tNcount !=null) 
                {
                    if (!numb_cheker())
                        return;

                    int n_Max = Convert.ToInt32(tNcount.Text);
                    double a_cheb = Convert.ToDouble(tAeq.Text);
                    double b_cheb = Convert.ToDouble(tBeq.Text);

                    dataBase.cheb_a = a_cheb;
                    dataBase.cheb_b = b_cheb;
                    dataBase.cheb_n = n_Max;
                    using(StreamWriter sw = new StreamWriter(savePath, append: true))
                    {
                        sw.WriteLine($"New data{dateTime} Chebushev method:\n");
                        for (int n = 2; n <= n_Max; n++)
                        {
                            double result_chebushev = Methods.Chebushev(a_cheb, b_cheb, n, f);
                            sw.WriteLine($"for n({n})= {result_chebushev}\n");
                            listCheb.Items.Add(result_chebushev);
                        }
                    }
                        
                        
                    
                    
                }
            }
        }

        private void butGauss_Click(object sender, EventArgs e)
        {
            if (f == null) return;
            else
            {
                if (tAeq != null && tBeq != null && tNcount != null)
                {
                    if (!numb_cheker())
                        return;

                    int n_Max = Convert.ToInt32(tNcount.Text);
                    double a_gauss = Convert.ToDouble(tAeq.Text);
                    double b_gauss = Convert.ToDouble(tBeq.Text);

                    dataBase.cheb_a = a_gauss;
                    dataBase.cheb_b = b_gauss;
                    dataBase.cheb_n = n_Max;
                    using (StreamWriter sw = new StreamWriter(savePath, append: true))
                    {
                        sw.WriteLine($"New data{dateTime} Gauss method:\n");
                        for (int n = 2; n <= n_Max; n++)
                        {
                            double result_gauss = Methods.Gauss(a_gauss, b_gauss, n, f);
                            sw.WriteLine($"for n({n})= {result_gauss}\n");
                            listGauss.Items.Add(result_gauss);
                        }
                    }
                    
                }
            }
        }



        private void tAeq_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if(!Char.IsDigit(c) && c != 8 && c != 44)
            {
                e.Handled = true;
            }
            
        }

        private void tAeq_Leave(object sender, EventArgs e)
        {
            if(tAeq.Text != null)
            {
                try
                {
                    Convert.ToDouble(tAeq.Text);
                }
                catch
                {
                    string[] _temp = tAeq.Text.Split(',');
                    tAeq.Text = _temp[0];
                }
            }
            if(tBeq.Text != null)
            {
                try
                {
                    Convert.ToDouble(tBeq.Text);
                }
                catch 
                {
                    string[] _temp = tBeq.Text.Split(',');
                    tBeq.Text = _temp[0];
                }
            }
        }

        private void tNcount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!Char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void tNcount_Leave(object sender, EventArgs e)
        {
            if (tNcount.Text != null)
            {
                try
                {
                    int _temp_n = Convert.ToInt32(tNcount.Text);
                    if(_temp_n <= 2)
                    {
                        tNcount.Text = null;
                    }
                }
                catch
                { 
                    tNcount.Text = null;
                }
            }
        }

        private void bChebClear_Click(object sender, EventArgs e)
        {
            listCheb.Items.Clear();
        }

        private void bGauClear_Click(object sender, EventArgs e)
        {
            listGauss.Items.Clear();
        }

        private void bComparisonClear_Click(object sender, EventArgs e)
        {
            listComparison.Items.Clear();
        }

        private void butComparison_Click(object sender, EventArgs e)
        {
            if(listCheb.Items.Count > 0 && listGauss.Items.Count > 0) 
            {
                listComparison.Items.Clear();

                int[] _max_counter= {listCheb.Items.Count, listGauss.Items.Count};
                if (_max_counter[0] == _max_counter[1])
                    using (StreamWriter sw = new StreamWriter(savePath, append: true))
                    {
                        sw.WriteLine($"New data{dateTime} Gauss method:\n");
                        for (int i = 0; i < _max_counter.Max(); i++)
                        {
                            double cheb = Convert.ToDouble(listCheb.Items[i]);
                            double gauss = Convert.ToDouble(listGauss.Items[i]);

                            double res = Math.Abs(cheb - gauss);
                            sw.WriteLine($"for n({i})= {res}\n");
                            listComparison.Items.Add(res);
                        }
                    }
                else
                    using (StreamWriter sw = new StreamWriter(savePath, append: true))
                    {
                        sw.WriteLine($"New data{dateTime} Gauss method:\n");
                        for (int i = 0; i < _max_counter.Min(); i++)
                        {
                            double cheb = Convert.ToDouble(listCheb.Items[i]);
                            double gauss = Convert.ToDouble(listGauss.Items[i]);

                            double res = Math.Abs(cheb - gauss);
                            sw.WriteLine($"for n({i})= {res}\n");
                            listComparison.Items.Add(res);
                        }
                    }
            }
        }

        private void bPlot_Click(object sender, EventArgs e)
        {
            FormPlot formPlot= new FormPlot(dataBase);
            formPlot.Show();
        }
    }
}
