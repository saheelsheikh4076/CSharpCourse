namespace Basics
{
    public class NullableDataTypes
    {
        public static void Test()
        {
            //Valued Type variable/datatypes do not accept null
            int i = 0;//Valued Type
            //int j = null;//Non Nullable data type (does not accept null)
            int? k = null;
            float? f = null;
            bool? isPassed = null;
            bool? isMale = Convert.ToBoolean(null);
            Console.WriteLine(isMale);





            //All reference type variables or datatypes or class or struct or arrays or delegates
            //accept null value
            string str = null;
            NullableDataTypes nullable = null;
            AssignmentOperators assign = null;
        }
    }
}
