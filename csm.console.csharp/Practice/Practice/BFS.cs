using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice.Practice
{
    class BFS
    {
        static List<int>[] map;
        static int n;
        static int answer;

        static bool[] visited;

        public static void Solution()
        {
            answer = 0;
            n = int.Parse(Console.ReadLine().Trim());
            int pairs = int.Parse(Console.ReadLine().Trim());
            visited = new bool[n];
            map = new List<int>[n];

            for (int i = 0; i < map.Length; i++)
            {
                map[i] = new List<int>();
            }


            for (int i = 0; i < pairs; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();

                int a = int.Parse(tokens[0]) - 1;
                int b = int.Parse(tokens[1]) - 1;

                map[a].Add(b);
                map[b].Add(a);

            }



            int result= 0 ;
            Console.WriteLine(Dfs(0));

        }

        public static int Dfs(int node)
        {
          
            if (map[node].Count <=0)
            {
                return 0;
            }

            visited[node] = true;


            int count = 1;



            foreach (int nextNode in map[node])
            {
                if (visited[nextNode])
                    continue;
                count += Dfs(nextNode);
            }

            return count;
        }


        public static void Dfs2(int node)
        {
            Stack<int> st = new Stack<int>();
            st.Push(1);

            while(st.Count > 0)
            {
                int v = st.Pop();

                if (visited[v])
                {
                    continue;
                }

                visited[v] = true;
                answer++;

                foreach(int next in map[v]) 
                {
                    if (visited[next]){
                        continue;
                    }
                    st.Push(next);
                }
            }
        }

        

        public static void Bfs2()
        {
            Queue<int> queue = new Queue<int>(n);
            queue.Enqueue(0);
            

            while (queue.Count > 0)
            {
                int comIndex = queue.Dequeue();

                if (visited[comIndex])
                    continue;

                foreach (int i in map[comIndex])
                {
                    if (visited[i])
                        continue;

                    queue.Enqueue(i);
                }

                visited[comIndex] = true;
                answer++;
            }

        }

       

    }
}

