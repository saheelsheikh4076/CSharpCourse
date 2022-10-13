using Basics;

namespace Advance
{
    public class Constructors
    {
        public void Test()
        {

            Constructors c;//It just assigns a label for that class i.e a pointer is declared without address
                           //A reference variable without reference is created.

            Constructors c2 = new Constructors();//new keyword calls the constructor. new <constructor>
            ArithmaticClass a = new ArithmaticClass();// constructor has (), it has name same as class name
                                                      //constructor lies within the class
                                                      //if you do not see any constructor within class then it is hidden
                                                      //by default a parameterless constructor is always present and is hidden
                                                      //we can override the hidden constructor by creating our own constructor
        }
        public int i { get; set; }
        private int j;
        public int result ;
        //Following is the syntax of overridden parameterless constructor
        public Constructors()
        {
            //It is responsible to create an instance of class in Heap memory
        }
        public Constructors(int _i)
        {
            j = _i;
        }

        public Constructors(int a, int b, int c)
        {
            result = (a + b) * c;
        }
         
    }
}
