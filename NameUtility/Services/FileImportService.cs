using name_sorter.Data;
using NameUtility.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSortingUtility.Services
{
    internal class FileImportService<T> where T : ISortable
    {
        public FileImportService()
        {

        }

        public IList<ISortable> GetValuesFromFile(string fileName)
        {
            var names = new List<ISortable>();
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var fullName = line.Split(' ');
                        if (fullName.Length == 0)
                        {
                            continue;
                        }

                        //add item to list
                        var name = new Name(fullName);
                        names.Add(name);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.");
            }

            return names;
        }
    }
}
