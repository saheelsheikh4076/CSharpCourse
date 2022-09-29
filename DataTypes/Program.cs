using Advance1;
using Basics;

Console.WriteLine($"Pi value is {ConstantVariables.PI}");
ConstantVariables.PI = 3.142f;
Console.WriteLine($"Pi value is {ConstantVariables.PI}");
ConstantVariables c = new ConstantVariables();
//c.CollegeName = "hello";
Console.WriteLine(c.CollegeName);
Console.WriteLine(c.DepartmentName);
c.Test();
Console.WriteLine(c.GetTrustName());