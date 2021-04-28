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

/// <summary>
/// Hlavní zdrojový kód pro Calculater.
/// </summary>
namespace Calculater
{
    /// <summary>
    /// Hlavní třída.
    /// </summary> 
    /// <param name="num1">první zadané číslo</param>
    /// <param name="num2">druhé zadané číslo</param>
    /// <param name="op">zadaný znak pro výpočet</param>
    /// <param name="fact_pressed">je true, pokud se zadal faktoriál</param>
    /// <param name="op_pressed">je true, pokud se zadal znak pro výpočet</param>
    /// <param name="minus_pressed">je true, pokud je na inputu negativní číslo</param>
    /// <param name="power_pressed">je true, pokud se zadala mocnina</param>
    /// <param name="equal_pressed">je true, pokud se zadalo "rovná se"</param>
    /// <param name="number_pressed">je true, pokud se zadalo číslo nebo čárka</param>
    public partial class Calc : Form
    {
        double num1 = 0;    //první číslo
        double num2 = 0;    //druhé číslo
        String op = "";     //znak operace
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

        //čísla a čárka
        /// <summary>
        /// Výpis čísel.
        /// </summary> 
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

            //vynechání čarky po druhém zmáčnknutí
            if (button.Text == ",")
            {
                if (!input.Text.Contains(","))
                    input.Text = input.Text + button.Text;
            }
            else
                input.Text = input.Text + button.Text;
            
            number_pressed = true;
        }

        //zmáčknuté C (delete)
        /// <summary>
        /// Smazání inputu.
        /// </summary>
        private void delete(object sender, EventArgs e)
        {
            input.Text = " ";
            overview.Text = "";
        }

        //znak operca zmáčknutý
        /// <summary>
        /// Načtení znaku operace a prvního čísla.
        /// </summary>
        private void op_press(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            if (((input.Text == " ") && (button.Text == "-")) || (op_pressed))
            {
                if (op_pressed) //záporné číslo
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
                if (button.Text == "!") //faktoriál
                {
                    overview.Text = input.Text + button.Text;
                    fact_pressed = true;
                }
                else if (button.Text == "^") //mocnina
                {
                    power_pressed = true;
                    overview.Text = "(" + input.Text + ")" + button.Text;
                }
                else
                    overview.Text = input.Text + button.Text;

                //uložení prvního čísla
                num1 = double.Parse(input.Text);
                op = button.Text;
                op_pressed = true;
                input.Clear(); //text reset
            }
            else 
                input.Text = "chybí číslo";
        }

        //zmáčknuté číslo
        /// <summary>
        /// Načtení druhého čísla a "rovná se".
        /// </summary>
        private void op_equal(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (fact_pressed) //faktoriál
            {
                overview.Text = overview.Text + button.Text;
                fact_pressed = false;
            }
            else if (minus_pressed) //záporné číslo potřebuje závorky
            {
                num2 = double.Parse(input.Text);
                overview.Text = num1 + op + "(" + num2 + ")" + button.Text;
            }
            else if (power_pressed)
            {
                num2 = double.Parse(input.Text); //mocnina se závorkama
                overview.Text = "(" + num1 + ")" + op + num2 + button.Text;
            }
            else
            {
                num2 = double.Parse(input.Text);
                overview.Text = num1 + op + num2 + button.Text;
            }



            //výpočet
            switch (op)
            {
                case "+": //sčítání
                    input.Text = mathematics.Plus(num1, num2).ToString();
                    break;

                case "-": //odčítání
                    input.Text = mathematics.Minus(num1, num2).ToString();
                    break;

                case "*": //násobení
                    input.Text = mathematics.Mult(num1, num2).ToString();
                    break;

                case "/": //dělení
                    input.Text = mathematics.Div(num1, num2).ToString();
                    break;

                case "^": //mocnina
                    input.Text = mathematics.Exp(num1, num2).ToString();
                    break;

                case "√": //odmocnina
                    input.Text = mathematics.Sqrt(num1, num2).ToString();
                    break;

                case "!": //faktoriál
                    input.Text = mathematics.Fact(num1).ToString();
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

        //zmáčknuté help
        /// <summary>
        /// Volání sekce Help.
        /// </summary>
        private void help(object sender, EventArgs e)
        {
            new Help().Show();
        }

        //přístup z klávesnice
        /// <summary>
        /// Přístup pomocí klávesnice.
        /// </summary>
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
            else if (e.KeyCode.Equals(Keys.F))          //faktoriál
                button16.PerformClick();
            else if (e.KeyCode.Equals(Keys.M))          //modulo
                button21.PerformClick();
            else if (e.KeyCode.Equals(Keys.P))          //mocnina
                button10.PerformClick();
            else if (e.KeyCode.Equals(Keys.R))          //odmocnina
                button20.PerformClick();
            else if (e.KeyCode.Equals(Keys.H))          //help
                button22.PerformClick();
            else if (e.KeyCode.Equals(Keys.E))          //=
                button11.PerformClick();
            else if (e.KeyCode.Equals(Keys.Back) || e.KeyCode.Equals(Keys.Delete))       //delete
                button12.PerformClick();
        }
    }
}
