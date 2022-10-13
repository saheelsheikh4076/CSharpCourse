namespace Advance
{
    /// <summary>
    /// Generic : to make general
    /// </summary>
    public class GenericClass<T,TResult>
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public TResult ReturnType { get; set; }
        public TResult MyMethod<K,Q>(T parameter, Q para1, K para2)
        {
            K value;
            Q value2;
            T value3;
            //Meaningful operation
            return ReturnType;
        }
    }
}
