using DataTypes;
//To create a variabe of class type (OLD fashion)
//or to create a class instance
//or to create a class object
//or to instantiate a class 
//or to create a reference variable of a class
ArithmaticClass arithmatic = new ArithmaticClass();
int resultAdd = arithmatic.Addition(10, 20, 30);
int resultSubtract = arithmatic.Subtract(10, 20);

Console.WriteLine($"Result of addition is {resultAdd}");//string interpolation
Console.WriteLine($"Result of subtraction is {resultSubtract}");//string interpolation
Console.WriteLine($"Result of multiplication is {arithmatic.Multiply(10,20)}");
(int q, int r) = arithmatic.Divide(10, 3);
Console.WriteLine($"result of division-> Remainder is {r} and Quotient is {q}");
Console.WriteLine($"Result of Increment is {arithmatic.Increment(10)}");
Console.WriteLine($"Result of Decrement is {arithmatic.Decrement(10)}");
int a = 10;
Console.WriteLine($"Value in a {a}");//10
Console.WriteLine($"Value in a {a++}");//10->11
Console.WriteLine($"Value in a {++a}");//12
Console.WriteLine($"Value in a {--a}");//11
Console.WriteLine($"Value in a {a--}");//11