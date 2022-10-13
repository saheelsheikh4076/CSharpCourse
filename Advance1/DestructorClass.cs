namespace Advance
{
    public class DestructorClass
    {
        //each class has a default constructor and that is parameterless.
        public DestructorClass()//It creates an instance in heap memory
        {
            ConstantVariables.Counter++;
            ConstantVariables.StartTime = DateTime.Now;
            ConstantVariables.StopTime = DateTime.Now;
        }
        public int MyProperty { get; set; }

        ~DestructorClass()//Each class has a destructor called default destructor
        {
            //it is called by garbage collector during its removal from memory
            //It removes the instance of class from memory
            //we can override the destructor and use it for meaningful operation during
            //deinstantiation
            ConstantVariables.Counter--;
            ConstantVariables.StopTime = DateTime.Now;
        }
    }
}
