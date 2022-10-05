using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    public class IncompleteClass
    {
        public void Test()
        {
            Student s = new Student();
           
        }
        //Same class in different location is partial class
        public partial class Student
        {
            public Student()
            {

            }
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public partial class Student
        {
            public int Age { get; set; }
        }


        public partial class Student
        {
            public string Address { get; set; }
        }
    }
}
