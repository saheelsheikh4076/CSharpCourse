using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class StudentClass//The class next to namespace is called Type
    {
        ///Following are the class members
        /// properties are customized variables (private, public, etc),
        /// fields are only variables (private),
        /// methods (functions) (private, public, etc)
        /// struct
        /// classes - > classes (nested classes)
        /// 

        public string FirstName { get; set; }
        private string FatherName;//Private Field
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Name { get; private set; }//Public Property
        public int Age { get; set; }//Public Property
        public string Gender { get; }//Public Property (value can be set using constructor)
        //public string Mobile { set; }// Not allowed - Useless
        public void Test()
        {
            FatherName = "ABCD";//Setting value
            string temp = FatherName;//Getting value
            Name = "qwer";//set
            temp = Name;//get
        }
        public class Mobile
        {
            public string CompanyName { get; set; }
            public string Brand { get; set; }
            public float ScreenSize { get; set; }
        }
        public struct Bag
        {
            public string CompanyName { get; set; }
            public string Brand { get; set; }
            public float BagSize { get; set; }
        }
    }
}
