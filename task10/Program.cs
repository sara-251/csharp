using System;
using System.Collections.Generic;
#region Models
public class Employee : ICloneable
{
    public string Name;
    public double Salary;
    public Employee(string n, double s) { Name = n; Salary = s; }
    public object Clone() { return new Employee(Name, Salary); }
}
public class Manager : Employee, IComparable<Manager>
{
    public Manager(string n, double s) : base(n, s) { }
    public int CompareTo(Manager other) { return Salary.CompareTo(other.Salary); }
}
#endregion
#region SortingClasses
public class SortingAlgorithm<T> where T : ICloneable
{
    public static void Sort(T[] arr, Comparison<T> comp)
    {
        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (comp(arr[i], arr[j]) > 0)
                { T temp = arr[i]; arr[i] = arr[j]; arr[j] = temp; }
    }
    public static T GetDefault() { return default(T); }
}
public class SortingTwo<T>
{
    public static void Sort(T[] arr, Comparison<T> comp)
    {
        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (comp(arr[i], arr[j]) > 0)
                { T temp = arr[i]; arr[i] = arr[j]; arr[j] = temp; }
    }
}
#endregion
class Program
{
    static void Main()
    {
        #region Problem1
        Employee[] e = { new Employee("Ali", 5000), new Employee("Sara", 4000) };
        SortingAlgorithm<Employee>.Sort(e, (a, b) => a.Salary.CompareTo(b.Salary));
        #endregion
        #region Question1
        string q1 = "Generic sorting is reusable,type safe,works with any data type and reduces code duplication.";
        #endregion
        #region Problem2
        int[] n1 = { 1, 4, 2, 9 };
        SortingTwo<int>.Sort(n1, (a, b) => b - a);
        #endregion
        #region Question2
        string q2 = "Lambda expressions make sorting shorter,clearer and allow dynamic comparison logic.";
        #endregion
        #region Problem3
        string[] words = { "apple", "kiwi", "banana" };
        SortingTwo<string>.Sort(words, (a, b) => a.Length.CompareTo(b.Length));
        #endregion
        #region Question3
        string q3 = "Dynamic comparer allows custom logic for different data types without rewriting sorting code.";
        #endregion
        #region Problem4
        Manager[] m = { new Manager("M1", 8000), new Manager("M2", 6000) };
        Array.Sort(m);
        #endregion
        #region Question4
        string q4 = "IComparable allows defining custom comparison logic inside the class itself.";
        #endregion
        #region Problem5
        Func<Employee, Employee, bool> compName = (a, b) => a.Name.Length > b.Name.Length;
        #endregion
        #region Question5
        string q5 = "Built in delegates like Func reduce custom delegate definitions and increase flexibility.";
        #endregion
        #region Problem6
        int[] n2 = { 5, 3, 1 };
        Array.Sort(n2, delegate (int a, int b) { return a - b; });
        Array.Sort(n2, (a, b) => a - b);
        #endregion
        #region Question6
        string q6 = "Lambda is shorter and more readable while anonymous delegate is older syntax.";
        #endregion
        #region Problem7
        int x = 1, y = 2;
        int temp = x; x = y; y = temp;
        #endregion
        #region Question7
        string q7 = "Generic methods allow utility functions to work with any data type safely.";
        #endregion
        #region Problem8
        SortingTwo<Employee>.Sort(e, (a, b) => { int r = a.Salary.CompareTo(b.Salary); return r != 0 ? r : a.Name.CompareTo(b.Name); });
        #endregion
        #region Question8
        string q8 = "Multi criteria sorting increases flexibility but requires careful comparison logic.";
        #endregion
        #region Problem9
        int d1 = SortingAlgorithm<int>.GetDefault();
        Employee d2 = SortingAlgorithm<Employee>.GetDefault();
        #endregion
        #region Question9
        string q9 = "default(T) returns zero for value types and null for reference types.";
        #endregion
        #region Problem10
        Employee[] clone = (Employee[])e.Clone();
        #endregion
        #region Question10
        string q10 = "Constraints ensure only valid types are used which increases type safety.";
        #endregion
        #region Problem11
        Func<string, string> upper = s => s.ToUpper();
        #endregion
        #region Question11
        string q11 = "Delegates support functional style and reusable transformation logic.";
        #endregion
        #region Problem12
        Func<int, int, int> add = (a, b) => a + b;
        int r1 = add(3, 4);
        #endregion
        #region Question12
        string q12 = "Delegates allow passing operations as parameters increasing reusability.";
        #endregion
        #region Problem13
        Func<int, string> toStr = i => i.ToString();
        #endregion
        #region Question13
        string q13 = "Generic delegates transform data between different types safely.";
        #endregion
        #region Problem14
        Func<int, int> square = n => n * n;
        #endregion
        #region Question14
        string q14 = "Func simplifies delegate creation without defining custom delegate type.";
        #endregion
        #region Problem15
        Action<string> print = s => Console.WriteLine(s);
        #endregion
        #region Question15
        string q15 = "Action is used when no return value is needed.";
        #endregion
        #region Problem16
        Predicate<int> even = n => n % 2 == 0;
        #endregion
        #region Question16
        string q16 = "Predicate improves clarity for boolean filtering conditions.";
        #endregion
        #region Problem17
        List<string> list = new List<string> { "one", "two" };
        var f = list.FindAll(delegate (string s) { return s.Contains("o"); });
        #endregion
        #region Question17
        string q17 = "Anonymous functions allow quick inline customization.";
        #endregion
        #region Problem18
        Func<int, int, int> mul = delegate (int a, int b) { return a * b; };
        #endregion
        #region Question18
        string q18 = "Anonymous functions are preferred for short one time operations.";
        #endregion
        #region Problem19
        var f2 = list.FindAll(s => s.Length > 3);
        #endregion
        #region Question19
        string q19 = "Lambda expressions are concise and essential in LINQ and modern C#.";
        #endregion
        #region Problem20
        Func<double, double, double> div = (a, b) => a / b;
        double r2 = div(10, 2);
        #endregion
        #region Question20
        string q20 = "Lambda expressions make mathematical expressions shorter and more expressive.";
        #endregion

        //part2 
        #region ParallelProgrammingAndConcurrency
        /*Parallel Programming is executing multiple tasks at the same time to improve performance using multiple CPU cores.
        Concurrency is managing multiple tasks that progress independently but not necessarily simultaneously.
        In C# parallel programming can be implemented using Task Parallel Library (TPL), Parallel.For, Parallel.ForEach and Threads
        Concurrency focuses on coordination between tasks, handling shared resources and avoiding race conditions.
        Common issues include deadlock, race condition and thread starvation.
        Parallelism improves speed for CPU bound operations while concurrency improves responsiveness.*/
        #endregion

        #region UnitTestingAndTDD
        /*Unit Testing is testing small independent units of code like methods or classes.
        It ensures each unit works correctly in isolation.
        Popular frameworks in C# include MSTest, NUnit and xUnit.
        Test Driven Development TDD is a development approach where tests are written before the actual code.
        TDD cycle is Red write failing test, Green write code to pass test, Refactor improve code.
        Benefits include better design, fewer bugs and easier maintenance.*/
        #endregion

        #region AsynchronousProgrammingAsyncAwait
        /*Asynchronous Programming allows non blocking operations so the application remains responsive
        In C# async and await keywords simplify asynchronous code.
        The async keyword is used before a method to indicate it contains asynchronous operations.
        The await keyword pauses execution until the awaited task completes without blocking the thread.
        Async programming is useful for IO bound operations like file access, database calls and web requests.
        It improves scalability and responsiveness especially in web and UI applications.*/
        #endregion

        //part3
        #region AsynchronousProgramming
        /*Asynchronous programming is a programming approach that allows tasks to run without blocking the main thread of execution.
        It is mainly used to handle long running operations such as file access, database queries, and web requests without freezing the application.
        Instead of waiting for an operation to finish, the program continues executing other tasks and handles the result when it becomes available.
        In C#, asynchronous programming is implemented using async and await keywords along with the Task class.
        It improves application responsiveness especially in UI and web applications.
        It increases scalability by allowing better resource utilization.
        Asynchronous programming helps build efficient, responsive and scalable applications.*/

        #endregion
    }
}using System;
using System.Collections.Generic;
#region Models
public class Employee : ICloneable
{
    public string Name;
    public double Salary;
    public Employee(string n, double s) { Name = n; Salary = s; }
    public object Clone() { return new Employee(Name, Salary); }
}
public class Manager : Employee, IComparable<Manager>
{
    public Manager(string n, double s) : base(n, s) { }
    public int CompareTo(Manager other) { return Salary.CompareTo(other.Salary); }
}
#endregion
#region SortingClasses
public class SortingAlgorithm<T> where T : ICloneable
{
    public static void Sort(T[] arr, Comparison<T> comp)
    {
        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (comp(arr[i], arr[j]) > 0)
                { T temp = arr[i]; arr[i] = arr[j]; arr[j] = temp; }
    }
    public static T GetDefault() { return default(T); }
}
public class SortingTwo<T>
{
    public static void Sort(T[] arr, Comparison<T> comp)
    {
        for (int i = 0; i < arr.Length; i++)
            for (int j = i + 1; j < arr.Length; j++)
                if (comp(arr[i], arr[j]) > 0)
                { T temp = arr[i]; arr[i] = arr[j]; arr[j] = temp; }
    }
}
#endregion
class Program
{
    static void Main()
    {
        #region Problem1
        Employee[] e = { new Employee("Ali", 5000), new Employee("Sara", 4000) };
        SortingAlgorithm<Employee>.Sort(e, (a, b) => a.Salary.CompareTo(b.Salary));
        #endregion
        #region Question1
        string q1 = "Generic sorting is reusable,type safe,works with any data type and reduces code duplication.";
        #endregion
        #region Problem2
        int[] n1 = { 1, 4, 2, 9 };
        SortingTwo<int>.Sort(n1, (a, b) => b - a);
        #endregion
        #region Question2
        string q2 = "Lambda expressions make sorting shorter,clearer and allow dynamic comparison logic.";
        #endregion
        #region Problem3
        string[] words = { "apple", "kiwi", "banana" };
        SortingTwo<string>.Sort(words, (a, b) => a.Length.CompareTo(b.Length));
        #endregion
        #region Question3
        string q3 = "Dynamic comparer allows custom logic for different data types without rewriting sorting code.";
        #endregion
        #region Problem4
        Manager[] m = { new Manager("M1", 8000), new Manager("M2", 6000) };
        Array.Sort(m);
        #endregion
        #region Question4
        string q4 = "IComparable allows defining custom comparison logic inside the class itself.";
        #endregion
        #region Problem5
        Func<Employee, Employee, bool> compName = (a, b) => a.Name.Length > b.Name.Length;
        #endregion
        #region Question5
        string q5 = "Built in delegates like Func reduce custom delegate definitions and increase flexibility.";
        #endregion
        #region Problem6
        int[] n2 = { 5, 3, 1 };
        Array.Sort(n2, delegate (int a, int b) { return a - b; });
        Array.Sort(n2, (a, b) => a - b);
        #endregion
        #region Question6
        string q6 = "Lambda is shorter and more readable while anonymous delegate is older syntax.";
        #endregion
        #region Problem7
        int x = 1, y = 2;
        int temp = x; x = y; y = temp;
        #endregion
        #region Question7
        string q7 = "Generic methods allow utility functions to work with any data type safely.";
        #endregion
        #region Problem8
        SortingTwo<Employee>.Sort(e, (a, b) => { int r = a.Salary.CompareTo(b.Salary); return r != 0 ? r : a.Name.CompareTo(b.Name); });
        #endregion
        #region Question8
        string q8 = "Multi criteria sorting increases flexibility but requires careful comparison logic.";
        #endregion
        #region Problem9
        int d1 = SortingAlgorithm<int>.GetDefault();
        Employee d2 = SortingAlgorithm<Employee>.GetDefault();
        #endregion
        #region Question9
        string q9 = "default(T) returns zero for value types and null for reference types.";
        #endregion
        #region Problem10
        Employee[] clone = (Employee[])e.Clone();
        #endregion
        #region Question10
        string q10 = "Constraints ensure only valid types are used which increases type safety.";
        #endregion
        #region Problem11
        Func<string, string> upper = s => s.ToUpper();
        #endregion
        #region Question11
        string q11 = "Delegates support functional style and reusable transformation logic.";
        #endregion
        #region Problem12
        Func<int, int, int> add = (a, b) => a + b;
        int r1 = add(3, 4);
        #endregion
        #region Question12
        string q12 = "Delegates allow passing operations as parameters increasing reusability.";
        #endregion
        #region Problem13
        Func<int, string> toStr = i => i.ToString();
        #endregion
        #region Question13
        string q13 = "Generic delegates transform data between different types safely.";
        #endregion
        #region Problem14
        Func<int, int> square = n => n * n;
        #endregion
        #region Question14
        string q14 = "Func simplifies delegate creation without defining custom delegate type.";
        #endregion
        #region Problem15
        Action<string> print = s => Console.WriteLine(s);
        #endregion
        #region Question15
        string q15 = "Action is used when no return value is needed.";
        #endregion
        #region Problem16
        Predicate<int> even = n => n % 2 == 0;
        #endregion
        #region Question16
        string q16 = "Predicate improves clarity for boolean filtering conditions.";
        #endregion
        #region Problem17
        List<string> list = new List<string> { "one", "two" };
        var f = list.FindAll(delegate (string s) { return s.Contains("o"); });
        #endregion
        #region Question17
        string q17 = "Anonymous functions allow quick inline customization.";
        #endregion
        #region Problem18
        Func<int, int, int> mul = delegate (int a, int b) { return a * b; };
        #endregion
        #region Question18
        string q18 = "Anonymous functions are preferred for short one time operations.";
        #endregion
        #region Problem19
        var f2 = list.FindAll(s => s.Length > 3);
        #endregion
        #region Question19
        string q19 = "Lambda expressions are concise and essential in LINQ and modern C#.";
        #endregion
        #region Problem20
        Func<double, double, double> div = (a, b) => a / b;
        double r2 = div(10, 2);
        #endregion
        #region Question20
        string q20 = "Lambda expressions make mathematical expressions shorter and more expressive.";
        #endregion

        //part2 
        #region ParallelProgrammingAndConcurrency
        /*Parallel Programming is executing multiple tasks at the same time to improve performance using multiple CPU cores.
        Concurrency is managing multiple tasks that progress independently but not necessarily simultaneously.
        In C# parallel programming can be implemented using Task Parallel Library (TPL), Parallel.For, Parallel.ForEach and Threads
        Concurrency focuses on coordination between tasks, handling shared resources and avoiding race conditions.
        Common issues include deadlock, race condition and thread starvation.
        Parallelism improves speed for CPU bound operations while concurrency improves responsiveness.*/
        #endregion

        #region UnitTestingAndTDD
        /*Unit Testing is testing small independent units of code like methods or classes.
        It ensures each unit works correctly in isolation.
        Popular frameworks in C# include MSTest, NUnit and xUnit.
        Test Driven Development TDD is a development approach where tests are written before the actual code.
        TDD cycle is Red write failing test, Green write code to pass test, Refactor improve code.
        Benefits include better design, fewer bugs and easier maintenance.*/
        #endregion

        #region AsynchronousProgrammingAsyncAwait
        /*Asynchronous Programming allows non blocking operations so the application remains responsive
        In C# async and await keywords simplify asynchronous code.
        The async keyword is used before a method to indicate it contains asynchronous operations.
        The await keyword pauses execution until the awaited task completes without blocking the thread.
        Async programming is useful for IO bound operations like file access, database calls and web requests.
        It improves scalability and responsiveness especially in web and UI applications.*/
        #endregion

        //part3
        #region AsynchronousProgramming
        /*Asynchronous programming is a programming approach that allows tasks to run without blocking the main thread of execution.
        It is mainly used to handle long running operations such as file access, database queries, and web requests without freezing the application.
        Instead of waiting for an operation to finish, the program continues executing other tasks and handles the result when it becomes available.
        In C#, asynchronous programming is implemented using async and await keywords along with the Task class.
        It improves application responsiveness especially in UI and web applications.
        It increases scalability by allowing better resource utilization.
        Asynchronous programming helps build efficient, responsive and scalable applications.*/

        #endregion
    }
}