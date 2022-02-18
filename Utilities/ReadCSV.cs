using System.Globalization;
using playlistimport.Classes;
using CsvHelper;

namespace playlistimport.Utilities;

public class ReadCSV {
    public static List<T> FromCSV<T, TMap>(string filePath) {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture)) {
            csv.Context.RegisterClassMap<SongMap>();
            return csv.GetRecords<T>().ToList();
        }    
    }
}