// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using playlistimport;
using playlistimport.Methods;
using utilties;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import

var file = new GetFilePath(Utilities.ConsoleReadLineWithMessage("Please Enter Absolute The Folder Path for the input file "));
var records = new ReadRecords<Song>(file.DisplayFilePath());

records = Utilities.RemoveDuplicateSongs(records.AccessRecords(), "name");

var type = Utilities.ConsoleReadLineWithMessage("How would you like to filter the songs list?");
var value = Utilities.ConsoleReadLineWithMessage($"Please enter the {type} to filter by:");
var songQuery = new SongQueryByType(records.AccessRecords(), type, value);
    
    
Utilities.WriteToCsv(Utilities.ConsoleReadLineWithMessage("Please Enter Absolute The Folder Path for the output file")+"output.csv",songQuery.AccessList());
Utilities.ConsoleWrite("Done Writing!");