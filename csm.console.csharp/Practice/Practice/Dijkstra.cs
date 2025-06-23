using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Practice
{
    class Dijkstra
    {
        const int Inf = 987654321;

        static int[][] graph;

        public static void Solution()
        {
            ConstructGraph();
            while (true)
            {
                Console.Write("시작 지점 입력 : ");
                int start = int.Parse(Console.ReadLine());
                Console.Write("도착 지점 입력 : ");
                int end = int.Parse(Console.ReadLine());

                Console.WriteLine($"{start} -> {end} 최단 거리 : {Dijkstra.GetMinDistance(start, end)}");
            }
        }

        public static void ConstructGraph()
        {
            graph = new int[7][];

            graph[0] = new int[] { 0, 7, Inf, Inf, 3, 10, Inf };
            graph[1] = new int[] { 7, 0, 4, 10, 2, 6, Inf };
            graph[2] = new int[] { Inf, 4, 0, 2, Inf, Inf, Inf };
            graph[3] = new int[] { Inf, 10, 2, 0, 11, Inf, 4 };
            graph[4] = new int[] { 3, 2, Inf, 11, 0, Inf, 5 };
            graph[5] = new int[] { 10, 6, Inf, 9, Inf, 0, Inf };
            graph[6] = new int[] { Inf, Inf, Inf, 4, 5, Inf, 0 };


        } 

        public static int GetMinDistance(int start, int end)
        {
            int[] dist = new int[7];

            for(int i=0; i<dist.Length; i++)
            {
                dist[i] = Inf;
            }


            dist[start] = 0;
            Dictionary<int, int> way = new Dictionary<int, int>(7);

            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
            priorityQueue.Enqueue(start, dist[start]);

            int[] path = new int[7];
            path[start] = start;
            while(priorityQueue.Count> 0)
            {
                int v = priorityQueue.Dequeue();
                


                //  i 는 다음에 가야할 노드
                for (int i = 0; i < graph[v].Length; i++)
                {
                    // 현재 노드에서 다음 노드까지의 거리 + 현재 노드까지 오는데 걸리는 거리 < 가야하는 노드에 지금 기록되어있는 거리
                    if (graph[v][i] + dist[v] < dist[i])
                    {
                        
                        // 지금 기록되어 있는 거리를 현재 노드에서 다음 노드까지의 거리 + 현재 노드까지 오는데 걸리는 거리로 초기화 한다/
                        dist[i] = graph[v][i] + dist[v];
                        path[i] = v;
                        priorityQueue.Enqueue(i, dist[i]);
                    }
                }

            }

            int current = end;
            List<int> res = new List<int>();
            while(current != start)
            {
                res.Add(current);
                current = path[current];
            }

            res.Add(current);
            res.Reverse();

            foreach(int item in res)
            {
                Console.WriteLine(item);
            }

            return dist[end];
        }

    }
}
