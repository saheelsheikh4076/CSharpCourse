using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    internal class TryParseClass
    {
        public void Test()
        {

            //datatype.TryParse out keyword
            //out keyword is part of Reference (Address), ref is also a keyword that holds reference


            //tryParse

            string str = "2d";
            //int i = Convert.ToInt32(str);
            bool isSucceeded = Int32.TryParse(str, out int a);
            Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {a}");

            char c = 'A';
            a = (int)c;
            Console.WriteLine($"value is {a}");
            isSucceeded = Int32.TryParse(c.ToString(), out a);
            Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {a}");

            isSucceeded = bool.TryParse("TRUEE", out bool result);
            Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {result}");
            isSucceeded = double.TryParse("2..33", out double resultDouble);
            Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {resultDouble}");

            try//try if it executes without error (exception)
            {
                Console.WriteLine("enter any number to convert into int");
                a = Convert.ToInt32(Console.ReadLine());
                isSucceeded = true;
            }//If it is throwing error then catch it in following block
            catch (Exception ex)//ex.Message will show the reason of error
            {
                isSucceeded = false;
                a = 0;
            }
            finally//Finally block will execute in both cases (error or not)
            {
                Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {a}");
            }

            double i;
            string s = "1.1";
            isSucceeded = double.TryParse(s, out i);
            Console.WriteLine($"Is succeeded {isSucceeded} and the result is {i}");
        }
    }
}
