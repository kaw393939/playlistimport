using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using static Utilities.ListUtilities;

namespace Utilities;

/// <summary>
/// this class handles logic for csv file reading and writing
/// CURRENTLY UNUSED
/// </summary>
public class CsvHandler
{
    /// <summary>
    /// read data from a specified file and return a List, of type T, of the results
    /// </summary>
    /// <param name="filename">data filename provided by using (should be relative path)</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> Read<T>(string filename)
    {
        var records = CreateListOfType<T>();

        using (var reader = new StreamReader(filename))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap<SongMap>();
            Console.WriteLine("Reading the CSV File\r");
            records = csv.GetRecords<T>().ToList();
        }

        return records;
    }

    /// <summary>
    /// write data to the console
    /// </summary>
    /// <param name="records"></param>
    /// <param name="removeDuplicates"></param>
    /// <typeparam name="T"></typeparam>
    public static void Write(List<Song> records, bool removeDuplicates=false)
    {
        //here is creating a new list type using a function
        Console.WriteLine($"Record Count = {records.Count}\r");
        Console.WriteLine("_____________________________\r");

        if (removeDuplicates)
        {
            var distinctItems = records.GroupBy(x => x.Name).Select(y => y.First());
        }
        
        // write data to output csv file
        // using (var writer = new StreamWriter("./Output.csv"))
        // using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        // {
        //     csvWriter.WriteRecords(songQueryResults);
        // }
        // Console.WriteLine("Done");
    }
}

// map corresponding data from file to class
public class SongMap : ClassMap<Song>
{
    public SongMap()
    {
        Map(m => m.Name);
        Map(m => m.Artist);
        Map(m => m.Composer);
        Map(m => m.Genre);
        Map(m => m.Year).TypeConverter<CustomDateYearConverter>();
        Map(m => m.Plays).TypeConverter<CustomIntConverter>();
    }
}
