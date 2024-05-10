
using name_sorter.Data;
using NameSortingUtility.Services;
using NameUtility;
using NameUtility.Sorters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var sortBuilder = new SortBuilder<Name>("names.txt")
                .SetSortOrder(NameSorterEnum.LastNameFirstName)
                .Build();

            sortBuilder.WriteNamesToFile();
            sortBuilder.WriteNamesToConsole();

        }
    }
}

