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
        public class Department : College
        {
            public Department()
            {

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
}