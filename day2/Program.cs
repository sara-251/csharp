using System;
using System.Security.Principal;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace day1
{

    class Point
    {
        public int x;
        public int y;
    }
    class Program
    {
        static void Main(string[] args)
        {
            #region problem 1
            int x1 = 10; // declare var x and assign value = 10
            int y1 = 20; // declare var y and assign value = 20
            /*
             calculate the sum of both x and y
             and store it in var sum
            */
            int sum = x1 + y1;
            Console.WriteLine(sum); // print the sum

            /*
             shortcut to comment ==>> Ctrl+K, Ctrl+C
             shortcut to uncomment ==>> Ctrl+K, Ctrl+U
            */
            #endregion

            #region problem 2
            //int x = "10"; type error ==>slove it by assign var inter value instead of string
            int x = 10;
            int y = 5; // doesnot declareeee 
            //console.WriteLine(x + y); ==?sensetivee c small 
            Console.WriteLine(x + y);
            /*
             runtime error==>>>happens while the program is running,,Uusually stops the program 
             ex::int a = 5;
                 int b = 0;
                 int c = a / b;   ///division by zeroo

            logical error==>>>output is wrongg
            ex::int x = 5;
                int y = 3;
                int sum = x - y; //sum or subtract!
             */
            #endregion

            #region problem 3
            string full_Name = "Sara Mahmoud"; // store full name
            int age = 20;                     // store age
            decimal Salary = 10000.50m; // store salary
            bool isStudent = true;

            /*
             Why is it important to follow naming conventions such as PascalCase in C#?
             *makes code easier to read and understand
             *help differentiate between variables,methods,and classes
             */
            #endregion

            #region problem 4
            Point p1;
            p1 = new Point();
            Point p2 = new Point();
            p2 = p1;
            Console.WriteLine(p1.x);
            p1.x = 25;
            Console.WriteLine(p2.x);
            /*
            Value Types: Each variable has its own copy,, Memory allocated on stack.
            Reference Types: Variable stores a reference to the object on heap.Multiple variables can point to the same object, so changes via one reference affect all.
            */
            #endregion

            #region problem 5
            int x2 = 15;
            int y2 = 4;
            int summ = x2 + y2;
            int difference = x2 - y2;
            int product = x2 * y2;
            double division = (double)x2 / y2;
            int remainder = x2 % y2;

            Console.WriteLine($"sum::{sum}");
            Console.WriteLine($"difference::{difference}");
            Console.WriteLine($"product::{product}");
            Console.WriteLine($"division::{division}");
            Console.WriteLine($"remainder::{remainder}");
            /*
             int a = 2, b = 7;
             Console.WriteLine(a % b);
            output=2 ==>>>The %  is the modulus operator, which gives the remainder after division.
                         7 cannot go into 2 even once → integer division result = 0
                         Remainder = 2 − (0 × 7) = 2
             */
            #endregion

            #region problem 6
            int number = 16;
            if (number > 10 && number % 2 == 0)
            {
                Console.WriteLine($"{number} is greater than 10 and even.");
            }
            else
            {
                Console.WriteLine($"{number} does not satisfy both conditions.");
            }

            // How does && differ from &?
            /*
             - && is the logical AND operator: evaluates left to right, stops if first condition is false.
             - & is the bitwise AND operator (or logical AND if applied on bools) and evaluates both sides always.
            */
            #endregion

            #region problem 7
            double val = 9.75;
            int intValue = (int)val; // explicit 
            Console.WriteLine($"Explicit cast: {intValue}");

            // Implicit casting example (int to double)
            int intValue2 = 5;
            double doubleValue2 = intValue2; // implicit 
            Console.WriteLine($"Implicit cast: {doubleValue2}");

            //Why explicit casting required?
            /*
             - Because converting double to int can lose fractional data.
             - Compiler requires explicit cast to indicate potential data loss.
            */
            #endregion

            #region problem 8
            Console.Write("Enter your age: ");
            string age2 = Console.ReadLine();
            try
            {
                int agee = int.Parse(age2);

                if (agee > 0)
                {
                    Console.WriteLine($"Your age is: {agee}");
                }
                else
                {
                    Console.WriteLine("Age must be greater than 0.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid integer.");
            }

            // Question: What exception might occur?
            /*
             - FormatException occurs if input cannot be parsed to an integer.
             - Can handle it using try-catch.
            */

            #endregion

            #region problem 9

            int x5 = 5;
            int y5 = ++x5 + x5++;
            Console.WriteLine($"x = {x5}, y = {y5}"); // x=7, y=12

            /*
             - Prefix (++x) increments before using the value.
             - Postfix (x++) uses the value first, then increments.
            */
            #endregion

            /*
              2. Compiled vs Interpreted & C#
               - Compiled: translates code to machine code before running (C, C++).
               - Interpreted: executes code line by line at runtime (Python, JS).
               - C#: hybrid → compiled to IL, then JIT by CLR at runtime.
            */

            /*
            3. Implicit, Explicit, Convert, Parse
            - Implicit: automatic, no data loss (int → double)
            - Explicit: manual, may lose data ((int)double)
            - Convert: safe type conversion, may throw exception
            - Parse: string to type, throws exception if format invalid
            */

            /*
            5. C# is Managed Code
            - Runs under CLR
            - CLR handles memory (GC), type safety, exceptions
            - No manual memory management needed
            */

            /*
            6. Struct vs Class
            - Struct: value type, stored on stack, passed by value
            - Class: reference type, stored on heap, passed by reference
            - Struct can have methods, fields, properties like class
            - Use struct for small, lightweight objects
            */
        }
    }
}
