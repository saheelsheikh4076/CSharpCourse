namespace OOPS
{
    public partial class DelegateClass
    {
        public void TestFunc()
        {
            
        }
    }

    public partial class DelegateClass
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
        public virtual void Test()
        {
            
            //Create an instance of delegate
            MyDelegate addDelegate = new MyDelegate(Add);
            addDelegate.Invoke(10);//invoke means start
            Add(10);
            DelegateClass2 class2 = new DelegateClass2();
            class2.Test(Add);
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
            addFunction(15);//Call back function.. here we are invoking the delegate
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

    public class DelegateTest
    {
        public delegate int AddDelegate(int a,int b);//Defination
        public void Test(AddDelegate addDelegate)
        {
            //AddDelegate d = new AddDelegate(TargetFunction);
            //int result = d.Invoke(10, 20);

            //--------------------------------
            int result2 = addDelegate(10, 20);
            result2 = addDelegate(10, 20);
            result2 = addDelegate(10, 20);
            result2 = addDelegate(10, 20);
            result2 = addDelegate(10, 20);
            result2 = addDelegate(10, 20);
            result2 = addDelegate(10, 20);
            result2 = addDelegate(10, 20);
            
            Console.WriteLine($"{result2 }");
        }
        //-------------------------------------------------------
        public void CallerFunction()
        {
            Test(AddFunction);
            Test((a, b) => { return a+b; });
            Test(TargetFunction);
            Test((a, b) => { return a * b; });
            Test(SubtractFunction);
            Test((a, b) => { return a - b; });
        }
        public int TargetFunction(int first, int second)
        {
            return first * second;
        }
        public int AddFunction(int first, int second)
        {
            return first + second;
        }
           
        public int SubtractFunction(int first, int second)
        {
            return first - second;
        }
    }

    public class InbuildDelegates
    {
        public void Function1(int a)
        {
            Console.WriteLine($"Action Delegate is invoked and value received is {a}");
        }
        public int Function2(int a, int b, int c)
        {
            return Math.Abs(a) + Math.Abs(b) + Math.Abs(c);
        }
        public bool Function3(int a)
        {
            return a > 10;
        }
        public void TestActionDelegate()
        {
            Action<int> actDelegate = Function1;
            Action<int> actDelegate1 = new Action<int>(Function1);
            actDelegate.Invoke(10);
        }
        public void TestFuncDelegate()
        {
            Func<int, int, int, int> funcDel = Function2;
            Func<int, int, int, int> funcDel1 = new Func<int, int, int, int>(Function2);
            Func<int, bool> funcAsPredicate = Function3;
            Console.WriteLine($"Result of Func As Predicate is {funcAsPredicate.Invoke(11)}");
            int result = funcDel.Invoke(10, 30, -40);
            Console.WriteLine($"Result of Func Delegate is Received as {result}");
        }
        public void TestPredicateDelegate()
        {
            Predicate<int> predDel = Function3;
            Predicate<int> predDel1 = new Predicate<int>(Function3);
            bool result = predDel.Invoke(9);
            Console.WriteLine($"Result of predicate delegate is {result}");
        }


    }

    public class MultiDelegates
    {
        public void Function1(int a)
        {
            Console.WriteLine("Function 1 invoked");
        }
        public void Function2(int a)
        {
            Console.WriteLine("Function 2 invoked");
        }
        public void Function3(int a)
        {
            Console.WriteLine("Function 3 invoked");
        }
        public void Function4(int b)
        {
            Console.WriteLine("Function 4 invoked");
        }

        public void Test()
        {
            Action<int> actDel = Function1;//Subscribe an event of function1
            actDel += Function2;//subscribe function 2
            actDel += Function3;
            actDel += Function4;
            actDel -= Function2;//unsubscribe function 3

            actDel.Invoke(10);
        }


    }

    public class DelegateWithLambda
    {
        public delegate void LambdaDelegate(int a);
        public void Test()
        {
            DoSomething((a) => Console.WriteLine($"Do something is called with value {a}"));
        }

        public void DoSomething(LambdaDelegate l)
        {
            l(10);
        }
        //create a function that will filter numbers from list and return filtered list
        public void TestFilter()
        {
            List<int> list = new List<int>() { 1, 2, 20, 30, 15, 9, 7, 50 };
            
            foreach (var item in GreaterThan10(list))
            {
                Console.WriteLine($"GreaterThan10 Result {item}");
            }
              
            foreach (var item in Filter(list, (a) => { return a > 7; }))
            {
                Console.WriteLine($"Filter Result {item}");
            }
            foreach (var item in Filter(list, (a) => { return a < 20; }))
            {
                Console.WriteLine($"Filter Result {item}");
            }
        }
        
        public delegate bool FilterDelegate(int a);
        public List<int> GreaterThan10(List<int> list)
        {
            List<int> result = new List<int>();
            foreach (var item in list)
            {
                if(item>10)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public List<int> Filter(List<int> list, FilterDelegate filter)
        {
            List<int> result = new List<int>();
            foreach (var item in list)
            {
                if (filter(item))//(a) => { return a > 7; }
                {
                    result.Add(item);
                }
            }
            return result;
        }



        //+++++++++++ARITHMATIC+++++++++++++++++++++++
        public void TestArithmatic()
        {
           var addition = ArithmaticOperation(10, 20, (a, b) => { return a + b; });
           var multiplication = ArithmaticOperation(10, 20, (a, b) => { return a * b; });
           var division = ArithmaticOperation(10, 20, (a, b) => { return a / b; });
           var substraction = ArithmaticOperation(10, 20, (a, b) => { return a - b; });
            Console.WriteLine("Result is {0}",addition);
        }
        public delegate int ArithmaticDelegate(int a, int b);
        public int ArithmaticOperation(int a, int b, ArithmaticDelegate arithmatic)
        {
           return arithmatic(a, b);
        }

        //+++++++++++++++++++++++++++++++++++++++++++
        //Create a function that returns a list of random integers
        //Pass that list to another function that will order it in ascending
        public List<int> GetAListofInt()
        {
            List<int> list = new List<int>()
            {
                11,2,5,2,9,4,10,40,25,17
            };
            return list;
        }
        
    }
}
