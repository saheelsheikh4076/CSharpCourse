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
        Console.WriteLine($"Result {operators.AssignAndShiftLeft(2,3)}");
    }
}