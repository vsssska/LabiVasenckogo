using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Windows.Forms.DataVisualization.Charting;

namespace kolockvium
{
    public partial class Form1 : Form
    {
        int N = 20;
        double[,] A;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxRow.Items.Add("Строка");
            comboBoxRow.Items.Add("Столбец");
            comboBoxRow.SelectedIndex= 0;
        }

        private void textBoxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if(!Char.IsDigit(number) && number != 8 && number != 44)
                e.Handled = true;
        }

        private void textBoxRowIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if(!Char.IsDigit(number) && number != 8)
                e.Handled = true;
        }

        private void textBoxMin_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(textBoxMin.Text);
            }
            catch 
            {
                textBoxMin.Text= string.Empty;
            }
        }

        private void textBoxMax_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(textBoxMax.Text);
            }
            catch
            {
                textBoxMax.Text = string.Empty;
            }
        }

        private void textBoxTargetNumb_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDouble(textBoxTargetNumb.Text);
            }
            catch
            {
                textBoxTargetNumb.Text = string.Empty;
            }
        }

        public static void WriteDeafaultValue(string fileNameBin, string fileNameTxt, double[,] A1, double _digitMin, double _digitMax, int _indexN, int _indexM)
        {
            
            using (var stream = File.Open(fileNameBin, FileMode.Create))
            {
                using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                {
                    for(int i = 0; i < _indexN; i++)
                    {
                        for (int j = 0; j < _indexM; j++)
                        {
                            Random rnd = new Random();
                            double _digit = rnd.NextDouble() * (_digitMax - _digitMin) + _digitMin;
                            A1[i, j] = _digit;
                            writer.Write(A1[i, j] + "\t");
                        }
                        writer.Write("\n");
                    }
                }
                stream.Close();
            }

            using (var stream = File.Open(fileNameTxt, FileMode.Create))
            {
                using(var writer = new StreamWriter(stream))
                {
                    for (int i = 0; i < _indexN; i++)
                    {
                        for (int j = 0; j < _indexM; j++)
                        {
                            Random rnd = new Random();
                            double _digit = rnd.NextDouble() * (_digitMax - _digitMin) + _digitMin;
                            A1[i, j] = _digit;
                            writer.Write(A1[i, j] + "\t");
                        }
                        writer.Write("\n");
                    }
                    writer.Close();
                }
                stream.Close();
            }
        }

        private void buttonToFile_Click(object sender, EventArgs e)
        {
            double _DigitMin = Convert.ToDouble(textBoxMin.Text);
            double _DigitMax = Convert.ToDouble(textBoxMax.Text);

            Random rnd = new Random();
            int _IndexN = rnd.Next(2, N);
            int _IndexM = rnd.Next(2, N);

            A = new double[_IndexN, _IndexM];

            DateTime dateTime = DateTime.Now;
            string NewDateFormat = dateTime.ToString("yyyy_MM_dd_HH_mm");
            string _fileNameBin = NewDateFormat + ".bin";
            string _fileNameTxt = NewDateFormat + ".txt";

            WriteDeafaultValue(_fileNameBin, _fileNameTxt, A, _DigitMin, _DigitMax, _IndexN, _IndexM);

            
            using (var reader = new StreamReader(_fileNameTxt))
            {
                var lines = File.ReadAllLines(_fileNameTxt);
                var matrix = new List<double[]>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var row = line.Split('\t').Select(double.Parse).ToArray();
                    matrix.Add(row);
                }

                var flattenedMatrix = new double[matrix.Capacity];
                var index = 0;
                foreach (var row in matrix)
                {
                    foreach (var element in row)
                    {
                        flattenedMatrix[index++] = element;
                    }
                }

                var chart = new Chart();
                chart.Size = new System.Drawing.Size(600, 400);
                chart.Titles.Add("Scatter Plot");
                chart.ChartAreas.Add(new ChartArea());

                var series = new Series();
                series.ChartType = SeriesChartType.Point;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 10;
                series.Color = System.Drawing.Color.Blue;

                for (int i = 0; i < flattenedMatrix.Length; i++)
                {
                    series.Points.AddXY(i, flattenedMatrix[i] % _DigitMax);
                }

                chart.Series.Add(series);

                var form = new Form();
                form.Controls.Add(chart);
                form.ShowDialog();

                reader.Close();
            }

            


           
        }

        public static void ReplaceWriter(string filePath, int _index, int flagIndex, double _newDigit)
        {
            var lines = File.ReadAllLines(filePath);
            var fileLines = File.ReadAllLines(filePath);
            var numRows = lines.Length;
            var numCols = lines[0].Split('\t').Length;

            if (flagIndex == 0)
            {
                var row = _index;
                var _newNumb = Convert.ToString(_newDigit);

                for (int i = 1; i <= numCols; i++)
                {

                    var lineToUpdate = fileLines[row - 1];
                    var values = lineToUpdate.Split('\t');
                    values[i - 1] = _newNumb;

                    lineToUpdate = string.Join("\t", values);
                    fileLines[row - 1] = lineToUpdate;
                    File.WriteAllLines(filePath, fileLines);
                }
            }

            else
            {
                var col = _index;
                var _newNumb = Convert.ToString(_newDigit);

                for (int i = 0; i < numRows; i++)
                {
                    var value = fileLines[i].Split('\t');
                    value[col-1]= _newNumb;
                    fileLines[i] = string.Join("\t", value);
                    
                }
                File.WriteAllLines(filePath, fileLines);
            }

            string txtFilePath = Path.GetFileNameWithoutExtension(filePath);
            txtFilePath = txtFilePath + ".txt";

            lines = File.ReadAllLines(txtFilePath);
            fileLines = File.ReadAllLines(txtFilePath);
            numRows = lines.Length;
            numCols = lines[0].Split('\t').Length;

            if (flagIndex == 0)
            {
                var row = _index;
                var _newNumb = Convert.ToString(_newDigit);

                for (int i = 1; i <= numCols; i++)
                {

                    var lineToUpdate = fileLines[row - 1];
                    var values = lineToUpdate.Split('\t');
                    values[i - 1] = _newNumb;

                    lineToUpdate = string.Join("\t", values);
                    fileLines[row - 1] = lineToUpdate;
                    File.WriteAllLines(txtFilePath, fileLines);
                }
            }

            else
            {
                var col = _index;
                var _newNumb = Convert.ToString(_newDigit);

                for (int i = 0; i < numRows; i++)
                {
                    var value = fileLines[i].Split('\t');
                    value[col - 1] = _newNumb;
                    fileLines[i] = string.Join("\t", value);
                    
                }
                File.WriteAllLines(txtFilePath, fileLines);
            }
        }
        private void buttonReplace_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                int _index = Convert.ToInt32(textBoxRowIndex.Text);
                int flag;
                double _NewDigit = Convert.ToDouble(textBoxTargetNumb.Text);

                if (comboBoxRow.SelectedIndex == 0)
                    flag = 0;
                else
                    flag = 1;

                ReplaceWriter(filePath, _index, flag, _NewDigit);


            }
        }
    }
}
