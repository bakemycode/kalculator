using System;
using System.Collections.Generic;
using System.IO;

namespace kalculrator3
{
    public class ReadFromCsv
    {
        public List<string> loadCsvFile(string filePath)
        {
            var reader = new StreamReader(File.OpenRead(filePath));
            List<string> searchList = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                searchList.Add(line);
                Console.WriteLine(line);
            }
            return searchList;
        }
    }
}