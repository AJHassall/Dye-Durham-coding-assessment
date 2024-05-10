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
        private readonly IList<string> GivenNames;
        public string Value
        {
            get {
                IList<string> names = new List<string>(GivenNames);
                string first = names.First();
                names.RemoveAt(0);
                names.Add(first);

                return string.Join(" ", names);
            }
        }

        public string ReadValue
        {
            get
            {
                return string.Join(" ", GivenNames);
            }
        }

        public Name(IList<string> givenNames)
        {
            GivenNames = givenNames;
        }
    }
}
