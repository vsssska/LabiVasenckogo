using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kursach
{
    public partial class FormPlot : Form
    {
        DataBase data;
        Series series1 = new Series();
        Func<double, double> f = x => x * x; //integral eq
        public FormPlot(DataBase dataBase)
        {
            data = dataBase;
            InitializeComponent();
        }

        private void FormPlot_Load(object sender, EventArgs e)
        {
            
            chart1.Parent = this;
            chart1.Dock = DockStyle.None;
            chart1.Visible= false;

            // Добавление серии данных
            
            chart1.Series[0].Name = series1.Name;
            chart1.Series[0].ChartType= SeriesChartType.Line;
            chart1.Series[0].Color = Color.Blue;

            series1.Name = "Series1";
            series1.ChartType = SeriesChartType.Line;
            series1.Color = Color.Red;
            chart1.Series.Add(series1);

           

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if(!Char.IsDigit(c) && c != 8)
            {
                e.Handled = true;
            }
        }

        private void bColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                chart1.Series[0].Color= cd.Color;
            }
            
        }

        private void bChartShow_Click(object sender, EventArgs e)
        {
            
            for (int n = 2; n <= data.gauss_n; n++)
            {
                double result_gauss = Methods.Gauss(data.gauss_a, data.gauss_b, n, f);
                this.chart1.Series[0].Points.AddXY(n, result_gauss);
            }

            for (int n = 2; n <= data.cheb_n; n++)
            {
                double result_gauss = Methods.Gauss(data.cheb_a, data.cheb_b, n, f);
                this.chart1.Series[1].Points.AddXY(n, result_gauss);
            }



            chart1.Visible = true;
        }

        private void bMaxAccept_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas[0].AxisX.Minimum = 0;
                chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(textBox1.Text);
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(textBox2.Text);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
