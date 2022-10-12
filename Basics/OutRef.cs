using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics
{
    public class OutRef
    {
        public void TestRef()
        {
            //We call function by following two methods
            //Call by reference/Address
            //Call by Value
            int x = 0;
            AddRef(10,20, ref x);//Here ref variable must be initialized
            Console.WriteLine(x);
        }
        public void AddRef(int a, int b, ref int result)
        {
            //here ref pointer has no need to initialize
            result = result + a + b;
            result = a + b;
        }

        public void TestOut()
        {
            int x;
            AddOut(10,20,out x);//here out variable/pointer has no need to initialize
            AddOut(10, 20, out int y);
            Console.WriteLine($"X={x} and Y = {y}");
        }
        public void AddOut(int a, int b, out int result)
        {
            result = 0;//Initialization is compulsory before using
            result = result + a + b;
            result = a + b;
        }
    }
}
