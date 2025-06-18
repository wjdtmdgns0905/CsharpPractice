using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Practice
{
    class QuickSort
    {
        public static int solution(int[] array)
        {
            int answer = 0;

            RecursiveQuickSort(array, 0, array.Length - 1);

            answer = array[(array.Length / 2) + 1];

            return answer;
        }

        public static void RecursiveQuickSort(int[] array, int start, int end)
        {
            if (start < end)
            {

                int mid = QuickSortPartition(array, start, end);

                RecursiveQuickSort(array, start, mid);
                RecursiveQuickSort(array, mid + 1, end);

            }
        }


        public static int QuickSortPartition(int[] array, int start, int end)
        {
            int pivot = array[(start + end) / 2];

            while (true)
            {
                while (pivot > array[start])
                {
                    start++;
                }
                while (pivot < array[end])
                {
                    end--;
                }

                if (start < end)
                {
                    Swap(array, start, end);
                    start++;
                    end--;
                }
                else
                {
                    return end;
                }
            }

        }

        public static void Swap(int[] array, int start, int end)
        {
            int temp = array[start];
            array[start] = array[end];
            array[end] = temp;

        }

    }
}

