using Advance1;
using Basics;


Constructors c;//It just assigns a label for that class i.e a pointer is declared without address
//A reference variable without reference is created.

Constructors c2 = new Constructors();//new keyword calls the constructor. new <constructor>
ArithmaticClass a = new ArithmaticClass();// constructor has (), it has name same as class name
//constructor lies within the class
//if you do not see any constructor within class then it is hidden
//by default a parameterless constructor is always present and is hidden
//we can override the hidden constructor by creating our own constructor

c = new Constructors();
Constructors c3 = c2;
c2.i = 10;
Console.WriteLine(c3.i);
Console.WriteLine(c.i);
Constructors c4 = new Constructors(10);