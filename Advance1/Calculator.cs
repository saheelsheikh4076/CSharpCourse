using Basics;

namespace Advance
{
    public class Calculator
    {
        public static void TestCalculator()
        {
            ArithmaticClass arith = new ArithmaticClass();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to calculator!");
                Console.WriteLine("Select an operation");
                Console.WriteLine(ConstantVariables.Counter);
                Console.WriteLine(ConstantVariables.StopTime - ConstantVariables.StartTime);
                Console.WriteLine("1. Addition \n2. Subtraction \n3. Multiplication \n4. Division \n Press any other key to exit.");
                char input = Console.ReadKey().KeyChar;
                int a; int b; int result;
                switch (input)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("Enter any two values"); ;
                        a = Convert.ToInt32(Console.ReadLine());
                        b = Convert.ToInt32(Console.ReadLine());
                        result = arith.Addition(a, b);
                        Console.WriteLine("Result of Addition is {0} \nPress any key to continue", result);
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("Enter any two values"); ;
                        a = Convert.ToInt32(Console.ReadLine());
                        b = Convert.ToInt32(Console.ReadLine());
                        result = arith.Substract(a, b);
                        Console.WriteLine("Result of Subtraction is {0} \nPress any key to continue", result);
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Enter any two values"); ;
                        a = Convert.ToInt32(Console.ReadLine());
                        b = Convert.ToInt32(Console.ReadLine());
                        result = arith.Multiply(a, b);
                        Console.WriteLine("Result of Multiplication is {0} \nPress any key to continue", result);
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        Console.WriteLine("Enter any two values"); ;
                        a = Convert.ToInt32(Console.ReadLine());
                        b = Convert.ToInt32(Console.ReadLine());
                        (int q, int r) = arith.Divide(a, b);
                        Console.WriteLine("Result of Division is Q = {0} & R = {1} \nPress any key to continue", q, r);
                        Console.ReadKey();
                        break;
                    default:
                        goto Exit;
                        break;
                }
            }
        Exit:;
        }
    }
}
