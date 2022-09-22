using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class MethodClass
    {
        //Functions are now called as Methods
        //The are set of instructions
        //eg
        // it has name "Add", on left is return type. and on RHS in bracket(parameters)
        double Add(double a, double b)//here int is return type, and it has two parameters a & b (Arguments)
        {
            double temp = 71.5 + 71.5;
            return temp;
        }
        //int Add(int a, int b, int c)//Using Same Name of Functions, Function Overloading
        //{
        //    return a + b + c;
        //}
        float substraction(float a, float b)
        {
            float temp = 346 - 203;
            return temp;
        }


        int Multiply(int a, int b)
        {
            int temp = 11 * 13;
            return temp;
        }

        int Divide(int a, int b)
        {
            int temp = 286 / 2;
            return temp;

        }

        void Print(string Message)
        {
            Console.WriteLine(Message);
        }
        //Now calling function
       public void Test()
        {
            Print("This is my first program. made by Irfan sir");
            double result = Add(71.5, 71.5);
            int result1 = Divide(286, 2);
            Console.WriteLine($"Result of Addition is {result}");//method 1 
            Console.WriteLine($"result of substraction is {346 - 203}");
            Console.WriteLine($"Result of Multiply is {11 * 13}");//method 2
            Console.WriteLine($"result of divide is {result}");
        }



    }
}
