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

        public void RandomOrk() //Заполняет рандомными числами
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
            //Создание таблицы
            for (int i = 0; i<5; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                dataGridView1.Rows.Add();
                dataGridView1.Columns[i].Width = 40;
                dataGridView1.Rows[i].Height = 40;
            }
            //Тут задаётся размер 
            c = dataGridView1.Columns.Count;
            w = dataGridView1.Columns[0].Width;
            wc = c * w +3;
            dataGridView1.Width = wc;
            c = dataGridView1.Rows.Count;
            w = dataGridView1.Rows[0].Height;
            wc = c * w +3;
            dataGridView1.Height = wc;
            //Параметры для комбобоксов
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e) //Проверка симметрии и заполненности таблицы
        {
            //да, тут немного тупо сделано, но как сделать умнее дошло уже потом, а код уже написан и работает
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

        private void button2_Click(object sender, EventArgs e) //рандом значения
        {
            RandomOrk();
        }

        private void button3_Click(object sender, EventArgs e) //Заполнение единицами ( = 100% симметрии)
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = 1;
                }
        }

        private void button4_Click(object sender, EventArgs e) // второе задание
        {

            string swit = comboBox1.Text + comboBox2.Text; //значения комбобоксов
            string res;

            switch (swit) //проверка на значения комбобоксов и возвращение результата
            {
                case "210":
                    ToDec todec = new ToDec();
                    todec.TextBox_1 = textBox1.Text;
                    res = todec.Todec();
                    if (res != null)
                    {
                        textBox2.Text = res;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Введите целочисленное значение", "Ошибка");
                        break;
                    }
                case "102":
                    ToTw totwice = new ToTw();
                    totwice.TextBox_1 = textBox1.Text;
                    res = totwice.Totw();
                    if (res != null)
                    {
                        textBox2.Text = res;
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Введите целочисленное значение", "Ошибка");
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Пожалуйста, выберите две разные системы счисления.", "Ошибка");
                        break;
                    }
            }
        }

        private void button5_Click(object sender, EventArgs e) //закрыть
        {
            Close();
        }
    }


    public class PreException2 //родительский класс
    {
        public string TextBox_1 { get; set; }

    }

    public class ToTw : PreException2 //Дочерний в Двоичную
    {
        public string Totw()
        {
            if (TextBox_1 == null)
            {
                return null;
            }

            else
            {
                try
                {
                    string res = Convert.ToString(int.Parse(TextBox_1), 2);
                    return res;
                }
                catch
                {
                    return null;
                }
            }
        }
    }

    public class ToDec : PreException2 //Дочерний в Десятичную
    {
        public string Todec()
        {
            if (TextBox_1 == null)
            {
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
                    return null;
                }
            }
        }
    }
}
