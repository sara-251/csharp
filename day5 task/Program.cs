using System;

class Program
{
    static void Main()
    {
        #region Problem 1
        try
        {
            Console.Write("Enter first integer: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Result: " + (a / b));
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Cannot divide by zero.");
        }
        finally
        {
            Console.WriteLine("Operation complete");
        }
        // Answer: finally ensures that a block of code executes regardless of success or exception.
        #endregion

        #region Problem 2
        int x, y;
        Console.Write("Enter positive integer X: ");
        while (!int.TryParse(Console.ReadLine(), out x) || x <= 0) { }
        Console.Write("Enter positive integer Y > 1: ");
        while (!int.TryParse(Console.ReadLine(), out y) || y <= 1) { }
        Console.WriteLine($"X={x}, Y={y}");
        // Answer: TryParse avoids exceptions on invalid input and returns a boolean indicating success.
        #endregion

        #region Problem 3
        int? n = null;
        int val = n ?? 10;
        Console.WriteLine("Nullable value: " + val);
        if (n.HasValue)
            Console.WriteLine("Has Value: " + n.Value);
        else
            Console.WriteLine("n is null");
        // Answer: InvalidOperationException
        #endregion

        #region Problem 4
        int[] arr1D = new int[5];
        try
        {
            arr1D[10] = 5;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Index out of bounds.");
        }
        // Answer: To prevent IndexOutOfRangeException and access only valid memory locations.
        #endregion

        #region Problem 5
        int[,] matrix = new int[3, 3];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
            {
                Console.Write($"Enter [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        for (int i = 0; i < 3; i++)
        {
            int sumRow = 0, sumCol = 0;
            for (int j = 0; j < 3; j++)
            {
                sumRow += matrix[i, j];
                sumCol += matrix[j, i];
            }
            Console.WriteLine($"Row {i} sum: {sumRow}, Column {i} sum: {sumCol}");
        }
        // Answer: It returns the size of the specified dimension of the array.
        #endregion

        #region Problem 6
        int[][] jagged = new int[3][];
        jagged[0] = new int[2];
        jagged[1] = new int[3];
        jagged[2] = new int[1];
        for (int i = 0; i < 3; i++)
            for (int j = 0; j < jagged[i].Length; j++)
            {
                Console.Write($"Enter [{i}][{j}]: ");
                jagged[i][j] = int.Parse(Console.ReadLine());
            }
        for (int i = 0; i < 3; i++)
        {
            foreach (var valRow in jagged[i])
                Console.Write(valRow + " ");
            Console.WriteLine();
        }
        // Answer: Jagged arrays allocate each row separately; rectangular arrays allocate a contiguous block.
        #endregion

        #region Problem 7
        string? s = null;
        Console.Write("Enter value: ");
        string? input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
            s = input;
        Console.WriteLine("Nullable string value: " + s!);
        // Answer: To allow reference variables to be null and help the compiler warn about potential NullReferenceExceptions.
        #endregion

        #region Problem 8
        int xBox = 10;
        object o = xBox;
        try
        {
            int yBox = (int)o;
            Console.WriteLine("Unboxed: " + yBox);
            string sBox = (string)o;
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Invalid cast.");
        }
        // Answer: Boxing/unboxing adds overhead due to heap allocation and type conversion.
        #endregion

        #region Problem 9
        void SumAndMultiply(int a1, int b1, out int sum, out int prod)
        {
            sum = a1 + b1;
            prod = a1 * b1;
        }
        SumAndMultiply(3, 4, out int s1, out int p1);
        Console.WriteLine($"Sum={s1}, Product={p1}");
        // Answer: Because they are not initialized before method call and must be assigned a value to return to caller.
        #endregion

        #region Problem 10
        void PrintString(string str, int count = 5)
        {
            for (int i = 0; i < count; i++)
                Console.WriteLine(str);
        }
        PrintString("Hello", count: 3);
        PrintString("World");
        // Answer: To avoid ambiguity when calling the method with positional arguments.
        #endregion

        #region Problem 11
        int[]? arrNullable = null;
        Console.WriteLine("Nullable array length: " + arrNullable?.Length);
        // Answer: It returns null instead of throwing an exception when the object is null.
        #endregion

        #region Problem 12
        Console.Write("Enter day: ");
        string day = Console.ReadLine()!;
        int dayNum = day.ToLower() switch
        {
            "monday" => 1,
            "tuesday" => 2,
            "wednesday" => 3,
            "thursday" => 4,
            "friday" => 5,
            "saturday" => 6,
            "sunday" => 7,
            _ => 0
        };
        Console.WriteLine("Day number: " + dayNum);
        // Answer: When mapping values directly to results; it is more concise and readable.
        #endregion

        #region Problem 13
        int SumArray(params int[] numbers)
        {
            int sumArr = 0;
            foreach (int nVal in numbers)
                sumArr += nVal;
            return sumArr;
        }
        int[] arrToSum = { 1, 2, 3 };
        Console.WriteLine("Sum array: " + SumArray(arrToSum));
        Console.WriteLine("Sum individual: " + SumArray(4, 5, 6));
        // Answer: Only one params array is allowed and it must be the last parameter.
        #endregion

        ////part 222
        #region Print Numbers in a Range
        Console.Write("Enter a positive integer: ");
        int n1 = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n1; i++)
        {
            Console.Write(i);
            if (i != n1) Console.Write(", ");
        }
        Console.WriteLine();
        #endregion

        #region Display Multiplication Table
        Console.Write("Enter a number for multiplication table: ");
        int n2 = int.Parse(Console.ReadLine());
        for (int i = 1; i <= 12; i++)
        {
            Console.Write(n2 * i);
            if (i != 12) Console.Write(", ");
        }
        Console.WriteLine();
        #endregion

        #region List Even Numbers
        Console.Write("Enter a number to list even numbers: ");
        int n3 = int.Parse(Console.ReadLine());
        for (int i = 2; i <= n3; i += 2)
        {
            Console.Write(i);
            if (i + 2 <= n3) Console.Write(", ");
        }
        Console.WriteLine();
        #endregion

        #region Compute Exponentiation
        Console.Write("Enter base number: ");
        int baseNum = int.Parse(Console.ReadLine());
        Console.Write("Enter exponent: ");
        int exp = int.Parse(Console.ReadLine());
        int result = 1;
        for (int i = 1; i <= exp; i++)
            result *= baseNum;
        Console.WriteLine(result);
        #endregion

        #region Reverse a Text String
        Console.Write("Enter a string to reverse: ");
        string text = Console.ReadLine();
        char[] charArray = text.ToCharArray();
        Array.Reverse(charArray);
        Console.WriteLine(new string(charArray));
        #endregion

        #region Reverse an Integer Value
        Console.Write("Enter an integer to reverse: ");
        string intText = Console.ReadLine();
        char[] intArray = intText.ToCharArray();
        Array.Reverse(intArray);
        Console.WriteLine(new string(intArray));
        #endregion

        #region Find Longest Distance Between Matching Elements
        Console.Write("Enter array size: ");
        int size = int.Parse(Console.ReadLine());
        int[] arr = new int[size];
        Console.WriteLine("Enter array elements separated by space:");
        arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int maxDistance = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    int distance = j - i - 1;
                    if (distance > maxDistance)
                        maxDistance = distance;
                }
            }
        }
        Console.WriteLine("Longest distance between matching elements: " + maxDistance);
        #endregion

        #region Reverse Words in a Sentence
        Console.Write("Enter a sentence: ");
        string sentence = Console.ReadLine();
        string[] words = sentence.Split(' ');
        Array.Reverse(words);
        Console.WriteLine(string.Join(" ", words));
        #endregion

    }

}
