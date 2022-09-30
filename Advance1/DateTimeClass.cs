using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance1
{
    public class DateTimeClass
    {
        public static void Test()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(DateTime.Now.AddDays(-1));
            Console.WriteLine(DateTime.Now.AddHours(-1));
            Console.WriteLine(new DateTime(2022,9,15));
            Console.WriteLine(new DateTime(2022,12,15,15,10,10));
        }
    }
}
