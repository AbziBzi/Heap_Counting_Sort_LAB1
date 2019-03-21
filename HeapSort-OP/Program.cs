using HeapSort_OP;
using System;
using System.Diagnostics;
using System.IO;

namespace ALG_LAB_1
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] values = {1000, 10000, 25000};
            int seed = (int)DateTime.Now.Ticks;
            StartTest(seed, values);
            Console.ReadKey();
        }

        public static void StartTest(int seed, int[] values)
        {
            string sortName = " ";

            while (sortName != "stop")
            { 
                Console.WriteLine("Pasirinkite rykiavima is pateiktu: \nNorint baigti darba - rasykite 'stop'.\nHeapSort_D     HeapSort_OP     CountingSort_D      CountingSort_OP");
                sortName = Console.ReadLine();
                Console.WriteLine();
                string[] times = new string[values.Length];

                if (sortName.ToUpper() == "HEAPSORT_D")
                {
                    Console.WriteLine(sortName.ToUpper());
                    Console.WriteLine("Elements Count:           Run Time:");
                    Run_HeapSort_D(seed, values);
                }
                else if (sortName.ToUpper() == "HEAPSORT_OP")
                {
                    Console.WriteLine(sortName.ToUpper());
                    Console.WriteLine("Elements Count:           Run Time:");
                    Run_HeapSort_OP(seed, values);
                    sortName = "COUNTINGSORT_D";
                }
                else if (sortName.ToUpper() == "COUNTINGSORT_D")
                {
                    Console.WriteLine(sortName.ToUpper());
                    Console.WriteLine("Elements Count:           Run Time:");
                    Run_CountingSort_D(seed, values);

                }
                else if (sortName.ToUpper() == "COUNTINGSORT_OP")
                {
                    Console.WriteLine(sortName.ToUpper());
                    Console.WriteLine("Elements Count:           Run Time:");
                    Run_CountingSort_OP(seed, values);
                }
                else
                    Console.WriteLine("Paduota bloga komanda");
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        public static void Run_HeapSort_D(int seed, int[] values)
        {
            string fileName = @"mydataarray.dat";
            string fileName2 = @"mydatalist.dat";

            Console.WriteLine("=== ARRAY ===");

            for (int i = 0; i < values.Length; i++)
            {
                MyFileArray myFileArray = new MyFileArray(fileName, values[i], seed);
                using (myFileArray.fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    var watch = Stopwatch.StartNew();
                    HeapSort_Array(myFileArray);
                    watch.Stop();
                    string time = watch.Elapsed.ToString();
                    Console.WriteLine("{0,-20}      {1}", values[i], time);
                }
            }
            Console.WriteLine("=== LIST ===");

            for (int i = 0; i < values.Length; i++)
            {
                MyFileList myFileList = new MyFileList(fileName2, values[i], seed);
                using (myFileList.fs = new FileStream(fileName2, FileMode.Open, FileAccess.ReadWrite))
                {
                    var watch = Stopwatch.StartNew();
                    HeapSort_List(myFileList);
                    watch.Stop();
                    string time = watch.Elapsed.ToString();
                    Console.WriteLine("{0,-20}      {1}", values[i], time);
                }
            }
        }

        public static void Run_CountingSort_D(int seed, int[] values)
        {
            string fileName = @"mydataarray.dat";
            string fileName2 = @"mydatalist.dat";

            Console.WriteLine("=== ARRAY ===");

            for (int i = 0; i < values.Length; i++)
            {
                MyFileArray myFileArray = new MyFileArray(fileName, values[i], seed);
                using (myFileArray.fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    var watch = Stopwatch.StartNew();
                    CountingSort_Array(myFileArray);
                    watch.Stop();
                    string time = watch.Elapsed.ToString();
                    Console.WriteLine("{0,-20}      {1}", values[i], time);
                }
            }
            Console.WriteLine("=== LIST ===");

            for (int i = 0; i < values.Length; i++)
            {
                MyFileList myFileList = new MyFileList(fileName2, values[i], seed);
                using (myFileList.fs = new FileStream(fileName2, FileMode.Open, FileAccess.ReadWrite))
                {
                    var watch = Stopwatch.StartNew();
                    CountingSort_List(myFileList);
                    watch.Stop();
                    string time = watch.Elapsed.ToString();
                    Console.WriteLine("{0,-20}      {1}", values[i], time);
                }
            }
        }

        public static void Run_HeapSort_OP(int seed, int[] values)
        {
            Console.WriteLine("=== ARRAY ===");

            for (int i = 0; i < values.Length; i++)
            {
                MyDataArray myArray = new MyDataArray(values[i], seed);
                var watch = Stopwatch.StartNew();
                HeapSort_Array(myArray);
                watch.Stop();
                string time = watch.Elapsed.ToString();
                Console.WriteLine("{0,-20}      {1}", values[i], time);
            }
            Console.WriteLine("=== LIST ===");

            for (int i = 0; i < values.Length; i++)
            {
                MyDataList myList = new MyDataList(values[i], seed);
                var watch = Stopwatch.StartNew();
                HeapSort_List(myList);
                watch.Stop();
                string time = watch.Elapsed.ToString();
                Console.WriteLine("{0,-20}      {1}", values[i], time);
            }
        }

        public static void Run_CountingSort_OP(int seed, int[] values)
        {
            Console.WriteLine("=== ARRAY ===");

            for (int i = 0; i < values.Length; i++)
            {
                MyDataArray myArray = new MyDataArray(values[i], seed);
                var watch = Stopwatch.StartNew();
                CountingSort_Array(myArray);
                watch.Stop();
                string time = watch.Elapsed.ToString();
                Console.WriteLine("{0,-20}      {1}", values[i], time);
            }

            Console.WriteLine("=== LIST ===");

            for (int i = 0; i < values.Length; i++)
            {
                MyDataList myList = new MyDataList(values[i], seed);
                var watch = Stopwatch.StartNew();
                CountingSort_List(myList);
                watch.Stop();
                string time = watch.Elapsed.ToString();
                Console.WriteLine("{0,-20}      {1}", values[i], time);
            }
        }

        /// <summary>
        /// Veikia
        /// </summary>
        /// <param name="arr"></param>
        public static void HeapSort_Array(DataArray arr)
        {
            int length = arr.Length;

            // Build max heap
            for (int i = length / 2 - 1; i >= 0; i--)
                Heapify_Array(arr, length, i);

            // Heap sort
            for (int i = length - 1; i >= 0; i--)
            { 
                // Swap
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Heapify root element
                Heapify_Array(arr, i, 0);
            }
        }

        /// <summary>
        /// Veikia
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="length"></param>
        /// <param name="root"></param>
        static void Heapify_Array(DataArray arr, int length, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < length && arr[left] > arr[largest])
                largest = left;

            if (right < length && arr[right] > arr[largest])
                largest = right;

            // Swap and continue heapifying if root is not largest
            if (largest != root && largest >= 1)
            {
                // Swap
                int swap = arr[root];
                arr[root] = arr[largest];
                arr[largest] = swap;

                Heapify_Array(arr, length, largest);
            }
        }

        /// <summary>
        /// Veikia
        /// </summary>
        /// <param name="list"></param>
        public static void HeapSort_List(DataList list)
        {
            int length = list.Length;

            // Build max heap
            for (int i = length / 2 - 1; i >= 0; i--)
                Heapify_List(list, length, i);


            // Heap sort
            for (int i = length - 1; i >= 0; i--)
            {
                // Swap
                int temp = list.Get(0);
                list.Set(0, list.Get(i));
                list.Set(i, temp);

                // Heapify root element
                Heapify_List(list, i, 0);
            }
        }

        /// <summary>
        /// Veikia
        /// </summary>
        /// <param name="list"></param>
        /// <param name="length"></param>
        /// <param name="root"></param>
        static void Heapify_List(DataList list, int length, int root)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < length && list.Get(left) > list.Get(largest))
                largest = left;

            if (right < length && list.Get(right) > list.Get(largest))
                largest = right;

            // Swap and continue heapifying if root is not largest
            if (largest != root && largest >= 1)
            {
                // Swap
                int swap = list.Get(root);
                list.Set(root, list.Get(largest));
                list.Set(largest, swap);

                Heapify_List(list, length, largest);
            }
        }


        /// <summary>
        /// Veikia
        /// </summary>
        /// <param name = "arr" ></ param >
        public static void CountingSort_Array(DataArray arr)
        {
            if (arr == null)
                return;

            int[] output = new int[arr.Length];
            int min = arr[0];
            int max = arr[0];

            //Finds min and max values
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] <= min)
                    min = arr[i];
                if (arr[i] >= max)
                    max = arr[i];
            }

            //Counts frequencies
            int[] counts = new int[max - min + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                counts[arr[i] - min]++;
            }

            //Each element stores the sum of previous counts
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }

            //Puts each element from items array to the right place using counts saved index
            for (int i = 0; i < arr.Length; i++)
            {
                output[counts[arr[i] - min] - 1] = arr[i];
                counts[arr[i] - min]--;
            }

            //Copies output to object
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = output[i];
            }
        }

        /// <summary>
        /// Letai bet veikia
        /// </summary>
        /// <param name="list"></param>
        public static void CountingSort_List(DataList list)
        {
            if (list == null)
                return;

            int[] output = new int[list.Length];
            int min = list.Min();
            int max = list.Max();

            //Counts frequencies
            int[] counts = new int[max - min + 1];
            list.Head();
            for (int i = 0; i < list.Length; i++)
            {
                counts[list.Current() - min]++;
                list.Next();
            }

            //Each element stores the sum of previous counts
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }

            //Puts each element from items array to the right place using counts saved index
            list.Head();
            for (int i = 0; i < list.Length; i++)
            {
                output[counts[list.Current() - min]--] = list.Current();
                list.Next();
            }

            //Copies output to object
            list.Head();
            for (int i = 0; i < list.Length; i++)
            {
                list.Change(output[i]);
                list.Next();
            }
        }
    }
}
