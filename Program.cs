// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using playlistimport;
using Utilities;

//Get the data from the user
var filePath = UserInteractions.GetFilePathFromUser();
var songYear = UserInteractions.GetYearFromUser();

//Read The CSV and Return Songs with the SongMap to correct empty values and convert to correct formats
var records = CsvRead.FromPath<Song, SongMap>(filePath);
ConsoleWrite.WriteToConsole($"Input Record Count = {records.Count}\r");
Print.PrintDashes();

//removes duplicates
var noDuplicates = CommonLinqQueries.RemoveDuplicates<Song>(records);
ConsoleWrite.WriteToConsole("Total after Exact Removing Duplicates: " + noDuplicates.Count.ToString());
var noDuplicatesByName = CustomLinqQueries.RemoveDuplicatesBySongName(records);
ConsoleWrite.WriteToConsole("Total after Duplicates by Song Name: " + noDuplicatesByName.Count.ToString());
Print.PrintDashes();

var songsByYear = CustomLinqQueries.GetSongsByYear(noDuplicatesByName, songYear);
ConsoleWrite.WriteToConsole("Total Songs By Year: " + songsByYear.Count.ToString());
Print.PrintDashes();

ConsoleWrite.WriteToConsole("Do you want to display the songs by year? (Y/N)\r");
Print.ListOfSongs(songsByYear);
Print.PrintDashes();

ConsoleWrite.WriteToConsole("Do you want to save these songs to csv? (Y/N)\r");
//Output files to a CSV
string outputPath = "./Output.csv";
CSVWriter.WriteCSVtoPath<Song>(outputPath, noDuplicates);
ConsoleWrite.WriteToConsole("Done");