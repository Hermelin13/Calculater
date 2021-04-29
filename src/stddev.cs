using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using math_library;

namespace GBV___MULGORO
{
    class stddev
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();

            for(string line = Console.ReadLine(); line != null; line = Console.ReadLine())
            {
                string[] str_numbers = line.Split(new char[] { ' ' });
                foreach(string str_num in str_numbers)
                {
                    double num;
                    
                    if (double.TryParse(str_num, out num))
                    {
                        numbers.Add(num);
                    }
                }
            }

            double n = numbers.Count;
            double sum_pow = 0;
            double n_pow_average = 0;
            double fraction;
            double result;

            foreach(float num in numbers)
            {
                sum_pow = mathematics.Plus( mathematics.Exp(num, 2), sum_pow );
                n_pow_average = mathematics.Plus(num, n_pow_average);
            }

            n_pow_average = mathematics.Div(n_pow_average, n);
            n_pow_average = mathematics.Exp(n_pow_average, 2);
            n_pow_average = mathematics.Mult(n_pow_average, n);

            fraction = mathematics.Minus(n, 1);
            fraction = mathematics.Div(1, fraction);

            result = mathematics.Minus(sum_pow, n_pow_average);
            result = mathematics.Mult(result, fraction);

            Console.WriteLine(result);
        }
    }
}
