using System;
using System.Collections.Generic;
using System.Linq;

public class BJ2667
{
    static int[,] map;
    static Dictionary<int, int> groups;
    static int[] dx;
    static int[] dy;
    static int count;
    static bool[,] visited;

    public static void Solution()
    {
        int n = int.Parse(Console.ReadLine());
        map = new int[n, n];
        groups = new Dictionary<int, int>(n);
        visited = new bool[n , n];
        count = 0;

        Stack<(int, int)> house = new Stack<(int, int)>();

        for(int i = 0; i<n; i++)
        {
            string values = Console.ReadLine();
            for(int j = 0; j<values.Length; j++)
            {
                if((values[j]-'0') == 1)
                {
                    house.Push((i, j));
                }

                map[i, j] = values[j]-'0';
            }
        }

        dx = new int[] { 0, 0, 1, -1 };
        dy = new int[] { 1, -1, 0, 0 };

     

        while(house.Count > 0)
        {
            (int, int) item = house.Pop();
            if (visited[item.Item1, item.Item2])
                continue;

            groups.Add(count, 0);
            Dfs(item.Item1, item.Item2);
            count++;
        }

        List<int> answer = new List<int>();

        for(int i=0; i<groups.Count; i++)
        {
            answer.Add(groups[i]);
        }

        answer.Sort();
        

        Console.WriteLine(answer.Count);

        for(int i=0; i<answer.Count; i++)
        {
            Console.WriteLine(answer[i]);
        }

    }

    static void Dfs(int y, int x)
    {
        if (visited[y, x])
        {
            return;
        }

        groups[count]++;
        visited[y, x] = true;

        for(int i=0; i < 4; i++)
        {
            int newY = y + dy[i];
            int newX = x + dx[i];
            if (CanVisit(newY, newX))
            {
                Dfs(newY, newX);
            }
        }
    }

    static bool CanVisit(int y, int x)
    {
        if (y >= 0 && y < map.GetLength(0) && x >= 0 && x < map.GetLength(1) && map[y,x]==1)
        {
            return true;
        }

        return false;
    }

}