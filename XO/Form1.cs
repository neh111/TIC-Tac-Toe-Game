using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class Form1 : Form
    {
        static bool x = false;
        static int numericValue = 3;
        static Button[,] matBoard =new Button[numericValue,numericValue];
        public Form1()
        {
            InitializeComponent();
            ReStart();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            numericValue = (int)numericUpDown1.Value;
            matBoard= new Button[numericValue, numericValue];
            for (int i = 0; i < numericValue*numericValue; i++)
            {
                    Button b = new Button();
                    b.Text = "?";
                    b.Location = new Point(861-i% numericValue*60, 48+ i / numericValue*60);
                    b.Size = new Size(60, 60);
                    matBoard[i / numericValue, i % numericValue] = b;
                    panel1.Controls.Add(b);
                    b.Click += ClickButtonXO;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chosen = comboBox1.Text;
            if (chosen == "X")
                x = true;
            else
                x = false;
        }
        private void ClickButtonXO(object sender, EventArgs e)
        {
            if (x)
            {
                ((Button)sender).Text="X";
                x = false;
            }
            else
            {
                ((Button)sender).Text="O";
                x = true;
            }
            string str = ((Button)sender).Text;
            if (IsWin(str))
            {
                MessageBox.Show(str+" is the winner!!");
            }
            ((Button)sender).Enabled = false;
        }

        private bool IsWin(string now)
        {
            return IsWinLines(now) || IsWinCoulmns(now) || IsWinDiagonals(now);
        }
        private bool IsWinLines(string now)
        {
            bool flag = false;
            for (int i = 0; i < numericValue && (!flag); i++)
            {
                for (int j = 0; j < numericValue; j++)
                {
                    if (matBoard[i, j].Text != now)
                        break;
                    if (j == numericValue-1)
                        flag = true;
                }
            }
            return flag;
        }
        private bool IsWinCoulmns(string now)
        {
            bool flag = false;
            for (int i = 0; i < numericValue && (!flag); i++)
            {
                for (int j = 0; j < numericValue; j++)
                {
                    if (matBoard[j,i].Text != now)
                        break;
                    if (j == numericValue-1)
                        flag = true;
                }
            }
            return flag;
        }
        private bool IsWinDiagonals(string now)
        {
            bool flag = false;
            for (int i = 0; i < numericValue && (!flag); i++)
            {
                if (matBoard[i, i].Text != now)
                    break;
                else
                {
                    if (i == numericValue - 1)
                        return true;
                }
            }
            int j = numericValue - 1;
            for (int i = 0; i < numericValue; i++)
             {
                if (matBoard[i, j].Text != now)
                    return false;
                j--;
             }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ReStart();
        }

        private void ReStart()
        {
            numericValue = 3;
            numericUpDown1.Value=numericValue;
            for (int i = 0; i < numericValue * numericValue; i++)
            {
                Button b = new Button();
                b.Text = "?";
                b.Location = new Point(861 - i % numericValue * 60, 48 + i / numericValue * 60);
                b.Size = new Size(60, 60);
                matBoard[i / numericValue, i % numericValue] = b;
                panel1.Controls.Add(b);
                b.Click += ClickButtonXO;
            }
        }
    }
}
