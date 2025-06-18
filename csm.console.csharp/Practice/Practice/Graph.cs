using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Practice
{
    struct OutEdge
    {
        public int Vertex { get; }
        public int Weight { get; }

        public OutEdge(int vertex, int weight)
        {
            Vertex = vertex;
            Weight = weight;
        }

    }

    class Graph
    {
        public static void solution(int[] array)
        {
            List<OutEdge>[] graph = new List<OutEdge>[7];
            for(int index= 0; index <graph.Length; index++)
            {
                graph[index] = new List<OutEdge>();
            }


            graph[0].Add(new OutEdge(1, 1)); // 0->1

            graph[1].Add(new OutEdge(0, 1)); // 1 -> 0
            graph[1].Add(new OutEdge(2, 2)); // 1 -> 2
            graph[1].Add(new OutEdge(3, 2)); // 1 -> 3

            graph[2].Add(new OutEdge(1, 2)); // 2 -> 1
            graph[2].Add(new OutEdge(5, 6)); // 2 -> 5
            graph[2].Add(new OutEdge(6, 3)); // 2 -> 6

            graph[3].Add(new OutEdge(1, 2)); // 3 -> 1
            graph[3].Add(new OutEdge(4, 1)); // 3 -> 4
            graph[3].Add(new OutEdge(5, 4)); // 3 -> 5

            graph[4].Add(new OutEdge(3, 1)); // 4 -> 3

            graph[5].Add(new OutEdge(2, 6)); // 5 -> 2
            graph[5].Add(new OutEdge(3, 4)); // 5 -> 3

            graph[6].Add(new OutEdge(2, 3)); // 6 -> 2


            // [0] : { (1,1) } 
            // [1] : { (0,1), (2,2), (3,2) } 
            // [2] : { (1,2), (5,6), (6,3) } 
            // [3] : { (1,2), (4,1), (5,4) } 
            // [4] : { (3,1) } 
            // [5] : { (2,6), (3,4) } 
            // [6] : { (2,3) } 

        }

    }
 
}
