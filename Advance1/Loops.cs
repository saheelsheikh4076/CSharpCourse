namespace Advance1
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
