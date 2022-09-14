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
        AssignmentOperators operators = new AssignmentOperators();
        Console.WriteLine($"Result of as it is {operators.AssignAsItIs(14)}");
        Console.WriteLine($"Result of Increment By One {operators.AssignAndIncrementByOne(142)}");
        Console.WriteLine($"Result of Increment {operators.AssignAndIncrement(140,3)}");
        Console.WriteLine($"Result of Decrement {operators.AssignAndDecrement(156,13)}");
        Console.WriteLine($"Result of Multiply {operators.AssignAndMultiply(11,13)}");
        Console.WriteLine($"Result of Divide {operators.AssignAndDivideQ( 286 , 2)}");
        Console.WriteLine($"Result of Divide {operators.AssignAndDivideR( 143 , 243)}"); 
        Console.WriteLine($"Result of shiftLeft {operators.AssignAndShiftLeft(1, 1000)}"); 
        Console.WriteLine($"Result of ShiftRight {operators.AssignAndShiftRight(1, 0001)}"); 
    }
}