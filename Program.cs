﻿// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using Utilities;
//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import
Console.WriteLine("Enter The Absolute File Path for the playlist\r");
var absoluteFilePath = "";
absoluteFilePath = ConsoleRead.ReadConsole();
if (absoluteFilePath == "")
{
    absoluteFilePath = "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv";
}

ConsoleWrite.WriteToConsole("Enter The year\r");
var readYear = ConsoleRead.ReadConsole();
var songYear = 2015;
if (readYear != String.Empty)
{
    songYear = int.Parse(readYear);
}
//here is creating a new list type using a function


var records = CSVRead.FromPath<Song, SongMap>(absoluteFilePath); 

ConsoleWrite.WriteToConsole($"Record Count = {records.Count}\r");
ConsoleWrite.WriteToConsole("_____________________________\r");
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
foreach (Song song in songQueryResults)
{
    var message = String.Format("{0},{1}, {2}",song.Name,song.Artist, song.Genre);
    ConsoleWrite.WriteToConsole(message);
}

string outPath = "./Output.csv";
CSVWrite.WriteCSVtoPath<Song>(outPath, songQueryResults);
ConsoleWrite.WriteToConsole("Done");