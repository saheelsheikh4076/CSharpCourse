namespace Advance1//Assembly
{
    public class AccessModifierClass
    {
        private int id;
        public void test()
        {
            AccessModifierClass c = new AccessModifierClass();
            c.PublicProperty = 10;
            c.InternalProperty = 10;
            c.PrivateProperty = 10;
        }
        private int PrivateProperty { get; set; }
        public int PublicProperty { get; set; }
        internal int InternalProperty { get; set; }//It will be accessible to assembly members
    }
    public class Test2
    {
        public void test()
        {
            AccessModifierClass c = new AccessModifierClass();
            c.InternalProperty = 10;
            c.PublicProperty = 10;
        }
    }
}