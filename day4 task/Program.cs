using Microsoft.VisualBasic;
using System;
using System.Buffers.Text;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Problem 1
            int[] arr1 = new int[3];
            int[] arr2 = { 1, 2, 3 };
            int[] arr3 = new int[] { 4, 5, 6 };
            for (int i = 0; i < arr1.Length; i++)
                arr1[i] = i + 10;

            foreach (var item in arr1)
                Console.Write(item + " ");
            Console.WriteLine();

            try
            {
                Console.WriteLine(arr1[10]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            // Answer:
            // Default value of int array elements in C# is 0.
            #endregion

            #region Problem 2
            int[] a1 = { 1, 2, 3 };
            int[] a2 = a1;
            a2[0] = 100;
            Console.WriteLine("After shallow copy change:");
            Console.WriteLine(a1[0]);
            int[] a3 = (int[])a1.Clone();
            a3[0] = 500;

            Console.WriteLine("After deep copy change:");
            Console.WriteLine(a1[0]); // not affected

            //Answer:
            // Array.Clone() creates a new array instance (shallow copy of elements).
            // Array.Copy() copies elements into an already existing array.
            #endregion

            #region Problem 3
            int[,] grades = new int[3, 3];
            for (int i = 0; i < grades.GetLength(0); i++)
            {
                for (int j = 0; j < grades.GetLength(1); j++)
                {
                    Console.Write($"Student {i + 1}, Subject {j + 1}: ");
                    grades[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Grades:");
            for (int i = 0; i < grades.GetLength(0); i++)
            {
                for (int j = 0; j < grades.GetLength(1); j++)
                    Console.Write(grades[i, j] + " ");
                Console.WriteLine();
            }

            // Answer:
            // GetLength(dimension) returns size of a specific dimension.
            // Length returns total number of elements in all dimensions.
            #endregion

            #region Problem 4
            int[] arr = { 5, 2, 8, 1 };
            Array.Sort(arr);
            Console.WriteLine("After Sort: " + string.Join(",", arr));
            Array.Reverse(arr);
            Console.WriteLine("After Reverse: " + string.Join(",", arr));
            Console.WriteLine("IndexOf 8: " + Array.IndexOf(arr, 8));

            int[] copyArr = new int[4];
            Array.Copy(arr, copyArr, arr.Length);
            Console.WriteLine("After Copy: " + string.Join(",", copyArr));

            Array.Clear(arr, 0, arr.Length);
            Console.WriteLine("After Clear: " + string.Join(",", arr));

            // Answer:
            // Array.Copy copies elements normally.
            // Array.ConstrainedCopy guarantees no partial copy if an exception occurs.
            #endregion

            #region Problem 5
            int[] arrLoop = { 1, 2, 3, 4, 5 };
            for (int i = 0; i < arrLoop.Length; i++)
                Console.Write(arrLoop[i] + " ");

            Console.WriteLine();
            foreach (var item in arrLoop)
                Console.Write(item + " ");

            int index = arrLoop.Length - 1;
            while (index >= 0)
            {
                Console.Write(arrLoop[index] + " ");
                index--;
            }

            //  Answer:
            // foreach is preferred for read-only operations
            // because it is safer and prevents modifying the collection accidentally.
            #endregion

            #region Problem 6
            int number;
            bool valid;

            do
            {
                Console.Write("Enter positive odd number: ");
                valid = int.TryParse(Console.ReadLine(), out number);

            } while (!valid || number <= 0 || number % 2 == 0);

            Console.WriteLine("Valid input accepted.");

            // Answer:
            // Input validation prevents runtime errors
            // and ensures the program works with correct data only.
            #endregion

            #region Problem 7
            int[,] matrix =
            {
                {1,2,3},
                {4,5,6},
                {7,8,9}
            };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + "\t");
                Console.WriteLine();
            }

            // Answer:
            // Use tabs (\t), spacing, or formatted output
            // to display 2D arrays in matrix form clearly.
            #endregion

            #region Problem 8
            Console.Write("Enter month number: ");
            int month = int.Parse(Console.ReadLine());

            if (month == 1) Console.WriteLine("January");
            else if (month == 2) Console.WriteLine("February");
            else if (month == 3) Console.WriteLine("March");
            else Console.WriteLine("Other");

            switch (month)
            {
                case 1: Console.WriteLine("January"); break;
                case 2: Console.WriteLine("February"); break;
                case 3: Console.WriteLine("March"); break;
                default: Console.WriteLine("Other"); break;
            }

            //Answer:
            // Use switch when comparing one variable
            // against multiple fixed constant values.
            #endregion

            #region Problem 9
            int[] searchArr = { 9, 4, 6, 2, 4 };
            Array.Sort(searchArr);
            Console.WriteLine("Sorted: " + string.Join(",", searchArr));
            Console.WriteLine("IndexOf 4: " + Array.IndexOf(searchArr, 4));
            Console.WriteLine("LastIndexOf 4: " + Array.LastIndexOf(searchArr, 4));

            //Answer:
            // Time complexity of Array.Sort() is O(n log n).
            #endregion

            #region Problem 10
            int[] sumArr = { 1, 2, 3, 4, 5 };

            int sum1 = 0;
            for (int i = 0; i < sumArr.Length; i++)
                sum1 += sumArr[i];

            int sum2 = 0;
            foreach (var item in sumArr)
                sum2 += item;

            Console.WriteLine("Sum using for: " + sum1);
            Console.WriteLine("Sum using foreach: " + sum2);
            // Answer:
            // Performance difference is negligible.
            // for gives more control (index access).
            // foreach is cleaner and safer.
            #endregion

            //bounss
           /*default size(in .NET):
             Usually 1 MB per thread(can vary by environment).
           Stores:
             Value types
             Method calls
             Local variables
           Characteristics:
            Very fast allocation / deallocation
            Limited size
         Can cause StackOverflowException if too much recursion
        Considerations:
            Avoid deep or infinite recursion.
            Keep local variables lightweight.
            Large objects should not be allocated on the stack.
        Heap
            No fixed default size.    
           Grows dynamically based on available system memory.
           Stores:
           Reference types(objects, arrays, strings)
           Managed by Garbage Collector(GC).
           Considerations:
           Large objects increase GC pressure.
          Frequent allocations affect performance.
           Memory leaks may happen if references are not released.


           What is Time Complexity ?
           Time complexity measures how an algorithm’s execution time grows relative to input size(n)
           It describes performance using Big-O notation.
            Common examples:
            O(1) → Constant time
            O(n) → Linear time
            O(log n) → Logarithmic time
            O(n²) → Quadratic time
            Example:
            Accessing array element → O(1)
            Loop through array → O(n)
            Nested loops → O(n²)
            Time complexity helps you evaluate scalability and efficiency of code.*/

        }
    }
}
