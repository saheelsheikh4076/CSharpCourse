using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class NewRollList : IRollList
    {
        private List<int> _RollList;
        public NewRollList()
        {
            _RollList = new List<int>()
            {
                12,13,15,17,19 //Seeding data
            };
        }
        public bool Add(int rollNo)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int rollNo)
        {
            throw new NotImplementedException();
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
