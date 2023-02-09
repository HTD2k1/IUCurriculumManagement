using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    public static class CsvHelper
    {
        public static IEnumerable<Record> ReadCSV(string path)
        {
            IEnumerable<Record> csvData = new List<Record>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ",",
            };
            using StreamReader reader = new StreamReader(path, Encoding.UTF8);
            var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<Record>();
            return records.ToList();
        }

        public class Record
        {
            public int program_id { get; set; }
            public int pathway_id { get; set; }
            public string? course_id { get; set; }
            public int semester { get; set; }

            [Name("year")]
            public int year { get; set; }
            public override string ToString()
            {
                return $"{program_id} {pathway_id} {course_id} {semester} {year}";
            }
        }
    }
}
