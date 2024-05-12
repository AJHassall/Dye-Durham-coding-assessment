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

        public IList<T> Sort<T>(IList<T> unsortedNames) where T : ISortable, new()
        {
            IList<T> names = new List<T>();
            var sortedNames = unsortedNames
                .OrderBy(x => x.GetValueAsSorted())
                .ToList();

            return sortedNames;
        }
    }
}
