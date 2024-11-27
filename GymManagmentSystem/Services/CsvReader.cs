using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ruta: GymManagementSystem/Services/CsvReader.cs
using System.Collections.Generic;
using System.IO;

namespace GymManagementSystem.Services
{
    public static class CsvReader
    {
        public static List<string[]> ReadCsv(string filePath)
        {
            var lines = new List<string[]>();
            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    lines.Add(values);
                }
            }
            return lines;
        }
    }
}
