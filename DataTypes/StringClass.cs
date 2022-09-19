using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class StringClass
    {
        public static void Test()
        {
            string s = "hello"+"world";
            Console.WriteLine("Hello {0}",s);
            Console.WriteLine($"Hello {s}");
            Console.WriteLine(s.Length);
            Console.WriteLine(s.IndexOf('o'));
            string[] splitresult = s.Split('w');
            string date = "19-9-2022";
            string[] datesplit = date.Split('-');
            string ss = date.Substring(5, 4);
            ss = date.Substring(date.LastIndexOf('-')+1, 4);
            string password = "   hello  world   ";
            string userInput = Console.ReadLine();
            Console.WriteLine(password.ToUpper() == userInput.ToUpper());//to make case insensitive
            Console.WriteLine($"[{password.Trim()}]");
        }
    }
}
