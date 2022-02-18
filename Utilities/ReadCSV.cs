using System.Globalization;
using playlistimport.Classes;
using CsvHelper;

namespace playlistimport.Utilities;

public class ReadCSV {
    public static List<T> FromPath<T, TMap>(string FilePath) {
        using (var reader = new StreamReader(FilePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
            csv.Context.RegisterClassMap<SongMap>();
            return csv.GetRecords<T>().ToList();
        }    
    }
}