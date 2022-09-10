using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class ParsingBetweenDataTypes
    {
        public void Method()
        {

            //implicit conversion & explicit conversion
            //implicit (Automatic)
            byte b = 255;

            Int16 i = b;
            Int32 i1 = i;
            Int64 i2 = i1;//implicit from lower to higher
                          //i = i1;//cannot convert from higher to lower


            //Explicit Method1
            i1 = (Int32)i2;
            i = (Int16)i1;
            b = (byte)i;
            //Method 2 using Predefined Functions called Methods
            i1 = Convert.ToInt32(i2);
            i = Convert.ToInt16(i1);
            b = Convert.ToByte(i);

            //from 1 to 1.0 or 2.1 to 2
            float f = i1;//converted implicitly
            i1 = (int)f;//to be converted explicitly
            i1 = Convert.ToInt32(f);//1.3 ->1 & 1.7 -> 2

            char c = '#';//Valued type & all the above are valued type variables
            int i3 = 'a';
            i3 = c;
            i1 = c;

            c = (char)i3;

            string str = "2";
            int i4 = Convert.ToInt32(str);

            str = Convert.ToString(i);
            str = i.ToString();
            str = 3.ToString();

            bool bl = Convert.ToBoolean("true");
            bl = Convert.ToBoolean("Truse");
            bl = Convert.ToBoolean("TRUE");

            str = bl.ToString();
            str = Convert.ToString(bl);

        }
    }
}
