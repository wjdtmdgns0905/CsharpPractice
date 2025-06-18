
namespace Practice.Practice
{
    class BinarySearch
    {
        static int answer = 0;
        public static void Solution()
        {
            List<int> list = new List<int>(10) { 1, 2, 4, 9, 10, 10, 10,10, 15, 68, 98, 103 };


            Console.WriteLine(BinarySearching(list, 107, 0, list.Count - 1));
            Console.WriteLine(UpperBound(list, 10));
            Console.WriteLine(LowerBound(list, 10));

        }


        static int UpperBound(List<int> list, int key)
        {
            

            int s = 0;
            int e = list.Count -1 ;

            int mid = (s + e) / 2;


            while (list[mid] != key)
            {
                if (list[mid] > key)
                {
                    e= mid -1;
                }
                else
                {
                    e = mid + 1;
                }

                mid = (s + e) / 2;
            }

            
            while (list[mid] == list[mid + 1])
            {
                mid++;
            }

            return mid;
        }

        static int LowerBound(List<int> list, int key)
        {


            int s = 0;
            int e = list.Count - 1;

            int mid = (s + e) / 2;


            while (list[mid] != key)
            {
                if (list[mid] > key)
                {
                    e = mid - 1;
                }
                else
                {
                    e = mid + 1;
                }

                mid = (s + e) / 2;
            }


            while (list[mid] == list[mid - 1])
            {
                mid--;
            }

            return mid;
        }


        static bool BinarySearching(List<int> list, int key, int start, int end)
        {
            if(start > end)
            {
                return false;
            }

            int mid = (start + end)/2;

            if(list[mid] > key)
            {
                BinarySearching(list, key, start, mid-1);
            }
            else if (list[mid] < key)
            {
                BinarySearching(list, key, mid+1, end);
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}
