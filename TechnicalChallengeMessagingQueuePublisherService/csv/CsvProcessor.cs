using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalChallengeMessagingQueuePublisherService.csv
{
    public class CsvProcessor
    {
        private readonly string FilePath;

        public CsvProcessor(string filePath) 
        {
            FilePath = filePath;
        }

        public List<T> ConvertCsv<T>()
        {
            using (var reader = new StreamReader(FilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                List<T> records = csv.GetRecords<T>().ToList();

                return records;
            }
        }
    }
}
