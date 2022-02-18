// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using playlistimport;
using playlistimport.Utilities;
using Utilities.UserInteraction;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//you will need to run "dotnet add package ConsoleTables" inside the consoleApp2 Project folder or create the project

var filePath = FilePathOperations.GetFilePath(Prints.FilePathRequest(), 
    Prints.DefaultFilePath());

var records = CsvRead.ReadDistinctRecords(filePath, new SongMap());

var songQuery = CustomQueries.SongByYear(records, FilePathOperations.GetInt(Prints.YearRequest(), Prints.DefaultYear()));

CsvWrite.WriteListToCsv(songQuery);