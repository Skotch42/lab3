using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_Lab_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView.ClearSelection();
        }

        const int A = 20;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int rule = (int)edRule.Value;
            int[] rule_in_2 = new int[8];
            int[,] table = new int[A, A];

            string s = Convert.ToString(rule, 2);
            int n = Convert.ToInt32(s);

            for (int j = 7; j >= 0; j--)
            {
                rule_in_2[j] = n % 10;
                n = n / 10;
            }

            table[0, 0] = 0; table[0, 1] = 0; table[0, 2] = 0; table[0, 3] = 0; 
            table[0, 4] = 0; table[0, 5] = 0; table[0, 6] = 0; table[0, 7] = 0; 
            table[0, 8] = 0; table[0, 9] = 1; table[0, 10] = 0; table[0, 11] = 0; 
            table[0, 12] = 0; table[0, 13] = 0; table[0, 14] = 0; table[0, 15] = 0; 
            table[0, 16] = 0; table[0, 17] = 0; table[0, 18] = 0; table[0, 19] = 0;

            for (int i = 0; i < A - 1; i++) 
            {
                int a = table[i, A - 1] * 100 + table[i, 0] * 10 + table[i, 1];
                string s1 = Convert.ToString(a);
                int b = Convert.ToInt32(s1, 2);

                for (int k = 0; k < 8; k++) 
                {
                    if (k == b)
                    {
                        table[i + 1, 0] = rule_in_2[k];
                    }
                }

                for (int j = 1; j < A - 1; j++)
                {
                    a = table[i, j - 1] * 100 + table[i, j] * 10 + table[i, j + 1];
                    s1 = Convert.ToString(a);
                    b = Convert.ToInt32(s1, 2);

                    for (int k = 0; k < 8; k++) 
                    {
                        if (k == b)
                        {
                            table[i + 1, j] = rule_in_2[k];
                        }
                    }
                }

                a = table[i, A - 2] * 100 + table[i, A - 1] * 10 + table[i, 0];
                s1 = Convert.ToString(a);
                b = Convert.ToInt32(s1, 2);

                for (int l = 0; l < 8; l++) 
                {
                    if (l == b)
                    {
                        table[i + 1, A - 1] = rule_in_2[l];
                    }
                }
            }

            dataGridView.ColumnCount = A; 
            dataGridView.RowCount = A;
            for (int i = 0; i < A; i++)
            {
                for (int j = 0; j < A; j++)
                {
                    if (table[i, j] == 1)
                    {
                        dataGridView.Rows[i].Cells[j].Style.BackColor = Color.Blue;
                    }
                }
            }
        }

        private void edRule_ValueChanged(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}
