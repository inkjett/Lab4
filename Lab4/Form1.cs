using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab4
{
    public partial class Form1 : Form
    {

        //List<int> Arr_Main = new List<int>();
        //Arr_Main = new List<int>();
        Int32[,] Arr_Main;
        Int32 Size1, Size2;
        //ArrayList Arr_Main;


        public void Arr_random_gen(Int32 a, Int32 b, ref Int32 [,] arr_out) // метод заполнения массивва рандомными числами
        {
            Random rnd = new Random();
            for (int i = 0; i < arr_out.GetLength(0); i++)
                for (int j = 0; j < arr_out.GetLength(1); j++)
                    arr_out[i,j] = rnd.Next(a, b);
        }
        public void Arr_to_Form(int[,] arr_in, ref DataGridView out_Data_Grid)//метод вывода масива в таблицу
        {
            out_Data_Grid.RowCount = arr_in.GetLength(0);
            out_Data_Grid.ColumnCount = arr_in.GetLength(1);
            for (int i = 0; i < arr_in.GetLength(0); i++)
            {
                for (int j = 0; j < arr_in.GetLength(1); j++)
                {
                    out_Data_Grid.Rows[i].Cells[j].Value = String.Format("{0}", arr_in[i, j]);
                }
            }   
        }


        public void sum_diag(int [,] arr_in, ref TextBox summ_out) // посчитать сумму элементво выше диагонали, матриаца должна быть квадратной
        {
            Int32 summ = 0;
            Int32 k = 1;

            for (int i = 0; i < Size1 - 1; i++)
            {
                for (int j = 0; j < Size2 - k; j++)
                {
                summ += arr_in[i, j];
                }
                k++;
            }
            summ_out.Text = Convert.ToString(summ);
            
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
        }

                          

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //генерация таблицы
        {
            Size1 = Int32.Parse(textBox1.Text);
            Size2 = Int32.Parse(textBox5.Text);
            Arr_Main = new Int32[Int32.Parse(textBox1.Text), Int32.Parse(textBox5.Text)];
            Arr_random_gen(Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text),ref Arr_Main );

        }

        private void button3_Click(object sender, EventArgs e) // вывод данных в таблицу
        {
            Arr_to_Form(Arr_Main,ref dataGridView1);
        }

        private void button1_Click_1(object sender, EventArgs e) // расчет саммы элементов матрицы
        {
            sum_diag(Arr_Main, ref textBox4);
        }
    }
}
