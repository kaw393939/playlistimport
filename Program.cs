// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using playlistimport;
using playlistimport.Classes;
using playlistimport.Utilities;
using Utilities;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import

var absoluteFilePath = UserInput.GetFilePath();
var songYear = UserInput.GetYear();

var records = ReadCSV.FromCSV<Song, SongMap>(absoluteFilePath);

//here is creating a new list type using a function
List<T> CreateNewListOfType<T>()
{
    List<T> records = new List<T>();
    return records;
}
/*var records = CreateNewListOfType<Song>();

Console.WriteLine($"Record Count = {records.Count}\r"); */

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


