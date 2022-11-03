namespace Asynchronous
{
    public class AsynchronousClass
    {
        //When a function is followed by () then it means that function is called.
        //When a function name is not followed by () then it means it is a function pointer
        public async void Test()
        {
            Task T1 = new Task(Task1);
            Task T2 = new Task(Task2);
            Task T3 = new Task(Task3);
            Task T4 = new Task(Task4);
            Task T5 = new Task(Task5);
          
            
            T1.Start();//Thread1
            T3.Start();//Thread2
            T2.Start();//Thread3
            T4.Start();//Thread4
            T5.Start();//Thread5
            
            Task.WaitAll(T1,T2,T3,T4,T5);//STOP

            // Synchronous threading runs on UI Thread
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
        }
        public void Task1()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 Complete 2 Sec");
        }
        public void Task2()
        {
            Thread.Sleep(4000);
            Console.WriteLine("Task 2 Complete 4 Sec");
        }
        public void Task3()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Task 3 Complete 1 Sec");
        }
        public void Task4()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Task 4 Complete 5 Sec");
        }
        public void Task5()
        {
            Thread.Sleep(3000);
            Console.WriteLine("Task 5 Complete 3 Sec");
        }
    }
}