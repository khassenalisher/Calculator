using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorNew
{
    public partial class v : Form
    {
        string saver;
        double specValue;
        double firstValue = 0;
        double secondValue = 0;
        double specMemory = 0;
        string operation1 = "";
        bool operation_pressed = false;
        bool count;
        int k = 0;
        bool memory = false;
      
        bool chek = false;

        public v()
        {
            InitializeComponent();
        }

        private void digit_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if ((display.Text == "0") || (operation_pressed))
            {
                k = 0;
                display.Clear();
            }

            if (b.Text == ",")
            {
                if (!display.Text.Contains(","))
                {
                    if (k == 0) display.Text = "0" + b.Text;
                    else
                        display.Text += b.Text;
                }

            }
            else display.Text = display.Text + b.Text;
            specValue = double.Parse(display.Text);
            operation_pressed = false;

            k++;
 
        }

        private void CE_Click(object sender, EventArgs e)
        {
            display.Text = "0";

        }

        private void operation_Click(object sender, EventArgs e)
        {

            
            Button b = sender as Button;
            operation1 = b.Text;
            if (memory) firstValue = double.Parse(display.Text);
            else
            {
                if ((chek)) //Если операции нажимаются больше одного раза
                {
                    equation.Text = "";
                    count = true;
                    equals.PerformClick();
                    operation_pressed = true;

                    equation.Text += firstValue + " " + saver;
                }
                else
                {

                    firstValue = double.Parse(display.Text);
                    operation_pressed = true;
                    equation.Text = firstValue + " " + operation1;
                    chek = true;
                }


            }
            }  

        private void equals_Click(object sender, EventArgs e)
        {
            if(!count)
            {
                equation.Text = "";
                chek = false;
            }
            secondValue = double.Parse(display.Text);
            Brain(operation1,firstValue,secondValue);
            operation_pressed = false;
            firstValue = double.Parse(display.Text);
            saver = operation1;
            operation1 = "";
            count = false;
        }

        public void Brain(string op,double first,double second)
        {
            try
            {
                switch (op)
                {
                    case "+":
                        display.Text = (first + second).ToString();
                        break;
                    case "-":
                        display.Text = (first - second).ToString();
                        break;
                    case "*":
                        display.Text = (first * second).ToString();
                        break;
                    case "/":
                        display.Text = (first + second).ToString();
                        break;
                    case "sqrt":
                        double sq = Double.Parse(display.Text);
                        sq = Math.Sqrt(sq);
                        display.Text = (sq).ToString();

                        break;
                    case "1/x":
                        double x = 1 / Double.Parse(display.Text);
                        display.Text = (x).ToString(); 
                         break;
                    case "x*x":
                        display.Text = (Double.Parse(display.Text)*Double.Parse(display.Text)).ToString() ;
                        break;
                    case "+-":
                        double y = (-1)* Double.Parse(display.Text);
                        display.Text = (y).ToString();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void C_Click(object sender, EventArgs e)
        {
            display.Clear();
            display.Text = "0";
            firstValue = 0;
            secondValue = 0;
            equation.Text = "";
        }

        private void MC_Click(object sender, EventArgs e)
        {
            specMemory = 0;
            equation.Text = "";
        }

        private void MPlus_Click(object sender, EventArgs e)
        {
            memory = true;
            operationplus.PerformClick();
                     
            specMemory = firstValue+specMemory;
            equation.Text = "M";
            memory = false;
            display.Text = "";
        }

        private void MMinus_Click(object sender, EventArgs e)
        {
            memory = true;
            operationplus.PerformClick();

            specMemory -= firstValue;
            equation.Text = "M";
            memory = false;
            display.Text = "";
        }

        private void MS_Click(object sender, EventArgs e)
        {
            specMemory = Double.Parse(display.Text);
            equation.Text = "";
        }

        private void MR_Click(object sender, EventArgs e)
        {
            display.Text = (specMemory).ToString();
        }


    }
}
