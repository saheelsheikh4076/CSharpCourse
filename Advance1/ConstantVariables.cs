using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance1
{
    public class ConstantVariables
    {
        public static float PI = 3.14f;//Static property, field, class, method, etc are
        //stored in Stack
        //One variable will serve all request
        public readonly string CollegeName;
        public readonly string DepartmentName = "ABCD Dept";
        //Readonly variables or properties cannot be set/changed
        //Two ways to set in readonly variables
        //1. direct assignment PI = 3.14
        //2. Through Constructor
        public ConstantVariables()
        {
            this.CollegeName = "The Institute";
            
        }
        //Const variable can be assigned by only one method (i.e. direct assignment)
        public const string TrustName="Abc Trust";
        //Const Variables are accessible to the parent Class members only
        public void Test()
        {
            Console.WriteLine(TrustName);
        }
        public string GetTrustName()
        {
            return TrustName;
        }
    }
}
