using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class PrivateConstructor
    {
        public void Test()
        {
            //TestClass t = new TestClass();
        }
        public class TestClass
        {
            private TestClass()
            {

            }
            public void Test1()
            {
                TestClass t = new TestClass();
            }
        }
    }
}
