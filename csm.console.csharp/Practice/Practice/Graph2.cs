using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice.Practice
{
    class Graph2
    {
        public static void solution(int[] array)
        {
            List<int>[] list = new List<int>[6];

            for(int i =0; i<list.Length; i++)
            {
                list[i] = new List<int>();
            }


            list[0].Add(1); // A -> B

            list[1].Add(2); // B -> C

            list[2].Add(4); // C -> E

            list[4].Add(3); // E -> D

            list[3].Add(1); // D -> B

            list[4].Add(5); // E -> F


            for(int i=0; i<7; i++)
            {
                Console.WriteLine(i);
            }

        }
    }
}
