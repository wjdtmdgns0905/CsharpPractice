using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Practice
{
    class BJ1697
    {
        static int n;
        static int k;
        static int count;
        static int result;
        static Queue<int> queue;
        static int[] time;

        public static void Solution()
        {
            count = 0;

            string[] values = Console.ReadLine().Split();
            n = int.Parse(values[0]);
            k = int.Parse(values[1]);

            queue = new Queue<int>();

            if (k > n)
            {
                time = new int[k*2+1];
            }
            else
            {
                time = new int[n*2+1];
            }


            queue = new Queue<int>();
            time[n] = 1;
            queue.Enqueue(n);

            Bfs();

            Console.WriteLine(time[k]-1);
            
        }

        static void Bfs()
        {
            int position;;
            while (queue.Count>0)
            {
                position = queue.Dequeue();

                if (position + 1 < time.Length)
                {
                    if (time[position] + 1 <= time[position + 1] || time[position + 1] == 0)
                    {
                        time[position + 1] = time[position] + 1;
                        queue.Enqueue(position + 1);
                    }
                }
                if (position * 2 < time.Length)
                {
                    if (time[position] + 1 <= time[position * 2] || time[position * 2] == 0)
                    {
                        time[position * 2] = time[position] + 1;
                        queue.Enqueue(position * 2);
                    }
                }
                if (position - 1 >= 0)
                {
                    if (time[position] + 1 <= time[position - 1] || time[position - 1] == 0)
                    {
                        time[position - 1] = time[position] + 1;
                        queue.Enqueue(position - 1);
                    }
                }
            }

        }

        
    }
}
