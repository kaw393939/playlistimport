using System.Globalization;
using playlistimport.Classes;
using CsvHelper;

namespace playlistimport.Utilities;

public class WriteCSV
{
    public static void WriteToCSV<T>(string outputPath, List<T> records)
    {
        using (var writer = new StreamWriter(outputPath))
        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(records);
        }
    }
}