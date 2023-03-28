using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        string data_path;
        string[] strings;
        double[,] variable;
        double[,] value;
        double[,,] g;
        //string myPpath = @"D:\myProgramm.log";
        string myPpath = AppDomain.CurrentDomain.BaseDirectory + "res";

        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size = new Size(200, 500);
            listBox1.Visible= false;
            if (!Directory.Exists(myPpath))
                Directory.CreateDirectory(myPpath);
            button2.Visible= false;
        }

        private void errorFunc(string erx, int id, double x, double y)
        {
            MessageBox.Show(erx);
            string newPrlog = myPpath + "\\myError" + DateTime.Now.ToString("dd_MM_yy HH_mm_ss") + ".log";

            FileStream file = new FileStream(newPrlog, FileMode.Create);
            file.Seek(0, SeekOrigin.End);
            StreamWriter streamWriter = new StreamWriter(file);

            streamWriter.WriteLine($"Имя файлы данных: G{id}.log" + Environment.NewLine +
                "Рассчитываемая ф-ция: cos(x/y)^(1/2)" + Environment.NewLine +
                $"Аргументы: x= {x} y={y}");

            streamWriter.Close();
            file.Close();
        }

        private string myprogram(int Gcount)
        {

            string newPrlog = myPpath + "\\myPr" + DateTime.Now.ToString("dd_MM_yy HH_mm_ss") + ".log";

            FileStream file = new FileStream(newPrlog, FileMode.Create);
            file.Seek(0, SeekOrigin.End);
            StreamWriter streamWriter= new StreamWriter(file);

            streamWriter.WriteLine($"Название программы: {System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Split('\\').Last()}" + Environment.NewLine +
                "Номер варианта: 50" + Environment.NewLine +
                $"{DateTime.Now}" + Environment.NewLine +
                "Рассчитываемая ф-ция: cos(x/y)^(1/2)" + Environment.NewLine +
                "Результаты расчетов содержатся в:  ");
            for (int j = 0; j < Gcount; j++)
                streamWriter.WriteLine($"G{j}.dat");
            
            streamWriter.Close();
            file.Close();
            return newPrlog;
        }

        private void datReader(int ic, string newPrlog)
        {
            string[] path;
            path = File.ReadAllLines(newPrlog);

            double[,] tempArr;
            for(int i=5; i < path.Length; i++)
            {
                string gPath = @"D:\" + path[i];
                string[] gStrings = File.ReadAllLines(gPath);

                string[] tempH = gStrings[5].Split('\t');
                tempArr = new double[gStrings.Length - 5, tempH.Length-1];
                for (int j=5; j<gStrings.Length; j++)
                {
                    string[] temp = gStrings[j].Split('\t');
                    
                    for(int k=1; k<temp.Length-1; k++)
                    {
                        tempArr[j-5, k-1] = Convert.ToDouble(temp[k]);
                    }
                }

            }

            for(int i=5; i<path.Length; i++)
            {
                listBox1.Items.Add(path[i]);
            }
            listBox1.Visible= true;
        }
        private void gWriter(int gID, int xi, int yi, double[,] val)
        {
            string path = myPpath + $"\\G{gID}.dat";
            if(File.Exists(path))
                File.Delete(path);

            FileStream streamwriter = new FileStream(path, FileMode.Create);
            streamwriter.Seek(0, SeekOrigin.End);
            StreamWriter file = new StreamWriter(streamwriter);
            file.Write(val);

            file.WriteLine("Рассчитываемая ф-ция: cos(x/y)^-2" + Environment.NewLine +
                $"Кол-во X: {xi}" + Environment.NewLine +
                $"Кол-во Y: {yi}" + Environment.NewLine);
            file.Write("xy\t");
            for (int i=0; i<xi; i++)
            {
                file.Write($"x{i}\t");
            }

            file.Write("\n");
            for (int i=0; i<yi; i++)
            {
                file.Write($"y{i}\t");
                for(int j=0; j<xi; j++)
                {
                    if (val[i, j] == Double.NaN)
                        file.Write("null\t");
                    file.Write($"{val[i, j]:f4}\t");
                }
                file.Write("\n");
            }
            file.Close();
            streamwriter.Close();
            
        }



        Func<double, double, double> calc = (x, y) => Math.Sqrt(Math.Cos(x / y));
        public void func(double[,] data)
        {
            for (int i=0; i<data.GetLength(0); i++)
            {
                
                double x0 = data[i, 0];
                double xN = data[i, 1];
                double xh = data[i, 2];

                double y0 = data[i, 3];
                double ye = data[i, 4];
                double yh = data[i, 5];

                int endY = Convert.ToInt32(Math.Abs(ye - y0) / yh);
                int endX = Convert.ToInt32(x0 + xN * xh);
                value = new double[endY, endX];

                try
                {
                    for (int j = 0; j < endY; j++)
                    {
                        for (int k = 0; k < endX; k++)
                        {
                            value[j, k] = calc(x0, y0);
                            x0 += xh;
                        }
                        y0 += yh;
                    }
                }
                catch(Exception ex)
                {
                    errorFunc(ex.ToString(), i, x0, y0);
                }

                gWriter(i, endX, endY, value);
                
            }
            string nTemp = myprogram(data.GetLength(0));
            datReader(data.GetLength(0), nTemp);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd= new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                data_path= ofd.FileName;
            }
            strings = File.ReadAllLines(data_path);

            variable = new double[strings.Length, 6];
            for(int i = 0; i < strings.Length; i++)
            {
                string[] tempvar = strings[i].Split(' ');
                for(int j=0; j<variable.GetLength(1); j++) 
                {
                    variable[i, j] = Convert.ToDouble(tempvar[j]);
                }
            }

            func(variable);
            Size = new Size(400, 500);
        }

        double[,] tempArr;
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gPath = myPpath + "\\" + listBox1.SelectedItem.ToString();
            string[] gStrings = File.ReadAllLines(gPath);

            
            string[] tempH = gStrings[5].Split('\t');
            tempArr = new double[gStrings.Length - 5, tempH.Length - 1];
            for (int j = 5; j < gStrings.Length; j++)
            {
                string[] temp = gStrings[j].Split('\t');

                for (int k = 1; k < temp.Length - 1; k++)
                {
                    tempArr[j - 5, k - 1] = Convert.ToDouble(temp[k]);
                }
            }

            dataGridView1.RowCount= tempArr.GetLength(0);
            dataGridView1.ColumnCount= tempArr.GetLength(1)-1;
            for(int i=0; i < dataGridView1.RowCount; i++)
            {
                for(int j=0; j< dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = tempArr[i, j];
                }
            }
            Size = new Size(800, 500);
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = tempArr.GetLength(0);
            dataGridView1.ColumnCount = tempArr.GetLength(1) - 1;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = tempArr[i, j]/2;
                }
            }
        }
    }
}
