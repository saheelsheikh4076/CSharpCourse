using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance1
{
    public class Constructors
    {
        public int i { get; set; }
        private int j;
        //Following is the syntax of overridden parameterless constructor
        public Constructors()
        {
            //It is responsible to create an instance of class in Heap memory
        }
        public Constructors(int _i)
        {
           j = _i;
        }
    }
}
