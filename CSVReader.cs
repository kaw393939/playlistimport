using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace playlistimport;

public class CsvRead
{
    public static List<T> FromPath<T,TMap>(string FilePath) where TMap : ClassMap
    {
        
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<TMap>();
            return csv.GetRecords<T>().ToList();
        }
        
    }
}