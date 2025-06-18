using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Practice
{
    class Recursion2
    {
        static int n;
        static string[] contexts;
        static string opening;
        static string start;
        static string end;
        static string ending;
        static string tab;


                                                                                                                                          
        public static void Solution()
        {
            n = int.Parse(Console.ReadLine());

            start = "어느 한 컴퓨터공학과 학생이 유명한 교수님을 찾아가 물었다.";
            opening = "\"재귀함수가 뭔가요?\"";

            contexts = new string[3];

            string context1 = "\"잘 들어보게. 옛날옛날 한 산 꼭대기에 이세상 모든 지식을 통달한 선인이 있었어.";
            string context2 = "마을 사람들은 모두 그 선인에게 수많은 질문을 했고, 모두 지혜롭게 대답해 주었지.";
            string context3 = "그의 답은 대부분 옳았다고 하네. 그런데 어느 날, 그 선인에게 한 선비가 찾아와서 물었어.\"";
           
            contexts[0] = context1;
            contexts[1] = context2;
            contexts[2] = context3;

            end = "\"재귀함수는 자기 자신을 호출하는 함수라네\"";
            tab = "____";
            ending = "라고 답변하였지.";

            Console.WriteLine(start);
            Recursion(0);
        }

        public static void Recursion(int s)
        {
            Tab(s);
            Console.WriteLine(opening);

            if (s >= n)
            {
                Tab(s);
                Console.WriteLine(end);
                Tab(s);
                Console.WriteLine(ending);

                return;
            }

            foreach (string context in contexts)
            {
                Tab(s);
                Console.WriteLine(context);
            }

            Recursion(s + 1);

            Tab(s);
            Console.WriteLine(ending);

        }

        public static void Tab(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(tab);
            }
        }
    }



}
