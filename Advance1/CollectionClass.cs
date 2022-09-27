namespace Advance1
{
    public class CollectionClass
    {
        public static void Test() 
        {
            //Declaration, allocate and assignemnt of value
            int[] a = { 1, 2, 3, 4, 5 };
            string[] s = { "first", "second", "third" }; 
            float[] f = { 1.2f, 2.2f, 3.3f, 4.2f, 5.0f };
            double[] d = { 1.1, 2.2, 3.3 };
            char[] c = { 'a', 'b', 'c' };
            bool[] b = { true, false, false, false, false };

            //declare only label
            int[] a1;
            string[] s2;

            //allocate memory
            a1 = new int[5];

            //assign value
            a1[0] = 10;
            //Allocate and assign values
            s2 = new string[] { "one", "two", "three" };

            //Declare and allocate memory
            int[] a2 = new int[10];
            string[] s3 = new string[10];
            //then assign value afterwards
            a2[0] = 10;
            a2[1] = 11;
            a2[2] = 12;
            a2[3] = 13;


            //Multi Dimension Arrays
            //Two dimension array 
            int[][] a3 = new int[][]
            {
                new int[]{1,2,3,4},//base index 0
                new int[]{5,6,7,8}, // base index 1
                new int[]{3,2,1,6} //base index 2
            };
            Console.WriteLine(a3[2][3]);
            


            int[][][] a4 = new int[][][]
            {
                new int[][]
                {
                    new int[]{1,2,3},
                    new int[]{4,5,6}
                },
                new int[][]
                {
                    new int[]{9,8,7},
                    new int[]{40,50,60}
                }
            };
            Console.WriteLine(a4[1][1][0]);
            a4[1][1][0] = 100;
            Console.WriteLine(a4[1][1][0]);
        }
    }
}
