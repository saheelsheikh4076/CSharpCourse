namespace Advance
{
    public class ForEachClass
    {
        public void Test()
        {
            List<int> rollNos = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            foreach (int rollNo in rollNos)
            {
                Console.WriteLine(rollNo);
            }
            foreach (var item in rollNos)
            {

            }
        }
    }
}
