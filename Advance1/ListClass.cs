namespace Advance;
/// <summary>
/// We use LINQ language expressions for working on List
/// List are of two types IQueryable & IEnumerable
/// </summary>
public class ListTestClass
{
    public ListTestClass()
    {
        SubClassItem = new ListSubClass();
        //MyName = string.Empty;
    }
    public class ListSubClass
    {
        public ListSubClass()
        {
            SubSubPropItem = new SubSubClass();
        }
        public class SubSubClass
        {
            public SubSubClass()
            {
                SubSubStrProp2 = string.Empty;
            }
            public int SubSubProp1 { get; set; }
            public string SubSubStrProp2 { get; set; }
        }
        public int SubProperty1 { get; set; }
        public int SubProperty2 { get; set; }
        public SubSubClass SubSubPropItem { get; set; }
        public SubSubClass? SubSubPropItem2 { get; set; }
    }
    public int MyProperty1 { get; set; }//valued type: Non Nullable
    public int MyProperty2 { get; set; }//valued type: Non Nullable
    public ListSubClass SubClassItem { get; set; }//reference type: Nullable
    public string? MyName { get; set; }//Reference type : Nullable
}
public class ListClass
{
    public void TestComplexList()
    {
        ///Example 1
        //Method1
        //create list of class
        List<ListClass> list = new List<ListClass>();
        //create class instance
        ListClass lc = new ListClass();
        //add class instance into list
        list.Add(lc);

        //Method 2
        list.Add(new ListClass());

        //Example 2
        List<ListTestClass> l = new List<ListTestClass>()
        {
            new ListTestClass()
            {
                //ListSubClass is null here
                MyProperty1 = 1,
                MyProperty2 = 2
            },
            new ListTestClass()
            {
                MyProperty1 = 3,
                MyProperty2 = 4
            },
            new ListTestClass()
            {
                MyProperty1 = 5,
                MyProperty2 = 6
            }
        };
        l.Add(new ListTestClass()
        {
            MyProperty1 = 7,
            MyProperty2 = 8
        });
        l.Add(new ListTestClass()
        {
            MyProperty1 = 9,
            MyProperty2 = 10
        });
        l.AddRange(new List<ListTestClass>()
        {
            new ListTestClass()
            {
                MyProperty1 = 1,
                MyProperty2 = 2
            },
            new ListTestClass()
            {
                MyProperty1 = 3,
                MyProperty2 = 4
            },
            new ListTestClass()
            {
                MyName = "Irfan sir",
                SubClassItem = new ListTestClass.ListSubClass()
                {
                    SubProperty1 = 1,
                    SubProperty2 = 2,
                    SubSubPropItem = new ListTestClass.ListSubClass.SubSubClass(),
                    SubSubPropItem2 = new ListTestClass.ListSubClass.SubSubClass()
                },
                MyProperty1 = 5,
                MyProperty2 = 6
            }
        }); ;
        foreach (var item in l)
        {
            var myName = item.MyName ?? "Not available";
            Console.WriteLine($"MyProperty1:{item.MyProperty1} & " +
                $"MyProperty2:{item.MyProperty2} " +
                $"MyName :{myName}" +
                $"& SubClassItem1:{item.SubClassItem.SubProperty1} " +
                $"& SubClassItem2:{item.SubClassItem.SubProperty2}");
        }

    }
    public void Test()
    {
        List<int> ints = new List<int>();
        ints.Add(10);
        ints.Add(20);
        ints.Add(30);
        List<int> ints1 = new List<int>();
        ints1.AddRange(ints);
        List<int> ints2 = new List<int>() { 1, 2, 3, 4, 10, 23, 44 };
        List<int> ints3;
        ints3 = new List<int> { 1, 2, 3, 4, 10, 23, 22 };//It creates new instance in heap
        ints3 = new() { 122, 83, 44, 55, 55 };//it also creates new instance in heap (overrites previous address)
        List<int> ints4 = ints3;//It does not create new instance rather it gives the address
        //of ints3 to ints4. thus, both will point to same list
        ints4.Add(100);

        //Filtering using where.


        List<int> ints5 = ints3.Where(s => s < 40 && s > 20).ToList();

        //Sorting Ascending Descending
        List<int> ints6 = ints3.OrderBy(a => a).ToList();
        List<int> ints7 = ints3.OrderByDescending(s => s).Where(s => s > 50).ToList();
        //Take only fixed number of items
        var ints8 = ints3.Take(3).ToList();//Top
        var ints9 = ints3.TakeLast(2).ToList();
        var intNumber = ints.First();
        var intLast = ints.Last();
        var removeSucceeded = ints.Remove(10);
        ints3.ForEach(s => s = 3);//Class Variable -> Student Age Property change Foreach
        ints3.DefaultIfEmpty();//It checks and if found empty or null then changes it to default value.. for int default is 0
        var intDistinct = ints3.Distinct().ToList();
        ints3.DistinctBy(s => s);//It is for complex list .. class variable list
        ints3.ElementAt(1); // int[] a => a[0]
        var elementat = ints3.ElementAtOrDefault(6);
    }
}
