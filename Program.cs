// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Utilities;
using static Utilities.ListUtilities;

var filename = "music.csv";

SongRequestManager.PrintColumnOptions();
SongRequestManager.UserChoosesColumns();

//here is creating a new list type using a function
var records = CreateListOfType<Song>();

using (var reader = new StreamReader(filename))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    csv.Context.RegisterClassMap<SongMap>();
    Console.WriteLine("Reading the CSV File\r");
    records = csv.GetRecords<Song>().ToList();
}
Console.WriteLine($"Record Count = {records.Count}\r");
Console.WriteLine("_____________________________\r");
//removes duplicates
var distinctItems = records.GroupBy(x => x.Name).Select(y => y.First());
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/t

using (var writer = new StreamWriter("./Output.csv"))
using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csvWriter.WriteRecords(songQueryResults);
}
Console.WriteLine("Done");

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

public class Song
{
    public string Name { get; set; }
    public string Artist { get; set; }
    public string Composer { get; set; }
    public string Genre { get; set; }
    public DateOnly Year { get; set; }
    public int Plays { get; set; }
}