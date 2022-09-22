using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance1
{
    internal class TestClass
    {
        public void Test()
        {
            AccessModifierClass c = new AccessModifierClass();
            c.PublicProperty = 10;
            c.InternalProperty = 10;
        }
    }
}
