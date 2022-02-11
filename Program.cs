﻿// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using playlistimport;
using playlistimport.Utilities;
using Utilities.UserInteraction;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import

var filePath = FilePathOperations.GetFilePath(Prints.FilePathRequest(), 
    Prints.DefaultFilePath());

var records = CsvRead.ReadDistinctRecords(filePath, new SongMap());

var songQuery = CustomQueries.SongByYear(records, FilePathOperations.GetInt(Prints.YearRequest(), Prints.DefaultYear()));

CsvWrite.WriteListToCsv(songQuery);