using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    /// <summary>
    /// Abstraction means showing the defination and hiding the implementation
    /// </summary>
    public abstract class Abstraction
    {
        //This class is an abstract class, and it may have an abstract method
        public abstract int AddNumbers(int a, int b);//Showing defination
        //defination does not know how it will be implemented

    }
    public abstract class Implementation : Abstraction
    {
       
    }
    public class Implementation1:Implementation
    {
        public override int AddNumbers(int a, int b)
        {
            return a + b;
        }
    }
}
