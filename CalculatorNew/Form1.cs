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
    public partial class Calculator : Form
    {
        double firstValue = 0;
        double secondValue = 0;
        string operation = "";
        bool operation_pressed = false;
        bool count;
        int k = 0;
      
        bool chek = false;

        public Calculator()
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
            operation = b.Text;
            if ((chek) ) //Если операции нажимаются больше одного раза
            {
                count = true;
                equals.PerformClick();
                operation_pressed = true;
                
                equation.Text += firstValue + " " + operation;
            }
            else
            {
                
                firstValue = double.Parse(display.Text);
                operation_pressed = true;
                equation.Text = firstValue + " " + operation;
                chek = true;
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
            Brain(operation,firstValue,secondValue);
            operation_pressed = false;
            firstValue = double.Parse(display.Text);
            operation = "";
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

    }
}
