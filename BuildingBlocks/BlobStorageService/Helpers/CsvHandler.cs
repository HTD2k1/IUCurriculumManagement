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

namespace BlobStorageService.Helpers
{
    public class CsvHandler
    {
        private static readonly CsvConfiguration _csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Encoding = Encoding.UTF8,
            Delimiter = ",",
        };
        public static IEnumerable<CSVRecord> ReadCSV(string path)
        {
            IEnumerable<CSVRecord> csvData = new List<CSVRecord>();
            using StreamReader reader = new StreamReader(path, Encoding.UTF8);
            var csv = new CsvReader(reader, _csvConfig);
            var records = csv.GetRecords<CSVRecord>();
            return records.ToList();
        }

        public static IEnumerable<CSVRecord> ReadCSV(Stream stream)
        {
            IEnumerable<CSVRecord> csvData = new List<CSVRecord>();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                Delimiter = ",",
            };
            using StreamReader reader = new StreamReader(stream);
            var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<CSVRecord>();
            return records.ToList();
        }

        public class CSVRecord
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
