using KursovayaV4.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KursovayaV4
{
    public partial class Form1 : Form
    {
        private double a, b, h; //Значения для Графиков
        private double a1, b1; //Значения для рассчета по разным методам
        private double x, y; // х у для графиков
        
        Settings settings = new Settings();

        //Массив, который хранит данные для 1 задания
        private double[,] z = new double[2, 4]; //0ая Строка - значения по методу Чебышева, 1ая Строка - значения по методу Гаусса
        
        
        public Form1()
        {
            InitializeComponent();
        }
        private void globalSafe()
        {
            try
            {
                a = Convert.ToDouble(textBox_a.Text);
                b = Convert.ToDouble(textBox_b.Text);
                h = Convert.ToDouble(textBox_h.Text);
                a1 = Convert.ToDouble(textBox_a1.Text);
                b1 = Convert.ToDouble(textBox_b1.Text);

                settings.a = a;
                settings.b = b;
                settings.h = h;
                settings.a1 = a1;
                settings.b1 = b1;

                settings.ColorOfSin = Convert.ToString(this.chart.Series[0].Color);
                settings.ColorOfCos = Convert.ToString(this.chart.Series[1].Color);
                settings.ColorOfTan = Convert.ToString(this.chart.Series[2].Color);

                settings.LineWidthSin = this.chart.Series[0].BorderWidth;
                settings.LineWidthCos = this.chart.Series[1].BorderWidth;
                settings.LineWidthTan = this.chart.Series[2].BorderWidth;

                settings.ChartTypeSin = Convert.ToString(this.chart.Series[0].ChartType);
                settings.ChartTypeCos = Convert.ToString(this.chart.Series[1].ChartType);
                settings.ChartTypeTan = Convert.ToString(this.chart.Series[2].ChartType);

                settings.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
            }

        }
        private void loadSettings()
        {
            settings = Settings.Load();

            this.chart.Series[0].Color = Color.FromName(settings.ColorOfSin);
            this.chart.Series[1].Color = Color.FromName(settings.ColorOfCos);
            this.chart.Series[2].Color = Color.FromName(settings.ColorOfTan);

            this.chart.Series[0].BorderWidth = settings.LineWidthSin;
            this.chart.Series[1].BorderWidth = settings.LineWidthCos;
            this.chart.Series[2].BorderWidth = settings.LineWidthTan;

            this.chart.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), settings.ChartTypeSin);
            this.chart.Series[1].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), settings.ChartTypeCos);
            this.chart.Series[2].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), settings.ChartTypeTan);

            a = settings.a;
            b = settings.b;
            h = settings.h;
            a1 = settings.a1;
            b1 = settings.b1;

            textBox_a.Text = Convert.ToString(a);
            textBox_b.Text = Convert.ToString(b);
            textBox_h.Text = Convert.ToString(h);
            textBox_a1.Text = Convert.ToString(a1);
            textBox_b1.Text = Convert.ToString(b1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_dataCheb.Text = string.Empty;
            loadSettings();

        }

        private void построитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(checkBox_cos.Checked == false && checkBox_sin.Checked == false && checkBox_tan.Checked == false)
            {
                MessageBox.Show("Выберите хотя бы один график!", "Внимание!");
                return;
            }

            try
            {
                a = Convert.ToDouble(textBox_a.Text);
                b = Convert.ToDouble(textBox_b.Text);
                h = Convert.ToDouble(textBox_h.Text);

                if (checkBox_sin.Checked)
                {
                    x = a;
                    this.chart.Series[0].Points.Clear();

                    while(x <= b)
                    {
                        y = Math.Sin(x);
                        this.chart.Series[0].Points.AddXY(x, y);
                        x += h;
                    }

                }

                if (checkBox_cos.Checked)
                {
                    x = a;
                    this.chart.Series[1].Points.Clear();

                    while (x <= b)
                    {
                        y = Math.Cos(x);
                        this.chart.Series[1].Points.AddXY(x, y);
                        x += h;
                    }
                }

                if (checkBox_tan.Checked)
                {
                    x = a;
                    this.chart.Series[2].Points.Clear();

                    while (x <= b)
                    {
                        y = Math.Tan(x);
                        this.chart.Series[2].Points.AddXY(x, y);
                        x += h;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
                MessageBox.Show("Параметры по умолчанию!", "Внимание!");
                a = -10;
                textBox_a.Text = Convert.ToString(a);
                b = 10;
                textBox_b.Text = Convert.ToString(b);
                h = 0.5;
                textBox_h.Text = Convert.ToString(h);

            }
        }

        private void очиститьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBox_cos.Checked == false && checkBox_sin.Checked == false && checkBox_tan.Checked == false)
            {
                MessageBox.Show("Выберите хотя бы один график!", "Внимание!");
                return;
            }

            if (checkBox_cos.Checked)
            {
                this.chart.Series[0].Points.Clear();
            }

            if (checkBox_sin.Checked)
            {
                this.chart.Series[1].Points.Clear();
            }

            if (checkBox_tan.Checked)
            {
                this.chart.Series[2].Points.Clear();
            }

        }

        private void сохранитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            globalSafe();
        }

        private void button_Calc_Click(object sender, EventArgs e)
        {
            
            int n = 5;
            try
            {
                a1 = Convert.ToDouble(textBox_a1.Text);
                b1 = Convert.ToDouble(textBox_b1.Text);

                //Рассчет по методу Чебышева по узлам от 2 до 5
                textBox_dataCheb.Text = string.Empty;
                textBox_dataCheb.Text = "Для функции _/sin(x)dx" + Environment.NewLine;

                x = a1;
                for(int i = 2; i <= n; i++)
                {
                    y = 0;
                    int p = 0; //Переменная для записи данных в массив z[0, p]

                    textBox_dataCheb.Text += $"Для {i} узлов " + Environment.NewLine;
                    for(int j = 0; j < i; j++) 
                    {
                        y += Functions.chebishev(a1, b1, i, j, 0);
                    }
                    y *= (b1 - a1) / i;

                    z[0, p] = y; //Записываем значение в массив для хранения
                    p++;
                    textBox_dataCheb.Text += $"Интеграл sin(x)= {y}" + Environment.NewLine;
                }

                //Рассчет по методу Гаусса по узлам от 2 до 5
                textBox_dataGauss.Text = string.Empty;
                textBox_dataGauss.Text = "Для функции _/sin(x)dx" + Environment.NewLine;

                x = a1;
                for (int i = 2; i <= n; i++)
                {
                    y = 0;
                    int p = 0; //Переменная для записи данных в массив z[1, p]

                    textBox_dataGauss.Text += $"Для {i} узлов " + Environment.NewLine;
                    for (int j = 0; j < i; j++)
                    {
                        y += Functions.gauss(a1, b1, i, j, 0);
                        Console.WriteLine($"y[{i}][{j}]= {y} ");
                    }
                    y *= (b1 - a1) / 2;
                    z[1, p] = y; //Записываем значение в массив для хранения
                    p++;
                    textBox_dataGauss.Text += $"Интеграл sin(x)= {y}" + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка данных");
                textBox_a1.Text = string.Empty;
                textBox_b1.Text = string.Empty;
            }

            
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_dataCheb.Text = string.Empty;
            textBox_dataGauss.Text = string.Empty;
            textBox_accuracy.Text = string.Empty;
        }

        private void button_accuracy_Click(object sender, EventArgs e)
        {
            textBox_accuracy.Text = string.Empty;

            textBox_accuracy.Text = "Для функции y= sin(x), ошибка метода Чебышева составила:" + Environment.NewLine;
            for(int i = 0; i < z.Length/2; i++)
            {
                textBox_accuracy.Text +=  $"Для {i}х узлов delA= {Math.Abs(z[0, i] - z[1,i])}" + Environment.NewLine;
            }
        }

        
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите выйти, данные без сохранения уйдут навечно PoroSad?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Хотите сохранить данные перед выходом???_?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    globalSafe();
                Application.Exit();
            }
        }

        
    }
}
