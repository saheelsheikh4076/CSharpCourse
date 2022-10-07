namespace OOPS
{
    public class Overriding
    {
        public void Test()
        {
            //use virtual keyword for the function/property you want to override
            SourceClass s = new SourceClass();
            Console.WriteLine(s.Add(10, 20));
            Console.WriteLine(s.Substract(20, 10));
            AnotherClass a = new AnotherClass();
            Console.WriteLine(a.Add(10, 20));
            Console.WriteLine(a.Substract(20, 10));
        }
        public class SourceClass
        {
            public int Add(int a, int b)
            {
                return a + b;
            }
            public virtual int Substract(int a, int b)
            {
                return a - b;
            }
            protected virtual int Multiply(int a, int b)
            {
                return a * b;
            }
            internal virtual int Divide(int a, int b)
            {
                return a / b;
            }
            //private virtual int Quotient(int a, int b)//Virtual member cannot be private
            //{
            //    return a % b;
            //}
        }
        public class AnotherClass : SourceClass
        {
            public new int Add(int a, int b)//Hiding using new keyword
            {
                return Math.Abs(a) + Math.Abs(b);
            }
            public override int Substract(int a, int b)
            {
                return Math.Abs(a) - Math.Abs(b);
            }
            protected override int Multiply(int a, int b)
            {
                return base.Multiply(a, b);
            }
            internal override int Divide(int a, int b)
            {
                return base.Divide(a, b);
            }
            //public override int Substract(int a, int b)
            //{
            //    return base.Substract(a, b);
            //}
        }
    }
}
