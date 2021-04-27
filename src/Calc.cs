using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using math_library;

namespace Calculater
{
    public partial class Calc : Form
    {
        //Math count = new Math ();

        double num1 = 0;    //first number
        double num2 = 0;    //second number
        String op = "";     //math symbol
        bool fact_pressed = false;
        bool op_pressed = false;
        bool minus_pressed = false;
        bool power_pressed = false;
        bool equal_pressed = true;
        bool number_pressed = false;

        public Calc()
        {
            InitializeComponent();
        }

        //numbers and coma pressed
        private void number(object sender, EventArgs e)
        {
            //text reset 
            if (equal_pressed)
            {
                input.Clear();
                overview.Clear();
                equal_pressed = false;
            }
            Button button = (Button)sender;

            //coma exclusion
            if (button.Text == ",")
            {
                if (!input.Text.Contains(","))
                    input.Text = input.Text + button.Text;
            }
            else
                input.Text = input.Text + button.Text;
            
            number_pressed = true;
        }

        //pressed C (delete)
        private void delete(object sender, EventArgs e)
        {
            input.Text = " ";
            overview.Text = "";
        }

        //math symbol pressed
        private void op_press(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            if (((input.Text == " ") && (button.Text == "-")) || (op_pressed))
            {
                if (op_pressed) //negative number
                    minus_pressed = true;

                equal_pressed = false;
                input.Text = button.Text;
            }
            else if ((equal_pressed) && (button.Text == "-"))
            {
                equal_pressed = false;
                input.Text = button.Text;
            }
            else if (number_pressed)
            {
                if (button.Text == "!") //factorial
                {
                    overview.Text = input.Text + button.Text;
                    fact_pressed = true;
                }
                else if (button.Text == "^") //exponentiation
                {
                    power_pressed = true;
                    overview.Text = "(" + input.Text + ")" + button.Text;
                }
                else
                    overview.Text = input.Text + button.Text;

                //first number saved
                num1 = double.Parse(input.Text);
                op = button.Text;
                op_pressed = true;
                input.Clear(); //text reset
            }
            else 
                input.Text = "chybí číslo";
        }

        //equal pressed
        private void op_equal(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (fact_pressed) //factorial
            {
                overview.Text = overview.Text + button.Text;
                fact_pressed = false;
            }
            else if (minus_pressed) //negative number needs brackets
            {
                num2 = double.Parse(input.Text);
                overview.Text = num1 + op + "(" + num2 + ")" + button.Text;
            }
            else if (power_pressed)
            {
                num2 = double.Parse(input.Text); //exponentiation with brackets
                overview.Text = "(" + num1 + ")" + op + num2 + button.Text;
            }
            else
            {
                num2 = double.Parse(input.Text);
                overview.Text = num1 + op + num2 + button.Text;
            }



            //calculations
            //count.operations()
            switch (op)
            {
                case "+": //plus
                    input.Text = mathematics.Plus(num1, num2).ToString();
                    break;

                case "-": //minus
                    input.Text = mathematics.Minus(num1, num2).ToString();
                    break;

                case "*": //multiplication
                    input.Text = mathematics.Mult(num1, num2).ToString();
                    break;

                case "/": //division
                    input.Text = mathematics.Div(num1, num2).ToString();
                    break;

                case "^": //exponentiation
                    input.Text = mathematics.Exp(num1, num2).ToString();
                    break;

                case "√": //square root
                    input.Text = mathematics.Sqrt(num1, num2).ToString();
                    break;

                case "!": //factorial
                    input.Text = mathematics.Fact(num1, num2).ToString();
                    break;

                case "%": //modulo
                    input.Text = mathematics.Mod(num1, num2).ToString();
                    break;

                default:
                    break;
            }
            //reset
            num1 = 0;
            num2 = 0;
            op_pressed = false;
            minus_pressed = false;
            power_pressed = false;
            equal_pressed = true;
        }

        //help pressed
        private void help(object sender, EventArgs e)
        {
            new Help().Show();
        }

        //keyboard access
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.NumPad0))         //0
                button17.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad1))    //1 
                button9.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad2))    //2
                button8.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad3))    //3
                button7.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad4))    //4
                button4.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad5))    //5
                button3.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad6))    //6
                button2.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad7))    //7
                button1.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad8))    //8
                button6.PerformClick();
            else if (e.KeyCode.Equals(Keys.NumPad9))    //9
                button5.PerformClick();
            else if (e.KeyCode.Equals(Keys.Decimal))    //,
                button18.PerformClick();
            else if (e.KeyCode.Equals(Keys.Add))        //+
                button19.PerformClick();
            else if (e.KeyCode.Equals(Keys.Subtract))   //-
                button15.PerformClick(); 
            else if (e.KeyCode.Equals(Keys.Multiply))   //*
                button14.PerformClick();
            else if (e.KeyCode.Equals(Keys.Divide))     //"/"
                button13.PerformClick();
            else if (e.KeyCode.Equals(Keys.F))          //factorial
                button16.PerformClick();
            else if (e.KeyCode.Equals(Keys.M))          //modulo
                button21.PerformClick();
            else if (e.KeyCode.Equals(Keys.P))          //exponentiation
                button10.PerformClick();
            else if (e.KeyCode.Equals(Keys.R))          //square root
                button20.PerformClick();
            else if (e.KeyCode.Equals(Keys.H))          //help
                button22.PerformClick();
            else if (e.KeyCode.Equals(Keys.E))          //equal
                button11.PerformClick();
            else if (e.KeyCode.Equals(Keys.Back) || e.KeyCode.Equals(Keys.Delete))       //delete
                button12.PerformClick();
        }
    }
}
