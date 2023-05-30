using KursovayaV4.Properties;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace KursovayaV4
{
    public partial class Form1 : Form
    {
        private double x, y; // х у для графиков

        private string logsDirect = Directory.GetCurrentDirectory() + "/logs"; //Папка, в которой хранятся файлы с данными о вычислениях
        private string logsName = DateTime.Now.ToString("yyyyMMdd") + ".txt"; //Имя файла в которой хранятся данные о вычислениях

        Settings settings = new Settings();

        private static int integral_methods = 2; //Количество методов
        private static int quant_nodes = 4;   //Количество используемых узлов
        private static int quant_formuls = 3;    //Количество формул
        
        private double[,,] z = new double[integral_methods, quant_nodes, quant_formuls]; //Массив, который хранит данные для 1 задания



        //Общие настройки
        public Form1()
        {
            InitializeComponent();
        }
        private void globalSafe()
        {
            try
            {
                settings.a = Convert.ToDouble(textBox_a.Text);
                settings.b = Convert.ToDouble(textBox_b.Text);
                settings.h = Convert.ToDouble(textBox_h.Text);
                settings.a1 = Convert.ToDouble(textBox_a1.Text);
                settings.b1 = Convert.ToDouble(textBox_b1.Text);
                settings.eps = Convert.ToDouble(textBox_epsilon.Text);

                settings.ColorOfSin = typeof(Color).GetProperty("Name").GetValue(this.chart.Series[0].Color).ToString();
                settings.ColorOfCos = typeof(Color).GetProperty("Name").GetValue(this.chart.Series[1].Color).ToString();
                settings.ColorOfTan = typeof(Color).GetProperty("Name").GetValue(this.chart.Series[2].Color).ToString();


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

            textBox_a.Text = Convert.ToString(settings.a);
            textBox_b.Text = Convert.ToString(settings.b);
            textBox_h.Text = Convert.ToString(settings.h);
            textBox_a1.Text = Convert.ToString(settings.a1);
            textBox_b1.Text = Convert.ToString(settings.b1);
            textBox_epsilon.Text = Convert.ToString(settings.eps);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_dataCheb.Text = string.Empty;
            loadSettings();

            comboBox_chartType.Items.Add("Point");
            comboBox_chartType.Items.Add("Line");
            comboBox_chartType.Items.Add("Spline");

            double g = -10;
            chart_demo.Series[0].Points.Clear();
            while (g <= 10)
            {
                chart_demo.Series[0].Points.AddXY(g, Math.Sin(g));
                g += 1;
            }
        }

        
        //Работа с методами
        private void button_Calc_Click(object sender, EventArgs e)
        {
            try
            {
                settings.a1 = Convert.ToDouble(textBox_a1.Text);
                settings.b1 = Convert.ToDouble(textBox_b1.Text);
                settings.eps= Convert.ToDouble(textBox_epsilon.Text);

                //Рассчет по методу Чебышева по узлам от 2 до 5
                textBox_dataCheb.Text = string.Empty;
                

                x = settings.a1;
                for (int i = 0; i < quant_formuls; i++)
                {
                    textBox_dataCheb.Text = "=========Для функции _/sin(x)dx===============" + Environment.NewLine +
                        "n\tChebishev\t\tGauss";

                    for (int j = 0; j < quant_nodes; j++)
                    {
                        x = Functions.chebishev(settings.a1, settings.b1, settings.eps, j, i);
                        
                    }

                    Console.WriteLine($"chebishev= {x} ");
                }

                //Рассчет по методу Гаусса по узлам от 2 до 5
                textBox_dataGauss.Text = string.Empty;
                textBox_dataGauss.Text = "Для функции _/sin(x)dx" + Environment.NewLine;

                x = settings.a1;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка данных");
                textBox_a1.Text = string.Empty;
                textBox_b1.Text = string.Empty;
                textBox_epsilon.Text = string.Empty;
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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(!Directory.Exists(logsDirect))
                    Directory.CreateDirectory(logsDirect);

                using (FileStream fs = new FileStream(logsDirect + "/" + logsName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("");



                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
            
        }



        //Работа с графиками и меню
        private void построитьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBox_cos.Checked == false && checkBox_sin.Checked == false && checkBox_tan.Checked == false)
            {
                MessageBox.Show("Выберите хотя бы один график!", "Внимание!");
                return;
            }

            try
            {
                settings.a = Convert.ToDouble(textBox_a.Text);
                settings.b = Convert.ToDouble(textBox_b.Text);
                settings.h = Convert.ToDouble(textBox_h.Text);

                if (checkBox_sin.Checked)
                {
                    x = settings.a;
                    this.chart.Series[0].Points.Clear();

                    while (x <= settings.b)
                    {
                        this.chart.Series[0].Points.AddXY(x, Functions.first_func(x));
                        x += settings.h;
                    }

                }

                if (checkBox_cos.Checked)
                {
                    x = settings.a;
                    this.chart.Series[1].Points.Clear();

                    while (x <= settings.b)
                    {
                        this.chart.Series[1].Points.AddXY(x, Functions.second_func(x));
                        x += settings.h;
                    }
                }

                if (checkBox_tan.Checked)
                {
                    x = settings.a;
                    this.chart.Series[2].Points.Clear();

                    while (x <= settings.b)
                    {
                        this.chart.Series[2].Points.AddXY(x, Functions.third_func(x));
                        x += settings.h;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!");
                MessageBox.Show("Параметры по умолчанию!", "Внимание!");
                settings.a = -10;
                textBox_a.Text = Convert.ToString(settings.a);
                settings.b = 10;
                textBox_b.Text = Convert.ToString(settings.b);
                settings.h = 0.5;
                textBox_h.Text = Convert.ToString(settings.h);

            }
        }

        private void очиститьГрафикToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBox_cos.Checked == false && checkBox_sin.Checked == false && checkBox_tan.Checked == false)
            {
                MessageBox.Show("Выберите хотя бы один график!", "Внимание!");
                return;
            }

            if (checkBox_sin.Checked)
            {
                this.chart.Series[0].Points.Clear();
            }

            if (checkBox_cos.Checked)
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

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти, данные без сохранения уйдут навечно PoroSad?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (MessageBox.Show("Хотите сохранить данные перед выходом?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    globalSafe();
                Application.Exit();
            }
        }
        private void загрузитьПоследниеНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadSettings();
        }


        //Настройка графика
        private void comboBox_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            0 - blue
            1 - red
            2 - green
            3 - yellow
            4 - black
             */
            chart_demo.Series[0].Color = Color.FromName(comboBox_color.SelectedItem.ToString());
        }

        private void numericUpDown_borderWidth_ValueChanged(object sender, EventArgs e)
        {
            chart_demo.Series[0].BorderWidth = Convert.ToInt32(numericUpDown_borderWidth.Value);
        }

        private void comboBox_chartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart_demo.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBox_chartType.SelectedItem.ToString());
        }

        private void comboBox_chartChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            int u = comboBox_chartChoose.SelectedIndex;

            comboBox_chartType.SelectedIndex = 2;
            numericUpDown_borderWidth.Value = chart.Series[u].BorderWidth;
            comboBox_color.SelectedIndex = u;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
             0 - sin(x)
             1 - 1/x
             2 - x**2
             */

            if(comboBox_chartChoose.SelectedIndex !=-1)
            {
                int u = comboBox_chartChoose.SelectedIndex;  //Выбранный пользователем график

                this.chart.Series[u].Color = Color.FromName(comboBox_color.SelectedItem.ToString()); //Преобразование цвета выбранного графика

                this.chart.Series[u].BorderWidth = Convert.ToInt32(numericUpDown_borderWidth.Value); //Преобразование размера линии графика

                this.chart.Series[u].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), comboBox_chartType.SelectedItem.ToString()); //Преобразование типа графика

            }
        }
    }
}
