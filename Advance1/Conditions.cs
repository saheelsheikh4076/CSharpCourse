using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance
{
    public class Conditions
    {
        public void CompareString()
        {
            //Conditions are decisions based on boolean operations
            //Conditional operators are mostly used by If Else
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if(a == b)
            {
                Console.WriteLine("both strings are same");
            }
            else
            {
                Console.WriteLine("both strings are different");
            }
        }
        public static void SelectOptionByIf()
        {
            //Select options with if can be performed with If Else Ladder
            Console.WriteLine("Enter 1 or 2 or 3 or 4 or 5");
            int a = Convert.ToInt32(Console.ReadLine());
            if(a == 1)
            {
                Console.WriteLine("You entered 1");
            }
            else if (a == 2)
            {
                Console.WriteLine("You entered 2");
            }
            else if (a == 3)
            {
                 Console.WriteLine("You entered 3");

            }
            else if(a == 4)
            {
                Console.WriteLine("You entered 4");
            }
            else if(a == 5)
            {
                Console.WriteLine("You entered 5");
            }

            else
            {
                Console.WriteLine("You entered incorrect value");
            }
        }

        public void SelectOptionBySwitch()
        {
            Console.WriteLine("Enter 1 or 2 or 3 or 4");
            int a = Convert.ToInt32(Console.ReadLine());
            switch (a)
            {
                case 1: Console.WriteLine("You entered 1"); break;
                case 2: Console.WriteLine("You entered 2"); break;
                case 3: Console.WriteLine("You entered 3"); break;
                case 4: Console.WriteLine("You entered 4"); break;
                default: Console.WriteLine("You entered incorrect value");break;
            }
        }

        public static void ConditionByTernaryOperator()
        {
            int a = 10;
            int b = 11;
            Console.WriteLine(a == 10 ? "Yes" : "No");
            Console.WriteLine(a == 10 ? (b == 11? "yes ok":" yes not ok") : "no" );
        }
    }
}
