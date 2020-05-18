using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Betcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int q;
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            q = dataGridView1.RowCount - 1;

            int[] mass = new int[q];

            for (int i = 0; i <q ; i++)

                mass[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            B(mass, 0, q - 1);

            for (int i = 0; i < q; i++)

                dataGridView1.Rows[i].Cells[0].Value = mass[i];
        }
        void B(int[] mass, int LOW, int MAX)
        {

            if (MAX == LOW)
                return;
            if (MAX - LOW == 1)
            {

                if (mass[MAX] < mass[LOW])
                {
                    int you;

                    you = mass[MAX];

                    mass[MAX] = mass[LOW];

                    mass[LOW] = you;
                }
                return;
            }
            int p = (MAX + LOW) / 2;


            B(mass, LOW, p);

            B(mass, p + 1, MAX);


            int[] A = new int[q];

            int xlow = LOW;
            int xmax = p + 1;
            int mid = 0;
            while (MAX - LOW + 1 != mid)
            {
                if (xlow > p)

                    A[mid++] = mass[xmax++];
                else

                if (xmax > MAX) A[mid++] = mass[xlow++];
                else

                if (mass[xlow] > mass[xmax]) A[mid++] = mass[xmax++];

                else A[mid++] = mass[xlow++];

            }
            for (int i = 0; i < mid; i++)

                mass[i + LOW] = A[i];
        }

    }
}
