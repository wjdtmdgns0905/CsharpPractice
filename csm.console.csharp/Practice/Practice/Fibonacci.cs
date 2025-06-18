using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Practice
{
    class Fibonacci
    {

        static Dictionary<long, long> values;

        static void Solution(string[] args)
        {

            values = new Dictionary<long, long>();

            int input = int.Parse(Console.ReadLine());


            saved = new long[input + 1];
            saved[0] = 0;
            saved[1] = 1;
            saved[2] = 1;

            Console.WriteLine(Fibo1(input));

        }




        static long[] saved;
        static long Fibo1(long n)
        {
            if (saved[n] == 0)
            {
                saved[n] = Fibo1(n - 1) + Fibo1(n - 2);
            }

            return saved[n];
        }


        static long Fibo(long n)
        {

            if (n <= 1)
            {
                if (!values.ContainsKey(1))
                {
                    values.Add(1, 1);
                }
                return n;
            }
            if (values.ContainsKey(n))
            {
                return values[n];
            }
            else if (values.ContainsKey(n - 1) && values.ContainsKey(n - 2))
            {
                values.Add(n, values[n - 1] + values[n - 2]);
                return values[n];
            }
            else if (values.ContainsKey(n - 1))
            {
                values.Add(n, values[n - 1] + +Fibo(n - 2));
                return values[n];
            }
            else if (values.ContainsKey(n - 2))
            {
                values.Add(n, Fibo(n - 1) + values[n - 2]);
                return values[n];
            }
            else
            {
                values.Add(n, Fibo(n - 1) + Fibo(n - 2));
                return values[n];
            }


        }
    }
}

