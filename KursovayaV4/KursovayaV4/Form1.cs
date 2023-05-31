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
        private double x; // х для графиков

        private string logsDirect = Directory.GetCurrentDirectory() + "/logs"; //Папка, в которой хранятся файлы с данными о вычислениях
        private string logsName = DateTime.Now.ToString("yyyyMMdd") + ".txt"; //Имя файла в которой хранятся данные о вычислениях

        Settings settings = new Settings();

        private static int integral_methods; //Количество методов
        private static int quant_nodes;      //Количество используемых узлов
        private static int quant_formuls;    //Количество формул
        
        
        public double[,,] z; //Массив хранения данных о расчетах с помощью различных методов
        

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

                settings.ColorOfFirstfunc  = typeof(Color).GetProperty("Name").GetValue(this.chart.Series[0].Color).ToString();
                settings.ColorOfSecondfunc = typeof(Color).GetProperty("Name").GetValue(this.chart.Series[1].Color).ToString();
                settings.ColorOfThirdfunc  = typeof(Color).GetProperty("Name").GetValue(this.chart.Series[2].Color).ToString();


                settings.LineWidthFirstfunc = this.chart.Series[0].BorderWidth;
                settings.LineWidthSecondfunc = this.chart.Series[1].BorderWidth;
                settings.LineWidthThirdfunc = this.chart.Series[2].BorderWidth;

                settings.ChartTypeFirstfunc = Convert.ToString(this.chart.Series[0].ChartType);
                settings.ChartTypeSecondfunc = Convert.ToString(this.chart.Series[1].ChartType);
                settings.ChartTypeThirdfunc = Convert.ToString(this.chart.Series[2].ChartType);

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

            this.chart.Series[0].Color = Color.FromName(settings.ColorOfFirstfunc);
            this.chart.Series[1].Color = Color.FromName(settings.ColorOfSecondfunc);
            this.chart.Series[2].Color = Color.FromName(settings.ColorOfThirdfunc);

            this.chart.Series[0].BorderWidth = settings.LineWidthFirstfunc;
            this.chart.Series[1].BorderWidth = settings.LineWidthSecondfunc;
            this.chart.Series[2].BorderWidth = settings.LineWidthThirdfunc;

            this.chart.Series[0].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), settings.ChartTypeFirstfunc);
            this.chart.Series[1].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), settings.ChartTypeSecondfunc);
            this.chart.Series[2].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), settings.ChartTypeThirdfunc);

            textBox_a.Text = Convert.ToString(settings.a);
            textBox_b.Text = Convert.ToString(settings.b);
            textBox_h.Text = Convert.ToString(settings.h);
            textBox_a1.Text = Convert.ToString(settings.a1);
            textBox_b1.Text = Convert.ToString(settings.b1);
            textBox_epsilon.Text = Convert.ToString(settings.eps);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox_dataCalc.Text = string.Empty;
            loadSettings(); //Загружаем последние сохраненные настройки

            comboBox_chartType.Items.Add("Point");
            comboBox_chartType.Items.Add("Line");
            comboBox_chartType.Items.Add("Spline");

            //График для предпросмотра
            double g = -10;
            chart_demo.Series[0].Points.Clear();
            while (g <= 10)
            {
                chart_demo.Series[0].Points.AddXY(g, Math.Sin(g));
                g += 1;
            }

            integral_methods = checkedListBox_methods.Items.Count;  //Заполняется кол-вом методов из чек листа
            quant_nodes = checkedListBox_nodes.Items.Count;         //Заполняется кол-вом узлов из чек листа
            quant_formuls = checkedListBox_funcs.Items.Count;       //Заполняется кол-вом формул из чек листа

            z = new double[quant_nodes, integral_methods + 1, quant_formuls]; //Создание массива для дальнейшего использования
        }

        
        //Работа с методами
        private void button_Calc_Click(object sender, EventArgs e)
        {
            try
            {
                settings.a1 = Convert.ToDouble(textBox_a1.Text);
                settings.b1 = Convert.ToDouble(textBox_b1.Text);
                settings.eps= Convert.ToDouble(textBox_epsilon.Text);

                textBox_dataCalc.Text = string.Empty;

                //Идем по списку выделенных методов
                foreach (int method in checkedListBox_methods.CheckedIndices)
                {

                    textBox_dataCalc.Text += $"========={checkedListBox_methods.Items[method]}===============" + Environment.NewLine;

                    //Идем по списку выделенных функций
                    foreach (int func in checkedListBox_choosedFuncs.CheckedIndices)
                    {
                        textBox_dataCalc.Text += $"Для функции {checkedListBox_funcs.Items[func]}" + Environment.NewLine 
                            + $"n\ty" + Environment.NewLine;

                        //Идем по списку выделенных узлов
                        foreach (int node in checkedListBox_nodes.CheckedIndices)
                        {
                            z[node, method, func] = Functions.calc_func(settings.a1, settings.b1, settings.eps, node + 2, func, method);
                            textBox_dataCalc.Text += $"{node+2}\t{z[node, method, func]}" + Environment.NewLine;
                        }
                    }

                }
                
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
            textBox_dataCalc.Text = string.Empty;
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
                        //Перемещаем курсор в конец файла, чтобы сохранить предыдущие расчеты
                        sw.BaseStream.Seek(0, SeekOrigin.End);

                        //Запись времени запуска вычислений
                        sw.WriteLine($"======={DateTime.Now.ToString("HH:mm:sss")}=========" + Environment.NewLine);

                        //Запись изначальных данных
                        sw.WriteLine($"a= {settings.a1}" + Environment.NewLine +
                            $"b= {settings.b1}" + Environment.NewLine +
                            $"eps= {settings.eps}" + Environment.NewLine);

                        //Идем по списку выделенных методов
                        foreach (int method in checkedListBox_methods.CheckedIndices)
                        {

                            sw.WriteLine($"========={checkedListBox_methods.Items[method]}===============" + Environment.NewLine);

                            //Идем по списку выделенных функций
                            foreach (int func in checkedListBox_choosedFuncs.CheckedIndices)
                            {
                                sw.WriteLine($"Для функции {checkedListBox_funcs.Items[func]}" + Environment.NewLine
                                    + $"n\ty" + Environment.NewLine);

                                //Идем по списку выделенных узлов
                                foreach (int node in checkedListBox_nodes.CheckedIndices)
                                {
                                    sw.WriteLine($"{node + 2}\t{z[node, method, func]}" + Environment.NewLine);
                                }
                            }

                        }

                    }    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!");
            }
            
        }



        //Работа с графиками и меню
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
        private void checkedListBox_funcs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                try
                {
                    settings.a = Convert.ToDouble(textBox_a.Text);
                    settings.b = Convert.ToDouble(textBox_b.Text);
                    settings.h = Convert.ToDouble(textBox_h.Text);
                    x = settings.a;
                    this.chart.Series[checkedListBox_funcs.SelectedIndex].Points.Clear();

                    while (x <= settings.b)
                    {
                        this.chart.Series[checkedListBox_funcs.SelectedIndex].Points.AddXY(x, Functions.graph_func(x, checkedListBox_funcs.SelectedIndex));
                        x += settings.h;
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
            else
            {
                this.chart.Series[checkedListBox_funcs.SelectedIndex].Points.Clear();
            }
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
