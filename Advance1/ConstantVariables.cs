namespace Advance
{
    public class ConstantVariables
    {
        public static int Counter = 0;
        public static DateTime StartTime;
        public static DateTime StopTime;
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
        public const string TrustName = "Abc Trust";
        //Const Variables are accessible to the parent Class members only
        public void Test()
        {
            Console.WriteLine($"Pi value is {ConstantVariables.PI}");
            ConstantVariables.PI = 3.142f;
            Console.WriteLine($"Pi value is {ConstantVariables.PI}");
            ConstantVariables c = new ConstantVariables();
            //c.CollegeName = "hello";
            Console.WriteLine(c.CollegeName);
            Console.WriteLine(c.DepartmentName);
            c.Test();
            Console.WriteLine(c.GetTrustName());
            Console.WriteLine(TrustName);
        }
        public string GetTrustName()
        {
            return TrustName;
        }
    }
}
