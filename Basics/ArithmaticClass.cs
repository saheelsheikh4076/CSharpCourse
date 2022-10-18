namespace Basics
{
    public class ArithmaticClass
    {
        public class AddClass
        {
            public int Result { get; set; }
            public AddClass(int a, int b)
            {
                Result = a + b;
            }
            public AddClass(int a, int b, int c)
            {
                Result = a + b + c;
            }
        }
        public void Test()
        {
            AddClass a = new AddClass(20, 22);
            Console.WriteLine(a.Result);
            AddClass a1 = new AddClass(20, 22, 24);
            Console.WriteLine(a1.Result);
            //To create a variabe of class type (OLD fashion)
            //or to create a class instance
            //or to create a class object
            //or to instantiate a class 
            //or to create a reference variable of a class

            ArithmaticClass arithmatic = new ArithmaticClass();
            Console.WriteLine(" --------->result of Addition <--------");
            int resultAdd = arithmatic.Addition(71, 72);
            Addition(71, 72);
            int resultAdd1 = arithmatic.Addition(50, 45, 48);

            Console.WriteLine($"Result of addition is {resultAdd}");//string interpolation
            Console.WriteLine($"Result of Addition is {resultAdd1}");//string interpolation
            Console.WriteLine($"Result of Addition is {arithmatic.Addition(45, 45, 45, 8)}");

            Console.WriteLine("-------->result of substract<---------");
            Console.WriteLine($"result of substract is {arithmatic.Substract(386, 243)}");
            Console.WriteLine($"result of substract is {arithmatic.Substract(386, 223, 20)}");
            Console.WriteLine($"result of substract is {arithmatic.Substract(526, 243, 80, 60)}");

            Console.WriteLine("-------->result of multiplication<------");
            Console.WriteLine($"result of Multiply is {arithmatic.Multiply(11, 13)}");
            Console.WriteLine($"result of Multiply is {arithmatic.Multiply(11, 13, 1)}");
            Console.WriteLine($"result of Multiply is {arithmatic.Multiply(5.5, 2, 6.5, 2)}");

            Console.WriteLine("------->result of division<------");

            (int q, int r) = arithmatic.Divide(286, 2);
            Console.WriteLine($"result of division-> Remainder is {r} and Quotient is {q}");
            Console.WriteLine($"Result of Increment is {arithmatic.Increment(12)}");
            Console.WriteLine($"Result of Decrement is {arithmatic.Decrement(12)}");
            int i= 12;
            Console.WriteLine($"Value in a {i}");//12
            Console.WriteLine($"Value in a {i++}");//12->13
            Console.WriteLine($"Value in a {++i}");//14
            Console.WriteLine($"Value in a {--i}");//13
            Console.WriteLine($"Value in a {i--}");//13
        }
        /// <summary>
        /// Arithmatic Operators
        /// +,-, * , /, %, A++, ++A, A--, --A
        /// </summary>
      /// Using same name for multiple methods represent Method overloading
        public int Addition(int a, int b)//Class member
        {
            return a + b;
        }
        public int Addition(int a, int b, int c)
        {
            return a + b + c;
        }public int Addition(int a, int b, int c, int d)
        {
            return a + b + c + d;
        }
        public int Substract(int a, int b)
        {
            return a - b;
        }
        public int Substract(int a, int b, int c)
        {
            return a - b - c;
        }
        public int Substract(int a, int b , int c, int d)
        {
            return a - b - c - d;
        }
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        public int Multiply(int a, int b, int c)
        {
            return a * b * c;
        }
        public double Multiply(double a, double b, double c, double d)
        {
            return a * b * c * d;
        }
        
        public (int Q, int R) Divide(int a, int b)
        {
            int q = a / b;
            int r = a % b;
            return (q, r);
        }
        public int Increment(int i)
        {
            return ++i;
        }
        public int Decrement(int i)
        {
            return --i;
        }
    }
}
