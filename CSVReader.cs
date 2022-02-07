using System.Globalization;
using CsvHelper;

namespace playlistimport;

public class CsvRead
{
    public static List<T> FromPath<T,TMap>(string FilePath)
    {
        
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<SongMap>();
            return csv.GetRecords<T>().ToList();
        }
        
    }
}