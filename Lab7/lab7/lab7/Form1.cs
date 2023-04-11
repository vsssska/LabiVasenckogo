using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = (char)e.KeyChar;
            if(((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44))
                e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("<"); //0 index
            comboBox1.Items.Add(">"); //1 index
            comboBox1.Items.Add("="); //2 index
            comboBox1.Items.Add("<="); //3 index
            comboBox1.Items.Add(">="); //4 index
            comboBox1.Items.Add("<>"); //5 index
        }

        private void buttonPerf_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                double f_oper = 0;
                double s_oper = 0;
                try
                {
                    f_oper = Convert.ToDouble(textBox1.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    textBox1.Text = ex.Message;
                    textBox1.Focus();
                    textBox1.Select(0, (ex.Message.ToString()).Length);
                }

                if (listBoxSecOp.SelectedItems.Count != -1)
                {
                    try
                    {
                        s_oper = Convert.ToDouble(listBoxSecOp.SelectedItem);
                        try
                        {
                            if (comboBox1.SelectedIndex == 0)
                                listBoxRes.Items.Add($"{f_oper} < {s_oper} = {f_oper < s_oper}");
                            if (comboBox1.SelectedIndex == 1)
                                listBoxRes.Items.Add($"{f_oper} > {s_oper} = {f_oper > s_oper}");
                            if (comboBox1.SelectedIndex == 2)
                                listBoxRes.Items.Add($"{f_oper} = {s_oper} = {f_oper == s_oper}");
                            if (comboBox1.SelectedIndex == 3)
                                listBoxRes.Items.Add($"{f_oper} <= {s_oper} = {f_oper <= s_oper}");
                            if (comboBox1.SelectedIndex == 4)
                                listBoxRes.Items.Add($"{f_oper} >= {s_oper} = {f_oper >= s_oper}");
                            if (comboBox1.SelectedIndex == 5)
                                listBoxRes.Items.Add($"{f_oper} <> {s_oper} = {f_oper != s_oper}");
                            if (comboBox1.SelectedIndex == -1)
                                MessageBox.Show("Нужно выбрать знак в comboBox!");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    catch
                    {

                    }
                }
                else
                    MessageBox.Show("Нужно выбрать эл-т в ЛистБоксе!");

            }
            else
            {
                MessageBox.Show("Введите значение в ТекстБокс");
                textBox1.Focus();
            }
                



        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            listBoxRes.Items.Clear();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            if(listBoxRes.SelectedIndex != -1)
            {
                string[] _temps = listBoxRes.SelectedItem.ToString().Split(' ');
                textBox1.Text = _temps[0];
                if (_temps[1] == "<")
                    comboBox1.SelectedIndex = 0;
                else if (_temps[1] == ">")
                    comboBox1.SelectedIndex = 1;
                else if (_temps[1] == "=")
                    comboBox1.SelectedIndex = 2;
                else if (_temps[1] == "<=")
                    comboBox1.SelectedIndex = 3;
                else if (_temps[1] == ">=")
                    comboBox1.SelectedIndex = 4;
                else if (_temps[1] == "<>")
                    comboBox1.SelectedIndex = 5;

                bool flag = false;
                for (int i = 0; i < listBoxSecOp.Items.Count; i++)
                {
                    if (Convert.ToDouble(_temps[2]) == Convert.ToDouble(listBoxSecOp.Items[i]))
                    {
                        listBoxSecOp.SelectedIndex = i;
                        flag = true;
                        break;
                    }
                }
                if(!flag)
                    listBoxSecOp.Items.Add(_temps[2]);
            }
            

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            comboBox1.SelectedIndex = (-1);
            listBoxSecOp.Items.Clear();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                try
                {
                    double temp = Convert.ToDouble(textBox1.Text);
                    bool flag = false;
                    for(int i = 0;i < listBoxSecOp.Items.Count;i++)
                    {
                        if (Convert.ToDouble(listBoxSecOp.Items[i]) == temp)
                        {
                            MessageBox.Show("Такой эл-нт уже существует");
                            flag = true;
                        }
                    }
                    if(!flag)
                        listBoxSecOp.Items.Add(textBox1.Text);
                }
                catch(Exception ex)
                {
                    textBox1.Text = ex.Message;
                    textBox1.Focus();
                    textBox1.Select(0, (ex.Message.ToString()).Length);
                }
            }
        }

        private void buttonDell_Click(object sender, EventArgs e)
        {
            if(listBoxSecOp.SelectedIndex != -1)
                listBoxSecOp.Items.Remove(listBoxSecOp.SelectedItem);
        }
    }
}
