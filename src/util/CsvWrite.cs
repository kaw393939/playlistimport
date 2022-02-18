namespace Music;
using System.Globalization;
using CsvHelper;

public class CsvWrite
{
    public static void WriteCSVtoPath<T>(string outputPath, List<T> records)
    {
        using (var writer = new StreamWriter(outputPath))
        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(records);
        }
    }
}