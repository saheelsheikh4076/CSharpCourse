using DataTypes;
//To create a variabe of class type (OLD fashion)
//or to create a class instance
//or to create a class object
//or to instantiate a class 
//or to create a reference variable of a class
string StudentName = "aaa";
string FatherName = "bbb";
string mobile = "345435343";
string Address = " sdf dsf fds fsd fs ";
string City = "Nagpur";
string MotherName = "ddd";
string Region = "MH";

string StudentName1 = "aaa";
string FatherName1 = "bbb";
string mobile1 = "345435343";
string Address1 = " sdf dsf fds fsd fs ";
string City1 = "Nagpur";
string MotherName1 = "ddd";
string Region1 = "MH";



StudentClass s1 = new StudentClass()
{
    Address = "sfdsff dsf sd",
    Age = 22,
    City = "nagpur",
    FirstName = "aaa",
    Region = "mh",
    PhoneNo = "43242342"  
};
StudentClass s2 = new StudentClass()
{
    Address = "sfdsff dsf sd",
    Age = 22,
    City = "nagpur",
    FirstName = "aaa",
    Region = "mh",
    PhoneNo = "43242342"
};


//s.Name = "abcd";//set not allowed as it is private set
string tmp = s.Name;//get
StudentClass.Mobile m = new StudentClass.Mobile();
m.ScreenSize = 6;
StudentClass.Bag b = new StudentClass.Bag();
b.BagSize = 5;