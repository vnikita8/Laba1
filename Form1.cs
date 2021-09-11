using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void RandomOrk()
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rnd.Next(1, 10);
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int w, c, wc;

            dataGridView1.AllowUserToAddRows = false;
            for (int i = 0; i<5; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Rows.Add();
                dataGridView1.Columns[i].Width = 40;
                dataGridView1.Rows[i].Height = 40;
            }
            c = dataGridView1.Columns.Count;
            w = dataGridView1.Columns[0].Width;
            wc = c * w +3;
            dataGridView1.Width = wc;
            c = dataGridView1.Rows.Count;
            w = dataGridView1.Rows[0].Height;
            wc = c * w +3;
            dataGridView1.Height = wc;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int check = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if ((dataGridView1.Rows[i].Cells[j].Value != null) & (dataGridView1.Rows[j].Cells[i].Value != null))
                        {
                        try
                        {
                            int n = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                            int m = int.Parse(dataGridView1.Rows[j].Cells[i].Value.ToString());
                            if (dataGridView1.Rows[i].Cells[j].Value.ToString() != dataGridView1.Rows[j].Cells[i].Value.ToString())
                            {
                                check = 1;
                                break;
                            }
                        }
                        catch
                        {
                            check = 2;
                            break;
                        }
                        }
                    else
                    {
                        check = 4;
                        break;
                    }
                }
                if (check != 0)
                {
                    break;
                }
            }
            if (check == 0)
            {
                MessageBox.Show("Симметрична", "Успешно");
            }
            else if (check == 2)
            {
                MessageBox.Show("Введите целочисленные значения", "Ошибка");
            }
            else if (check == 1)
            {
                MessageBox.Show("Не симметрична", "Успешно");
            }
            else
            {
                MessageBox.Show("Заполните матрицу", "Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RandomOrk();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 1;
                }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            Exception2 two = new Exception2();
            two.Swit = comboBox1.Text + comboBox2.Text;
            two.TextBox_1 = textBox1.Text;
            textBox2.Text = two.GoDo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }


    public class PreException2
    {
        public string Swit { get; set; }
        public string TextBox_1 { get; set; }

    }
    public class Exception2 : PreException2
    {
        public string GoDo()
        {
            switch (Swit)
            {
                case "22":
                    bool bul1 = false;
                    for (int i = TextBox_1.Length - 1; i >= 0; i--)
                        if ((int.Parse(TextBox_1[i].ToString()) < 0) | (int.Parse(TextBox_1[i].ToString()) > 1))
                        {
                            bul1 = true;
                        }
                    if (bul1 == false)
                    {
                        return TextBox_1;
                    }
                    else
                    {
                        MessageBox.Show("Некорректное число", "Ошибка");
                        return null;
                    }
                case "1010":
                    return TextBox_1;
                case "210":
                    //из 2 в 10
                    if (TextBox_1 == null)
                    {
                        MessageBox.Show("Введите целочисленное значение", "Ошибка");
                        return null;
                    }
                    else
                    {
                        try
                        {
                            string res = Convert.ToInt32(TextBox_1, 2).ToString();
                            return res;
                        }
                        catch
                        {
                            MessageBox.Show("Введите целочисленное значение", "Ошибка");
                            return null;
                        }
                    }
                case "102":
                    string bin = Convert.ToString(int.Parse(TextBox_1), 2);
                    return bin;
                default:
                    {
                        MessageBox.Show("Вы не выбрали систему счисления", "Ошибка");
                        return null;
                    }
            }
        }
    }


}
