using NameUtility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter.Data
{
    public class Name : ISortable
    {
        private IList<string> GivenNames;
        private string LastName;
        public string Value;

        string ISortable.Value
        {
            get => Value;
            set
            {
                LastName = value.Split(' ').ToList().Last();
                GivenNames = value.Split(' ').ToList();
                GivenNames.RemoveAt(GivenNames.Count-1);
                Value = value;
            }
        }

        public string GetValueAsSorted()
        {
            //Sort by last name then by any given names
            var copy = new List<string>(GivenNames);
            copy.Insert(0, LastName);


            return string.Join(" ", copy);
        }
    }
    
}
