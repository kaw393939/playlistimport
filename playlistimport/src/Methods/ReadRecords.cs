using System.Globalization;
using CsvHelper;
using utilties;

namespace playlistimport.Methods;

public class ReadRecords<T>
{
    private List<T> _records;

    public ReadRecords(string? filePath)
    {
        using var reader = new StreamReader(filePath);
        // ReSharper disable once ConvertToUsingDeclaration
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<SongMap>();
            Utilities.ConsoleWrite("Reading the CSV File\r");
            _records = csv.GetRecords<T>().ToList();
        }
    }

    public List<T> AccessRecords()
    {
        return _records;
    }
    
}