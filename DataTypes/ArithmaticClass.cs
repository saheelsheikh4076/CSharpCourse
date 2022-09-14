namespace DataTypes
{
    public class ArithmaticClass
    {
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
        public int Increment(int a)
        {
            return ++a;
        }
        public int Decrement(int a)
        {
            return --a;
        }
    }
}
