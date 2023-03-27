using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5_tp
{
    internal class DataBase
    {
        public double[,,] id;
        
        public void EventFill(object sender, EventArgs e, int i, int d, int c)
        {
            try
            {
                id[i, d, c] = Convert.ToDouble(((TextBox)sender).Text);
                Console.WriteLine($"id[{i},{d},{c}]= {id[i, d, c]}");
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
            }
            
        }
        public DataBase(TextBox[,] textBoxX, TextBox[,] textBoxY) 
        { 
            id = new double[4, 3, 2];

            for(int i=0; i<textBoxX.GetLength(0); i++)
            {
                int temp = Convert.ToInt32(i);
                for(int j=0; j<textBoxX.GetLength(1); j++)
                {
                    int temp2 = Convert.ToInt32(j);
                    textBoxX[i, j].TextChanged += (s, e) => EventFill(s, e, temp, temp2, 0);
                }
                
            }
            for (int i = 0; i < textBoxX.GetLength(0); i++)
            {
                int temp = Convert.ToInt32(i);
                for (int j = 0; j < textBoxX.GetLength(1); j++)
                {
                    int temp2 = Convert.ToInt32(j);
                    textBoxY[i, j].TextChanged += (s, e) => EventFill(s, e, temp, temp2, 1);
                }

            }
        }
    }
}
