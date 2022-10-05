using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class SealedClass
    {
        public void Test()
        {
            TestClass t = new TestClass();
            t.MyProperty = 23;
        }
        //If we want to block inheritance of a class then sealed keyword is used
        //It does not allow any class to get derived from sealed class
        public sealed class TestClass
        {
            public int MyProperty { get; set; }
            public int MyProperty1 { get; set; }
        }
        //public class TestClass1:TestClass
        //{

        //}
    }
}
