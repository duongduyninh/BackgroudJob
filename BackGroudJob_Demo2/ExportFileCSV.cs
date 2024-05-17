using CsvHelper;
using System.Formats.Asn1;
using System.Globalization;

namespace BackGroudJob_Demo2
{
    public class ExportFileCSV<T>
    {
        private readonly string _filePath;
        private readonly List<T> _data;

        public ExportFileCSV()
        {
            string folderPath = "FileCSV";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string currentTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            _filePath = Path.Combine(folderPath, $"output_{currentTime}.csv");

            _data = new List<T>();
        }

        public void AddData ( T data) 
        {
            _data.Add(data);
        }

        public void Export()
        {
            using (var writer = new StreamWriter(_filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(_data);
            }
        }

    }
}
