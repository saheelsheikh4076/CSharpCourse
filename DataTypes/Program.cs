//Functions are now called as Methods
//The are set of instructions
//eg
// it has name "Add", on left is return type. and on RHS in bracket(parameters)
int Add(int a, int b)//here int is return type, and it has two parameters a & b (Arguments)
{
    int temp = a + b;
    return temp;
}
//int Add(int a, int b, int c)//Using Same Name of Functions, Function Overloading
//{
//    return a + b + c;
//}

int Mutiply(int a, int b)
{
    int temp = a * b;
    return temp;
}
void Print(string Message)
{
    Console.WriteLine(Message);
}
//Now calling function
Print("This is my first program. made by Irfan sir");
int result = Add(10, 20);
Console.WriteLine($"Result of Addition is {result}");
Console.WriteLine($"Result of Addition is {Add(1,2)}");//method 2 

