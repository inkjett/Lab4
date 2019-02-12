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

        //ArrayList Arr_Main;

        
        public void Arr_random_gen(Int32 a, Int32 b, ref Int32 [,] arr_out) // метод заполнения массивва рандомными числами
        {
            Random rnd = new Random();
            for (int i = 0; i < arr_out.GetLength(0); i++)
                for (int j = 0; j < arr_out.GetLength(1); j++)
                    arr_out[i,j] = rnd.Next(a, b);
        }
        public void Arr_to_Form(int[,] arr_in, ref DataGridView out_Data_Grid)
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



        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

                          

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {            
            Arr_Main = new Int32[Int32.Parse(textBox1.Text), Int32.Parse(textBox5.Text)];
            Arr_random_gen(Int32.Parse(textBox2.Text), Int32.Parse(textBox3.Text),ref Arr_Main );

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arr_to_Form(Arr_Main,ref dataGridView1);
        }
    }
}
