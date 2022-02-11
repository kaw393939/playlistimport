// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using playlistimport;
using Utilities;

//Get the data from the user
var filePath = UserInteractions.GetFilePathFromUser();
var filterMethod = UserInteractions.GetFilterMethodFromUser();
var filterResult = UserInteractions.GetXFromUser(filterMethod);


//Read The CSV and Return Songs with the SongMap to correct empty values and convert to correct formats
var records = CsvRead.FromPath<Song, SongMap>(filePath);
ConsoleWrite.WriteToConsole($"Input Record Count = {records.Count}\r");
Print.PrintDashes();

//Get genres
/*var genreList = CustomLinqQueries.GetGenres(records);
Print.ListOfGenres(genreList);*/



//removes duplicates
var noDuplicates = CommonLinqQueries.RemoveDuplicates<Song>(records);
ConsoleWrite.WriteToConsole("Total after Exact Removing Duplicates: " + noDuplicates.Count.ToString());
var noDuplicatesByName = CustomLinqQueries.RemoveDuplicatesBySongName(records);
ConsoleWrite.WriteToConsole("Total after Duplicates by Song Name: " + noDuplicatesByName.Count.ToString());
Print.PrintDashes();

//retrieves songs from filterMethod

List<Song>? songs = null;
switch (filterMethod.ToLower())
{
    case "artist":
        songs = CustomLinqQueries.GetSongsByArtist(noDuplicatesByName, filterResult.ToString());
        break;
    case "genre":
        songs = CustomLinqQueries.GetSongsByGenre(noDuplicatesByName, filterResult.ToString());
        break;
    case "year":
        songs = CustomLinqQueries.GetSongsByYear(noDuplicatesByName, int.Parse(filterResult.ToString()));
        break;
}

ConsoleWrite.WriteToConsole("Total Songs By Artist: " + songs.Count.ToString());
Print.PrintDashes();

ConsoleWrite.WriteToConsole("Do you want to display the songs by year? (Y/N)\r");
Print.ListOfSongs(songs);
Print.PrintDashes();

ConsoleWrite.WriteToConsole("Do you want to save these songs to csv? (Y/N)\r");
//Output files to a CSV
const string outputPath = "./Output.csv";
CSVWriter.WriteCSVtoPath<Song>(outputPath, noDuplicates);
ConsoleWrite.WriteToConsole("Done");