namespace Basics
{

    /// <summary>
    /// Logical Operators
    /// And (&), Or (|), Not (!)
    /// </summary>
    public class LogicalOperators
    {
        public void LogicalOperator()
        {
            LogicalOperators operators = new LogicalOperators();
            int a = 1, b = 1;
            Console.WriteLine($"And result {operators.And(a, b)}");
            Console.WriteLine($"Or result {operators.Or(a, b)}");
            Console.WriteLine($"boolean And result {operators.And(true, false)}");
            Console.WriteLine($"boolean Or result {operators.Or(true, false)}");
            Console.WriteLine($"boolean Not result {operators.Not(false)}");
            Console.WriteLine($"Complx  result {operators.ComplexLogicalComparasion(false, false)}");
        }
        public int And(int a, int b)
        {
            return a & b;
        }
        public int Or(int a, int b)
        {
            return a | b;
        }
        public bool And(bool a, bool b)
        {
            return (a && b);
        }
        public bool Or(bool a, bool b)
        {
            return (a || b);
        }
        public bool Not(bool a)
        {
            return !a;
        }
        public bool ComplexLogicalComparasion(bool a, bool b)
        {
            ///True False
            ///!(T && F) || !(T || F)
            ///!(F) || !(T)
            ///T || F
            ///T
            ///False False
            ///!(F&&F) || !(F||F)
            ///!(F) || !(F)
            ///T || T
            ///T


            return !(a && b) || !(a || b);
        }
    }
}
