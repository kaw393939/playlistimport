// See https://aka.ms/new-console-template for more information

using playlistimport;
using Utilities;

//User Interaction To Retrieve Data
var absoluteFilePath = UserInputs.GetFilePathUser();
var songYear = UserInputs.GetYearUser();

//Reading In CSV File
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