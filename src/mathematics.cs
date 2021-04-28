using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Matematická knihovna.
/// </summary>
namespace math_library
{   
    /// <summary>
    /// Rozdělení funkcí
    /// </summary>
    public class mathematics
    {
        //scitaní
        /// <summary>
        /// Sčítání
        /// </summary>
        /// <param name="a">první číslo</param>
        /// <param name="b">druhé číslo</param>
        /// <returns>Součet parametrů</returns>
        public static double Plus(double a, double b)
        {
            return a + b;
        }
        //odčítání
        /// <summary>
        /// Odčítání
        /// </summary>
        /// <param name="a">první číslo</param>
        /// <param name="b">druhé číslo</param>
        /// <returns>Rozdíl parametrů</returns>
        public static double Minus(double a, double b)
        {
            return a - b;
        }
        //nasobení
        /// <summary>
        /// Násobení
        /// </summary>
        /// <param name="a">první číslo</param>
        /// <param name="b">druhé číslo</param>
        /// <returns>Součin parametrů</returns>
        public static double Mult(double a, double b)
        {
            return a * b;
        }
        //dělení
        /// <summary>
        /// Dělení
        /// </summary>
        /// <param name="a">dělenec</param>
        /// <param name="b">dělitel</param>
        /// <returns>Podíl parametrů</returns>
        public static double Div(double a, double b)
        {
            return a / b;
        }
        //mocnina
        /// <summary>
        /// Mocnina
        /// </summary>
        /// <param name="a">číslo</param>
        /// <param name="b">mocnina</param>
        /// <returns>Umocněné číslo</returns>
        public static double Exp(double a, double b)
        {
            double pow = 1;
            if (b >= 0)
            {
                for (int i = 0; i < b; i++)
                    pow = pow * a;
            }
            else
            {
                for (int i = 0; i > b; i--)
                    pow = pow / a;
            }
            return pow;    
        }
        //faktoriál
        /// <summary>
        /// Faktoriál
        /// </summary>
        /// <param name="a">číslo</param>
        /// <param name="factorial">uložení výsledku</param>
        /// <returns>Faktoriál čísla</returns>
        public static double Fact(double a)
        {
            double factorial = 1;
            for (int i = 1; i <= a; i++)
                factorial = factorial * i;

            return factorial;
        }
        //odmocnina
        /// <summary>
        /// Odmocnina
        /// </summary>
        /// <param name="a">odmocnina</param>
        /// <param name="b">číslo</param>
        /// <returns>Odmocnina čísla</returns>
        public static double Sqrt(double a, double b)
        {
            return Math.Pow(b, 1/a);
        }
        //modulo
        /// <summary>
        /// Modulo
        /// </summary>
        /// <param name="a">Dělenec</param>
        /// <param name="b">Dělitel</param>
        /// <returns>Zbytek z dělení</returns>
        public static double Mod(double a, double b)
        {
            return a % b;
        }
    }
}
