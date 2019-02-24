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

        Int32[,] Arr_Main;
        Int32[,] Arr_Main_change_line;
        Int32[,] Arr_Main_min_value;
        Int32 Size1, Size2;


        public void Arr_random_gen(Int32 a, Int32 b, ref Int32 [,] arr_out) // метод заполнения массивва рандомными числами
        {
            Random rnd = new Random();
            for (int i = 0; i < arr_out.GetLength(0); i++)
                for (int j = 0; j < arr_out.GetLength(1); j++)
                    arr_out[i,j] = rnd.Next(a, b);
        }
        
        public void Arr_to_Form(int[,] arr_in, ref DataGridView out_Data_Grid)//метод вывода масива в таблицу
        {
            out_Data_Grid.RowCount = arr_in.GetLength(0); //Количество строк в таблицу
            out_Data_Grid.ColumnCount = arr_in.GetLength(1); // Количество стобцов
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

        public void arr_change_line(int[,] arr_in, ref int [,] arr_out) // метод замена строк средней и крайней
        {

            
            Int32 temp_arr_number;
            //Int32[] temp_arr;  
            Int32 Middel_line = 0;
            arr_out = new int[arr_in.GetLength(0), arr_in.GetLength(1)];
            if (arr_in.GetLength(0) % 2 != 0)//опрделение строки четные или нет
            {
                Middel_line = (arr_in.GetLength(0) / 2);         //определение средней строки       
                for (int i = 0; i < arr_in.GetLength(0); i++)
                {
                    temp_arr_number = arr_in[0, i];
                    arr_in[0, i] = arr_in[Middel_line, i];
                    arr_in[Middel_line, i]=temp_arr_number;
                }

            }
            for(int i=0;i<arr_in.GetLength(0);i++)
            {
                for (int j=0;j<arr_in.GetLength(1);j++)
                {
                    arr_out[i, j] = arr_in[i, j];
                }
            }
            
        }

        public void add_colum_min_value(int[,] arr_in, ref int [,] arr_out) // метод добавления столбца после минимального занчения
        {
            Int32 min_value = arr_in[0, 0];
            Int32 count = 0;
           
            for (int i=0; i<arr_in.GetLength(0); i++ ) // определение минимального значения масиива
            {
                for (int j=0; j<arr_in.GetLength(1);j++)
                {
                    
                    if (arr_in[i, j] < min_value  )
                    {
                        min_value = arr_in[i, j];                        
                    }
                }

            
            }
            for (int i = 0; i < arr_in.GetLength(0); i++) // определение количества добавляемых столбцов
            {
                for (int j = 0; j < arr_in.GetLength(1); j++)
                {
                    if (min_value == arr_in[i, j])
                    {
                        count++;
                    }
                }
            }

            arr_out = new int[arr_in.GetLength(0), arr_in.GetLength(1) + count]; // добавление столбца GetLength(1) - столбцы, GetLength(0) - стороки 
            // i - столбец  j - строка
            //Int32 count_for_colum = 0;
            int jj;
            Int32 temp_count;
             
            for (jj = 0; jj < arr_in.GetLength(1); jj++) // выбираем столбец
            {                
                for (int i = 0; i < arr_in.GetLength(0); i++) // копируем строки в массиве 
                {
                    arr_out[i, jj] = arr_in[i, jj];
                }
                temp_count = 0;
                for (int temp_i=0; temp_i<arr_out.GetLength(0);temp_i++)
                {                    
                    if ((arr_in[temp_i, jj] == min_value)&&(temp_count==0))
                    {                        
                        for (int temp_ii = 0; temp_ii < arr_in.GetLength(1); temp_ii++)
                        {                            
                            arr_out[temp_ii, jj+1] = arr_in[temp_ii, 1];                                         
                        }                                  
                        temp_count++;                     
                    }
                    if (jj == 0 && temp_count>0)
                    {
                        for (int temp_ii = 0; temp_ii < arr_in.GetLength(1); temp_ii++)
                        {
                            arr_out[temp_ii, jj + 2] = arr_in[temp_ii, 1];
                        }
                        jj++;
                    }
                }
                if (temp_count>=1)
                {
                   jj++;
                }
            }

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

        private void button4_Click(object sender, EventArgs e) //вывод таблицы с поменеными строками 
        {

            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;
            arr_change_line(Arr_Main, ref Arr_Main_change_line);
            Arr_to_Form(Arr_Main_change_line, ref dataGridView2);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            add_colum_min_value(Arr_Main, ref Arr_Main_min_value);
            Arr_to_Form(Arr_Main_min_value, ref dataGridView2);
        }

        private void button1_Click_1(object sender, EventArgs e) // расчет саммы элементов матрицы
        {
            sum_diag(Arr_Main, ref textBox4);
        }
    }
}
