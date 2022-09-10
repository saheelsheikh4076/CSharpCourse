
//datatype.TryParse out keyword
//out keyword is part of Reference (Address), ref is also a keyword that holds reference


//tryParse
using System.Collections.Immutable;

string str = "2d";
//int i = Convert.ToInt32(str);
bool isSucceeded = Int32.TryParse(str, out int a);
Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {a}");

char c = 'A';
a = (int)c;
Console.WriteLine($"value is {a}");
isSucceeded = Int32.TryParse(c.ToString(), out a);
Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {a}");

isSucceeded = bool.TryParse("TRUEE", out bool result);
Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {result}");
isSucceeded = double.TryParse("2..33", out double resultDouble);
Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {resultDouble}");

try
{
    Console.WriteLine("enter any number to convert into int");
    a = Convert.ToInt32(Console.ReadLine());
    isSucceeded = true;
}
catch (Exception ex)
{
    isSucceeded = false;
    a = 0;
}
finally
{
    Console.WriteLine($"Is Succeeded : {isSucceeded}, and value is {a}");
}