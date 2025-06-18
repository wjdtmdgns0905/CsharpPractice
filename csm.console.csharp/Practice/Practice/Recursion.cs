using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Practice
{
    class Recursion
    {

        public static void Solution()
        {
            Foo(9);

            Console.WriteLine();
            Triangle(5);
        }

        static void Triangle(int vertical)
        {
            if (vertical < 1)
            {
                return;
            }

            PrintStar(vertical);
            Console.WriteLine();
            Triangle(vertical - 1);
        }

        static void PrintStar(int horizontal)
        {
            if (horizontal > 5)
            {
                return;
            }

            Console.Write("*");

            PrintStar(horizontal+1);
        }

        static void Foo(int i)
        {
            if (i <2)
            {
                Console.Write(1);
                return;
            }

            Foo(i / 2);

            Console.Write(i%2);
            
        }


    }
}
