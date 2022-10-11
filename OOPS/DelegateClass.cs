using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class DelegateClass
    {
        //A pointer holds address and points to the location
        //a delegate is a pointer to a function
        //it allows call backs
        //its advantage is that it decouples the code
        public delegate void MyDelegate(int a);//Defination
        //Syntax: first is access modifier public, private,etc
        //second is delegate keyword
        //third is the return type of the pointer. 
        //fourth is the name of delegate 'MyDelegate'
        //fifth is parameters or arguments (int a) parameter
        //signature of deletage is that its return type is void and it takes a int parameter
        public void Test()
        {
            //Create an instance of delegate
            MyDelegate addDelegate = new MyDelegate(Add);
            addDelegate.Invoke(10);//invoke means start
            Add(10);
            DelegateClass2 class2 = new DelegateClass2();
            class2.Test(Add1);
        }
        public void Add1(int abc)
        {
            Console.WriteLine("new function {0}", abc);
        }
        public void Add(int first)
        {
            Console.WriteLine($"Value is {first}");
        }
    }

    public class DelegateClass2
    {
        public delegate void AddDelegate(int a);
        public void Test(AddDelegate addFunction)
        {
            addFunction(15);//Call back function
            addFunction(15);//Call back function
            addFunction(15);//Call back function
            addFunction(15);//Call back function
            addFunction(15);//Call back function
            addFunction(15);//Call back function
            addFunction(15);//Call back function
            addFunction(15);//Call back function
            //This function does not know which function/method to call
        }
        public void Test1()
        {
            DelegateClass c = new DelegateClass();
            c.Add1(10);
            c.Add1(10);
            c.Add1(10);
            c.Add1(10);
            c.Add1(10);
            c.Add1(10);
            c.Add1(10);
        }
    }
}
