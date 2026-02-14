using System;
using System.Text;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region problem 1
            Console.Write("Enter  number: ");
            string input = Console.ReadLine();
            try
            {
                int num1 = int.Parse(input);
                Console.WriteLine("int.Parse result: " + num1);
                int num2 = Convert.ToInt32(input);
                Console.WriteLine("Convert.ToInt32 result: " + num2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            /*
             Difference with null:
             * int.Parse(null) -> throws ArgumentNullException
             * Convert.ToInt32(null) -> returns 0
             */

            #endregion

            #region problem 2
            Console.Write("Enter a number: ");
            string tryInput = Console.ReadLine();
            if (int.TryParse(tryInput, out int result))
            {
                Console.WriteLine("Valid number: " + result);
            }
            else
            {
                Console.WriteLine("Invalid input, not a number.");
            }

            /*
              TryParse is recommended because:
             * - It does not throw exceptions
             * - Safer and faster for user input
             */
            #endregion

            #region problem3
            object obj;
            obj = 10;
            Console.WriteLine("int hash: " + obj.GetHashCode());
            obj = "Hello";
            Console.WriteLine("string hash: " + obj.GetHashCode());
            obj = 10.5;
            Console.WriteLine("double hash: " + obj.GetHashCode());

            /*
              GetHashCode purpose:
             * - Used in hash-based collections (Dictionary, HashSet)
             * - Helps in fast object lookup
             */
            #endregion

            #region problem4
            StringBuilder ref1 = new StringBuilder("Hello");
            StringBuilder ref2 = ref1;
            ref1.Append(" World");
            Console.WriteLine("ref1: " + ref1);
            Console.WriteLine("ref2: " + ref2);

            /*
             * Both references point to the same object in memory
             */
            #endregion

            #region problem5
            string s = "Hi";
            Console.WriteLine("Before hash: " + s.GetHashCode());
            s += " Willy";
            Console.WriteLine("After hash: " + s.GetHashCode());

            /*
             string is immutable:
             * - Any modification creates a new object
             * - Improves security and memory safety
             */
            #endregion

            #region problem6
            StringBuilder sb = new StringBuilder("Hi");
            Console.WriteLine("Before hash: " + sb.GetHashCode());
            sb.Append(" Willy");
            Console.WriteLine("After hash: " + sb.GetHashCode());

            /*
             * StringBuilder modifies the same object
             * Faster for large string changes
             */

            #endregion

            #region problem7
            Console.Write("Enter first number: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Concatenation: Sum is " + (a + b));
            Console.WriteLine(string.Format("Composite formatting: Sum is {0}", a + b));
            Console.WriteLine($"String interpolation: Sum is {a + b}");

            /*
             Most used: String Interpolation
             * - Cleaner
             * - Easier to read
             */
            #endregion

            #region problem8
            StringBuilder sb2 = new StringBuilder("Hello World");
            sb2.Append(" !!!");
            sb2.Replace("World", "C#");
            sb2.Insert(6, "Amazing ");
            sb2.Remove(0, 6);
            Console.WriteLine(sb2);

            /*
             StringBuilder is designed for:
             * - Frequent modifications
             * - Less memory allocation
             * - Better performance than string
             */
            #endregion

            #region ques2
            /*
                 * Enum (Enumeration):
                 * - A value type used to define a set of named constants.
                 * - Improves code readability and prevents invalid values.
                 *
                 * When is it used?
                 * - When a variable can take only a fixed set of values.
                 * - Example: Days, Status, Roles, Directions.
                 * Three common built-in enums:
                 * 1) DayOfWeek
                 * 2) ConsoleColor
                 * 3) StringComparison
                 */
            #endregion

            #region ques3
            /*
            * string:
            * - Immutable (cannot be changed).
            * - Any modification creates a new object.
            * - Best for small or fixed text.
        
             * StringBuilder:
             * - Mutable (can be changed).
             * - Modifies the same object in memory.
             * - Best for frequent or large text modifications.
             */
            #endregion

            #region ques5
            /*
                 * User-defined constructor:
                 * - A constructor created by the programmer.
                 * - Used to initialize object data when the object is created.
                 * - Has the same name as the class and no return type.
                 */
            #endregion

            #region ques6
            /*
                * Array:
                * - Fixed size.
                * - Fast access using index.
                * - Stored in contiguous memory.
                * - Slow insertion/deletion
                //int[] arr = { 1, 2, 3, 4 };
                 * Linked List:
                 * - Dynamic size.
                 * - Slow access (no index).
                 * - Nodes stored separately in memory.
                 * - Fast insertion/deletion.
                 */
            #endregion

        }
    }
}
