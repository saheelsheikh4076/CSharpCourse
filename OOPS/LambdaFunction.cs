namespace OOPS;
/// <summary>
/// Lambda function is an inline function mostly used in delegates 
/// </summary>
public class LambdaFunction
{
    public void Test()
    {
        Func<int> func1 = () => { return 0; };
        Func<int, int> func2 = (a) => { return a; };
    }
}
