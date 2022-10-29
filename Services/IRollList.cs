namespace Services
{
    /// <summary>
    /// Interfaces that will provide list of services
    /// </summary>
    public interface IRollList
    {
        //Service 1
        public List<int> GetAll();
        //service 2
        public int GetCount();
        //service 3
        public bool Add(int rollNo);
        //service 4
        public bool Delete(int rollNo);
    }
}