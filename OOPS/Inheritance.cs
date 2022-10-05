using System.ComponentModel;

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
    public class Inheritance1
    {
        public void Test()
        {
            //College c = new College();
            //Console.WriteLine(c.Name??"No value");
            //Console.WriteLine(c.Name==null?"No value":c.Name);
            Department d = new Department();
            Console.WriteLine(d.NoOfStudents);
        }
        //--------------------------------------
        public class College
        {
            public College()
            {
                 this.Name = "Anjuman";
            }
            public College(string _Name, string address)
            {
                Name = _Name;
                Address = address;
            }

            public string? Name { get; set; }
            public string? Address { get; set; }
            public int NoOfStudents { get; set; }
           
        }
        //Deriving Department class from College class
        //Inheriting College class into Department class
        public class Department : College
        {
            public Department()
            {
                //
            }
            public Department(string _Name, string _Address):base(_Name, _Address)
            {
                this.Name = _Name;
                this.Address = _Address;
            }
            //public Department():base("JD","Nagpur")
            //{
            //    this.Name = "Computer";
            //}
            public new int NoOfStudents { get; set; }
        }
    }
    public class MultilevelInheritance
    {
        public void Test()
        {
            Level1 l1 = new Level1();
            Level1 l11 = new Level2();//it by default calls level1 constructor
            Level1 l12 = new Level3();//it also calls level1 constructor
            //Polymorphism

            Level2 l2 = new Level2();
            Level2 l21 = new Level3();

            Level3 l3 = new Level3();
            //Level3 l31 = new Level2();//It does not calls level3 constructor
        }

        public class Level1
        {
            public Level1()
            {

            }
            public int Id { get; set; }
        }
        public class Level2 : Level1
        {
            public Level2()
            {

            }
        }
        public class Level3 : Level2
        {
            public Level3()
            {
                //FILO = First in Last Out
            }
        }
    }
    public class HierarchicalInheritance
    {
        public void Test()
        {
            BaseClass b = new BaseClass();
            BaseClass b1 = new DerivedClass1();
            BaseClass b2 = new DerivedClass2();
        }
        public class BaseClass
        {
            public BaseClass()
            {

            }
        }
        public class DerivedClass1 : BaseClass
        {
            public DerivedClass1()
            {

            }
        }
        public class DerivedClass2 : BaseClass
        {
            public DerivedClass2()
            {

            }
        }
    }
}