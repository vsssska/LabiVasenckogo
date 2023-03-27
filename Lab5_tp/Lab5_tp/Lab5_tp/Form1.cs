using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Lab5_tp
{
    public partial class Form1 : Form
    {
        DataBase _data;
        public Form1()
        {
            InitializeComponent();
            TextBox[,] textBoxesX;
            textBoxesX = new TextBox[4, 3]
            {
                {
                    textBoxX01,
                    textBoxXn1,
                    textBoxXh1,
                    
                },
                {
                    textBoxX02,
                    textBoxXn2,
                    textBoxXh2,
                }, 
                { 
                    textBoxX03,
                    textBoxXn3,
                    textBoxXh3,

                },
                {
                    textBoxX04,
                    textBoxXn4,
                    textBoxXh4,
                }

            };
            TextBox[,] textBoxesY;
            textBoxesY = new TextBox[4, 3]
            {
                {
                    textBoxY01,
                    textBoxYk1,
                    textBoxYh1,
                },
                {
                    textBoxY02,
                    textBoxYk2,
                    textBoxYh2,
                    
                },
                {
                    textBoxY03,
                    textBoxYk3,
                    textBoxYh3,
                },
                {
                    textBoxY04,
                    textBoxYk4,
                    textBoxYh4,
                }
            };
            _data = new DataBase(textBoxesX, textBoxesY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxYh4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != ',')
                e.Handled = true;
        }


        public double func(double x, double y)
        {
            return Math.Sqrt(Math.Cos(x/y));
        }
        public void calc(int i)
        {
            int xi = Convert.ToInt32(_data.id[i, 1, 0] * _data.id[i, 2, 0]);
            int yi = Convert.ToInt32(Math.Abs(_data.id[i, 1, 1] - _data.id[i, 0, 1]) / _data.id[i, 2, 1]);
            double[,] res = new double[xi, yi];


            double h = _data.id[i, 2, 0];
            double ix = _data.id[i, 0, 0];
            double iy = _data.id[i, 0, 1];
            for (int j = 0; j < yi; j++)
            {
                ix = _data.id[i, 0, 0];
                for (int k = 0; k < xi; k++)
                {
                    res[k, j] = func(ix, iy);
                    ix += h;
                }

                iy += _data.id[i, 2, 1];
            }
        }
        private void butCalc_Click(object sender, EventArgs e)
        {
            for(int i=0; i<_data.id.GetLength(0); i++)
            {
                Thread thread = new Thread(()=>calc(i));
                thread.Start();
            }
        }
    }
}
