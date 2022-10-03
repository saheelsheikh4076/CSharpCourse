namespace OOPS
{
    public class Inheritance
    {
        public void Test()
        {
            BaseClass p = new BaseClass();
            p.Surname = "ABC";
            DerivedClass c = new DerivedClass();
            c.Surname = "ABC";
        }
        //Inheriting Properties and other members of the class into another class is
        //called inheritance.
        public class BaseClass
        {
            public string Surname { get; set; }
            public string Name { get; set; }
        }
        public class DerivedClass:BaseClass//Child class inherited properties of parent class
        {
            //Parent class is called as base class (technically)
            //Clild class is called as derived class
        }
        public class Derived1Class : BaseClass
        {

        }
    }
}