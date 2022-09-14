using DataTypes;
internal class Program
{
    private static void Main(string[] args)
    {
        //To create a variabe of class type (OLD fashion)
        //or to create a class instance
        //or to create a class object
        //or to instantiate a class 
        //or to create a reference variable of a class
        ArithmaticClass arithmatic = new ArithmaticClass();
        Console.WriteLine(" --------->result of Addition <--------");
        int resultAdd = arithmatic.Addition(71, 72);
        int resultAdd1 = arithmatic.Addition(50, 45, 48);

        Console.WriteLine($"Result of addition is {resultAdd}");//string interpolation
        Console.WriteLine($"Result of Addition is {resultAdd}");//string interpolation
        Console.WriteLine($"Result of Addition is {arithmatic.Addition(45, 45, 45, 8)}");

        Console.WriteLine("-------->result of substract<---------");
        Console.WriteLine($"result of substract is {arithmatic.Substract(386, 243)}");  
        Console.WriteLine($"result of substract is {arithmatic.Substract(386, 223, 20)}");  
        Console.WriteLine($"result of substract is {arithmatic.Substract(526, 243, 80, 60 )}");

        Console.WriteLine("-------->result of multiplication<------");
        Console.WriteLine($"result of Multiply is {arithmatic.Multiply( 11 , 13)}");
        Console.WriteLine($"result of Multiply is {arithmatic.Multiply( 11 , 13, 1)}");
        Console.WriteLine($"result of Multiply is {arithmatic.Multiply( 5.5 , 2, 6.5, 2 )}");

        Console.WriteLine("------->result of division<------");

        (int q, int r) = arithmatic.Divide(286 ,2);
        Console.WriteLine($"result of division-> Remainder is {r} and Quotient is {q}");
        Console.WriteLine($"Result of Increment is {arithmatic.Increment(12)}");
        Console.WriteLine($"Result of Decrement is {arithmatic.Decrement(12)}");
        int a = 12;
        Console.WriteLine($"Value in a {a}");//12
        Console.WriteLine($"Value in a {a++}");//12->13
        Console.WriteLine($"Value in a {++a}");//14
        Console.WriteLine($"Value in a {--a}");//13
        Console.WriteLine($"Value in a {a--}");//13
    }
}