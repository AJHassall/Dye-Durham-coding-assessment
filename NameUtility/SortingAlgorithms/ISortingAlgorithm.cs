using name_sorter.Data;
using NameUtility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameUtility.Sorters
{
    internal interface ISortingAlgorithm
    {
        IList<ISortable> Sort(IList<ISortable> unsortedNames);
    }
}
