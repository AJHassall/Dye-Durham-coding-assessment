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
    public class FileImportService<T> where T : ISortable, new()
    {
        public readonly StreamReader _streamReader;
        
        public FileImportService(StreamReader streamReader)
        {
            _streamReader = streamReader;
        }

        public List<T> GetValuesFromFile()
        {
            List<T> values = new List<T>();

            try
            {
                using (StreamReader reader = _streamReader)
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        try
                        {
                            T value = new T(); 
                            value.Value = line;
                            values.Add(value);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine($"Error parsing line '{line}': {ex.Message}");
                        }
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {(_streamReader.BaseStream as FileStream).Name} - {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file: {(_streamReader.BaseStream as FileStream).Name} - {ex.Message}");
            }

            return values;
        }
    }
}
