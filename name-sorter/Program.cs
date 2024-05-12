
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
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify a file");
                return -1;
            }

            var sortBuilder = new SortBuilder<Name>(args[0])
                .SetSortOrder(NameSorterEnum.LastNameFirstName)
                .Build();

            sortBuilder.WriteNamesToFile();
            sortBuilder.WriteNamesToConsole();

            return 1;

        }
    }
}

