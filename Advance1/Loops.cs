﻿namespace Advance
{
    /// <summary>
    /// Loops
    /// 1. While        - 4%
    /// 2. Do While     - 1%
    /// 3. for loop     - 15%
    /// 4. foreach loop - 80%
    /// </summary>
    public class Loops
    {
        public void TestForEach()
        {
            List<int> rollNos = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            foreach (int rollNo in rollNos)
            {
                Console.WriteLine(rollNo);
            }
            int[] rollArray = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            foreach (var item in rollArray)
            {
                Console.WriteLine($"Roll No in Array {item}");
            }
            foreach (var item in "Hello world")
            {
                Console.WriteLine($"Character : {item}");
            }
        }
        public void TestForLoopOnString()
        {
            string str = "Hello world";
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine($"Character : {str[i]}");
            }
        }
        public static void WhileLoopWithBreakAndContinue()
        {
            //break keyword is used to stop the loop / iteration - stop
            //continue keyword is used to skip the current running iteration. skip and go ahead

            int i = 0;
            while (true)
            {
               i++;
                        if(i>10) { break; }
                i--;
                i = i + 2;
            }

            i = 0;
            while (true)
            {
                i++;
                    if(i%2 == 0) { continue; }
                Console.WriteLine(i);
                i--;
                i++;
                if (i > 100) { break; }
            }
        }
        public static void TestLoopOn1DArray()
        {
            int[] arr = new int[] { 1, 4, 5, 7, 8, 3, 4, 10 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Value at {i} is {arr[i]}");
            }
        }
        public static void TestLoopOn2DArray()
        {
            int[][] arr = new int[][]
            {
                new int[]{1,2,3,4 },
                new int[]{5,6,7,8 },
                new int[]{7,5,4,3}
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write($"{arr[i][j]} ");
                }
                Console.WriteLine("");
            }
        }
        public static void TestForLoop()
        {
            //for(initialization;condition check;operation (increment/decrement)
            int i = 0, j = 0;
            for (; i < 10;)
            {
                Console.WriteLine($"Value of i is {i++} & j is {j++}");
            }
        }
        public static void TestWhile()
        {
            //while loop
            //while (true)
            //{
            //    Console.WriteLine("Infinite loop");
            //}
            int i = 0;
            while (i <10 )
            {
                Console.WriteLine($"value is {i++}");
            }
        }
        public static void TestDoWhile()//UpperCamelCase lowerCamelCase (Pascal)
        {
            //Infinite loop using do while
            //do
            //{
            //    Console.WriteLine("Infinite loop");
            //}
            //while (true);

            int i = 0;
            do
            {
                Console.WriteLine($"Value is {i}");
                i++;
            }
            while (i < 10);

            //Special case: False condition will iterate once 
            do
            {
                Console.WriteLine("False condition");
            }
            while (false);
        }
    }
}
