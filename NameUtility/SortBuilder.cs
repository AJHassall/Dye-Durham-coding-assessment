using name_sorter.Data;
using NameSortingUtility;
using NameSortingUtility.Services;
using NameUtility.Data;
using NameUtility.Sorters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameUtility
{
    public class SortBuilder<T> where T : ISortable
    {
        private readonly string FileName;
        private ISortingAlgorithm SortingAlgorithm;
        private IList<ISortable> Names;

        private bool isSortOrderSet = false;
        private bool isObjectBuilt = false;

        public SortBuilder(string fileName) 
        {
            FileName = fileName;
        }

        public SortBuilder<T> SetSortOrder(NameSorterEnum sortOrder)
        {

            var nameSorterFactory = new SortingAlgorithmFactory();
            SortingAlgorithm = nameSorterFactory.GetSortingAlgorithm(sortOrder);

            isSortOrderSet = true;
            return this;
        }

        public void WriteNamesToConsole()
        {
            foreach (var name in Names)
            {
                Console.WriteLine(name.ReadValue);
            }
        }

        public void WriteNamesToFile()
        {
            if (!isSortOrderSet)
            {
                throw new Exception("Sort Order is not set");
            }
            var extension = Path.GetExtension(FileName);
            var fileName = Path.GetFileNameWithoutExtension(FileName);
            using (TextWriter tw = new StreamWriter($"{fileName}.sorted{extension}"))
            {
                foreach (ISortable name in Names)
                    tw.WriteLine(name.Value);
            }
        }

        private void ReadNamesFromFile()
        {
            var fileImportService = new FileImportService<T>();
            var unsortedNames = fileImportService.GetValuesFromFile(FileName);
            Names = unsortedNames;

        }

        private bool Validate()
        {
            IList<string> errors = new List<string>();

            if (!isSortOrderSet)
            {
                errors.Add("Sort order is not set");
            }

            return errors.Count == 0;

        }

        public SortBuilder<T> Build()
        {
            if (!Validate())
            {
                throw new Exception("Builder is not configured correctly");
            }

            ReadNamesFromFile();

            Names = SortingAlgorithm.Sort(Names);
            return this;
        }

        public IList<ISortable> GetNames() { return Names; }
    }
}
