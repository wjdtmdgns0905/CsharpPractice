using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Practice
{
    class BJ2178
    {
        static int[,] map;
        static int[] dx;
        static int[] dy;
        static int[,] time;
        static Queue<(int, int)> pos;
        

        public static void Solution()
        {
            string[] inputStr = Console.ReadLine().Split();

            int n = int.Parse(inputStr[0]);
            int m = int.Parse(inputStr[1]);
            map = new int[n, m];
            time = new int[n, m];
            pos = new Queue<(int, int)>(n*m);


            for (int i = 0; i < n; i++)
            {
                string values = Console.ReadLine();
                for (int j = 0; j < values.Length; j++)
                {
                    map[i, j] = values[j] - '0';
                }
            }

            dx = new int[] { 0, 0, 1, -1 };
            dy = new int[] { 1, -1, 0, 0 };

            pos.Enqueue((0,0));
            time[0, 0] = 1;


            Bfs();

            Console.WriteLine(time[n-1, m-1]);
            
        }

        static void Bfs()
        {
            while(pos.Count> 0)
            {
                (int, int) currentPos = pos.Dequeue();
                for (int i = 0; i<4; i++)
                {
                    int newY= currentPos.Item1 + dy[i];
                    int newX = currentPos.Item2 + dx[i];

                    if(CanVisit(newY, newX) && time[newY, newX]==0)
                    {
                        time[newY, newX] = time[currentPos.Item1, currentPos.Item2] + 1;
                        pos.Enqueue((newY, newX));
                    }
                }
            }


        }

        static bool CanVisit(int y, int x)
        {
            if (y >= 0 && y < map.GetLength(0) && x >= 0 && x < map.GetLength(1) && map[y, x] == 1)
            {
                return true;
            }

            return false;
        }

    }
}
