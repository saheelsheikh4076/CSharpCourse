namespace Advance;
/// <summary>
/// We use LINQ language expressions for working on List
/// List are of two types IQueryable & IEnumerable
/// </summary>
public class ListClass
{
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
        

        List<int> ints5 = ints3.Where(s=>s<40 && s>20).ToList();

        //Sorting Ascending Descending
        List<int> ints6 = ints3.OrderBy(a => a).ToList();
        List<int> ints7 = ints3.OrderByDescending(s => s).Where(s=>s>50).ToList();
        //Take only fixed number of items
        var ints8 = ints3.Take(3).ToList();//Top
        var ints9 = ints3.TakeLast(2).ToList();
        var intNumber = ints.First();
        var intLast = ints.Last();
        var removeSucceeded = ints.Remove(10);
        ints3.ForEach(s => s = 3 );//Class Variable -> Student Age Property change Foreach
        ints3.DefaultIfEmpty();//It checks and if found empty or null then changes it to default value.. for int default is 0
        var intDistinct = ints3.Distinct().ToList();
        ints3.DistinctBy(s => s);//It is for complex list .. class variable list
        ints3.ElementAt(1); // int[] a => a[0]
        var elementat = ints3.ElementAtOrDefault(6);
    }
}
