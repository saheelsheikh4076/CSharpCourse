namespace OOPS;
/// <summary>
/// Lambda function is an inline function mostly used in delegates 
/// </summary>
public class LambdaFunction
{
    public delegate void NullDelegate();
    public void Test()
    {
        NullDelegate n = () => Console.WriteLine("Null delegate invoked");
        n();

        Func<int> func1 = () => { return 0; };
        int resultInt = func1.Invoke();

        Func<string> strFunc = () => { return "Hello world"; };
        string resultString = strFunc.Invoke();

        Func<int, string> func2 = (a) =>
        {
            return "Hello";
        };
        string resultStr = func2.Invoke(10);

        Func<int, int, bool> func3 = (a, b) =>
        {

            return a > b;
        };
        bool resultBool = func3(10, 20);
        resultBool = func3.Invoke(10, 20);

        Action<int> act1 = (a) => Console.WriteLine(a);
        act1(10);
        Action<int, int, string> act2 = (a, b, result) =>
        {
            var length = result.Length;
            Console.WriteLine($"Length of string is {length}");
            int sum = a + b;
            Console.WriteLine("Sum is {0}",sum);
        };
        act2(20, 30, "Hello");


        //ANONYMOUS FUNCTION
        Action<int> act3 = delegate (int a)//Anonymous function using delegate keyword
        {
            Console.WriteLine(a);
        };
        Func<int,int> act4 = delegate (int a)//Anonymous function using delegate keyword
        {
            Console.WriteLine(a);
            return a;
        };
        Console.WriteLine($"result of act4 {act4(10)}");
    }


}
