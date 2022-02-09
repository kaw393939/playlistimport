// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using playlistimport;
using playlistimport.Classes;
using Utilities;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import

var filePath = "data/music.csv";

Console.WriteLine("Enter The year\r");
var readYear = Console.ReadLine();
if (readYear != String.Empty)
{
    songYear = int.Parse(readYear);
    ConsoleWrite.WriteToConsole(songYear.ToString());
}

//here is creating a new list type using a function
var records = CreateNewListOfType<Song>();

IEnumerable<Song> songs = new List<Song>();
using (var reader = new StreamReader(filePath))
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
