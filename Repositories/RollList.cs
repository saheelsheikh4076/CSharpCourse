using Services;

namespace Repositories
{
    /// <summary>
    /// Repository is a place where business logic lies.
    /// </summary>
    public class RollList:IRollList //This is a contract that the class will provide implementation of all the services provided by the interface
    {
        private List<int> _RollList;
        public RollList()
        {
            _RollList = new List<int>()
            {
                12,13,15,17,19 //Seeding data
            };
        }
        public bool Add(int rollNo)
        {
            bool result = false;
            try
            {
                _RollList.Add(rollNo);
                result= true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public bool Delete(int rollNo)
        {
            bool result = false;
            if (_RollList.Any(s => s == rollNo))
            {
                try
                {
                    _RollList.Remove(rollNo);
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                }
            }
            return result;
        }

        public List<int> GetAll()
        {
            return _RollList;
        }

        public int GetCount()
        {
            return _RollList.Count;
        }
    }
}