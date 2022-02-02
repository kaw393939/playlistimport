// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using playlistimport;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import

Console.WriteLine("Enter The Absolute File Path for the playlist\r");
var absoluteFilePath = "";
var filePath = Console.ReadLine();
if (filePath == "")
{
    absoluteFilePath = "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv";
}

Console.WriteLine("Enter The year\r");
var readYear = Console.ReadLine();
var songYear = 2015;
if (!string.IsNullOrEmpty(readYear))
{
    songYear = int.Parse(readYear);
    Console.WriteLine(songYear);
}

List<Song> records;

using (var reader = new StreamReader(absoluteFilePath))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    csv.Context.RegisterClassMap<SongMap>();
    Console.WriteLine("Reading the CSV File\r");
    records = csv.GetRecords<Song>().ToList();
}

Console.WriteLine($"Record Count = {records.Count}\r");
Console.WriteLine("_____________________________\r");

List<Song> RemoveDuplicateSongs(List<Song> list)
{
    var distinctItems = list.GroupBy(x => x.Name).Select(y => y.First());
    return distinctItems.ToList();
}

var distinctItems = RemoveDuplicateSongs(records);

//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
IEnumerable<Song> songQuery =
    from song in distinctItems
    orderby song.Plays
    where song.Year == new DateOnly(songYear,1,1)
    select song;

var songQueryResults = songQuery.ToList();
var songCountCount = songQueryResults.Count.ToString();
Console.WriteLine(songCountCount);
foreach (Song song in songQueryResults)
{
    Console.WriteLine("{0},{1}, {2}",song.Name,song.Artist, song.Genre);
}

using (var writer = new StreamWriter("./Output.csv"))
using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    csvWriter.WriteRecords(songQueryResults);
}
Console.WriteLine("Done");