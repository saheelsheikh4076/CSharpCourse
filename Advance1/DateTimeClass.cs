namespace Advance1
{
    public class DateTimeClass
    {
        public static void Test()
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(DateTime.Now.AddDays(-1));
            Console.WriteLine(DateTime.Now.AddHours(-1));
            Console.WriteLine(new DateTime(2022, 9, 15));
            Console.WriteLine(new DateTime(2022, 12, 15, 15, 10, 10));
            string dateStr = "2022-5-04";
            string[] dateSplit = dateStr.Split('-');
            date = new DateTime(Convert.ToInt32(dateSplit[0]),
                Convert.ToInt32(dateSplit[2]), Convert.ToInt32(dateSplit[1]));
            //date = Convert.ToDateTime(dateStr);//System Date Format Must match
            //Convert date to string
            string dt = date.ToString();//Date + Time
            dt = date.ToShortDateString();
            string time = date.ToShortTimeString();
            string dtDDMMYYYY = date.ToString("yy-M-d");
            string timeDDMMYYYYYY = date.ToString("hh:m:ss tt");
            bool IsSucceeded = DateTime.TryParse("2022-33-03", out DateTime date1);
        }
    }
}
