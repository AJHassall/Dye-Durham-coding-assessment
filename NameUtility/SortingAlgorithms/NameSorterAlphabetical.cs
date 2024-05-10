using name_sorter.Data;
using NameSortingUtility;
using NameSortingUtility.Services;
using NameUtility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameUtility.Sorters
{
    internal class NameSorterAlphabetical : ISortingAlgorithm
    {
        public IList<ISortable> Sort(IList<ISortable> unsortedNames)
        {
            IList<ISortable> names = new List<ISortable>();
            var sortedNames = unsortedNames
                .OrderBy(x => x.Value)
                .ToList();

            return sortedNames;
        }
    }
}
