using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        string myPpath = @"D:\myProgramm.log";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void myprogram(int Gcount)
        {
            
            File.Delete(myPpath);

            FileStream file = new FileStream(myPpath, FileMode.Create);
            file.Seek(0, SeekOrigin.End);
            StreamWriter streamWriter= new StreamWriter(file);

            streamWriter.WriteLine($"Название программы: {System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName.Split('\\').Last()}" + Environment.NewLine +
                "Номер варианта: 50" + Environment.NewLine +
                $"{DateTime.Now}" + Environment.NewLine +
                "Рассчитываемая ф-ция: cos(x/y)^-2" + Environment.NewLine +
                "Результаты расчетов содержатся в:  ");
            for (int j = 0; j < Gcount; j++)
                streamWriter.WriteLine($"G{j}.dat");
            streamWriter.Close();
            file.Close();

        }


        private void datReader(int ic)
        {
            string[] path;
            path = File.ReadAllLines(myPpath);

            //g = new double[,,path.Length-5];
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
                    
                    for(int k=1; k<temp.Length; k++)
                    {
                        tempArr[j-5, k-1] = Convert.ToDouble(temp[k]);
                    }
                }

            }

        }
        private void gWriter(int gID, int xi, int yi, double[,] val)
        {
            string path = @"D:\g"+gID.ToString()+".txt";
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

                
                for(int j=0; j<endY; j++)
                {
                    for(int k=0; k<endX; k++)
                    {
                        value[j, k] = calc(x0, y0);
                        x0 += xh;
                    }
                    y0+= yh;
                }

                gWriter(i, endX, endY, value);
                
            }
            myprogram(data.GetLength(0));
            datReader(data.GetLength(0));
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
        }
    }
}
