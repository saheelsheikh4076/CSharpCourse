using static OOPS.AccessModifiers;

namespace OOPS//Assembly
{
    internal class OutsideClass//Type can only be public or internal
    {
        protected class InternalClass
        {

        }
        public void Test()
        {
            PublicClass publicClass = new PublicClass();
            InternalClass internalClass = new InternalClass();
            //ProtectedClass protectedClass = new ProtectedClass();
            //PrivateClass privateClass = new PrivateClass();
        }
    }
    public class AccessModifiers//Type
    {
        //Access Modifiers basically are four
        //private, protected, internal, public
        public void Test()
        {
            PublicClass publicClass = new PublicClass();
            InternalClass internalClass = new InternalClass();
            ProtectedClass protectedClass = new ProtectedClass();
            PrivateClass privateClass = new PrivateClass();
        }
        public class PublicClass //type/class
        {
            public string Name { get; set; }//member
        }
        internal class InternalClass 
        {
            public string Name { get; set; }
        }
        protected class ProtectedClass 
        {
            public void Test()
            {
                ProtectedClass protectedClass = new ProtectedClass();
            }
            public string Name { get; set; }
        }
        protected class ProtectedClass1 : ProtectedClass
        {
            public void Test()
            {
                ProtectedClass publicClass = new ProtectedClass();
            }
        }
        private class ProtectedClass2 : ProtectedClass
        {
            public void Test()
            {
                ProtectedClass publicClass = new ProtectedClass();
            }
        }
        private class PrivateClass 
        {
            public string Name { get; set; }
        }
    }
}
