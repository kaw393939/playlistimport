// See https://aka.ms/new-console-template for more information

using playlistimport;
using Utilities;
//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import
var absoluteFilePath = UserInputs.GetFilePathUser();
var songYear = UserInputs.GetYearUser();
//here is creating a new list type using a function


var records = CSVRead.FromPath<Song, SongMap>(absoluteFilePath); 

ConsoleWrite.WriteToConsole($"Record Count = {records.Count}\r");
ConsoleWrite.WriteToConsole("_____________________________\r");
//removes duplicates
var distinctItems = records.GroupBy(x => x.Name).Select(y => y.First());
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
var songQueryResults = CustomLinqQuery.GetSongsByYr(distinctItems.ToList(), songYear);
var songCountCount = songQueryResults.Count.ToString();
foreach (Song song in songQueryResults)
{
    var message = String.Format("{0},{1}, {2}",song.Name,song.Artist, song.Genre);
    ConsoleWrite.WriteToConsole(message);
}

string outPath = "./Output.csv";
CSVWrite.WriteCSVtoPath<Song>(outPath, songQueryResults);
ConsoleWrite.WriteToConsole("Done");