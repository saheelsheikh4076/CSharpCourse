using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance
{
    public class PropertyClass
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        private string _Name;

        public string Name 
        {
            get //Get Method
            {
                if(_Name == null)
                {
                    _Name = "No Value";
                }
                return _Name.ToUpper();
            }
            set //set method
            {
                if (value.Length > 6)
                {
                    _Name = value.Trim();
                }
            } 
        }
    }
}
