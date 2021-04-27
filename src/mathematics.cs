using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_library
{
    public class mathematics
    {
        //plus
        public static double Plus(double a, double b)
        {
            return a + b;
        }
        //minus
        public static double Minus(double a, double b)
        {
            return a - b;
        }
        //multiplication
        public static double Mult(double a, double b)
        {
            return a * b;
        }
        //division
        public static double Div(double a, double b)
        {
            return a / b;
        }
        //exponentiation
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
            //return Math.Pow(a, b);
        }
        //factorial
        public static double Fact(double a, double b)
        {
            double factorial = 1;
            for (int i = 1; i <= a; i++)
                factorial = factorial * i;

            return factorial;
        }
        //square root
        public static double Sqrt(double a, double b)
        {
            /*solution1 double error = 0.00001; //define the precision
            double num = b;
            while ((num - b / num) > error)
            {
                num = (num + b / num) / a;
            }
            return num;*/
            return Math.Pow(b, 1/a);
        }
        //modulo
        public static double Mod(double a, double b)
        {
            return a % b;
        }
    }
}
