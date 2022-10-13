namespace Advance;

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
        ints3 = new() { 22, 33, 44, 55 };//it also creates new instance in heap (overrites previous address)
        List<int> ints4 = ints3;//It does not create new instance rather it gives the address
        //of ints3 to ints4. thus, both will point to same list
        ints4.Add(100);

        //Filtering using where
        List<int> ints5 = ints3.Where(s=>s<40 && s>20).ToList();
    }
}
