using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics//Assembly Name
{
    public class AssignmentOperators
    {
        public void AssignmentOperator()
        {
            AssignmentOperators operators = new AssignmentOperators();
            Console.WriteLine($"Result of as it is {operators.AssignAsItIs(14)}");
            Console.WriteLine($"Result of Increment By One {operators.AssignAndIncrementByOne(142)}");
            Console.WriteLine($"Result of Increment {operators.AssignAndIncrement(140, 3)}");
            Console.WriteLine($"Result of Decrement {operators.AssignAndDecrement(156, 13)}");
            Console.WriteLine($"Result of Multiply {operators.AssignAndMultiply(11, 13)}");
            Console.WriteLine($"Result of Divide {operators.AssignAndDivideQ(286, 2)}");
            Console.WriteLine($"Result of Divide {operators.AssignAndDivideR(143, 243)}");
            Console.WriteLine($"Result of shiftLeft {operators.AssignAndShiftLeft(1, 1000)}");
            Console.WriteLine($"Result of ShiftRight {operators.AssignAndShiftRight(1, 0001)}");
            

        }
        public int AssignAsItIs(int a)
        {
            int b = a;
            return b;
        }
        public int AssignAndIncrementByOne(int a)
        {
            //a = a + 1;
            a += 1;
            return a;
        }
        public int AssignAndIncrement(int a, int b)
        {
            //a = a + b
            a += b;
            return a;
        }
        public int AssignAndDecrement(int a, int b)
        {
            //a = a - b
            a -= b;
            return a;
        }
        public int AssignAndMultiply(int a, int b)
        {
            ///a = a * b;
            ///
            a *= b;
            return a;
        }
        public int AssignAndDivideQ(int a, int b)
        {
            //a = a/b;
            a /= b;
            return a;
        }
        public int AssignAndDivideR(int a, int b)
        {
            //a = a % b
            a %= b;
            return a;
        }
        public int AssignAndShiftLeft(int a, int b)
        {
            ///2 will be 0010
            ///if shifted right by 1 it becomes 0001 i.e. 1
            ///if 2 (0010) is shifted left by 1 then it becomes 100 i.e. 4
            ///if 2 (0010) is shifted left by 2 then it becomes 1000 i.e. 8
            ///
            a <<= b;
            return a;
        }
        public int AssignAndShiftRight(int a, int b)
        {
            a >>= b;
            return a;
        }
    }
}
