using name_sorter.Data;
using NameUtility;
using NameUtility.Data;
using NameUtility.Sorters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSortingUtility
{
    internal class SortingAlgorithmFactory
    {
        public ISortingAlgorithm GetSortingAlgorithm(NameSorterEnum algorithm)
        {
            switch (algorithm)
            {
                case NameSorterEnum.LastNameFirstName:
                    return new NameSorterAlphabetical();
                default:
                    return new NameSorterAlphabetical();
            }
        }
    }
}
