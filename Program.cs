// See https://aka.ms/new-console-template for more information

using Utilities;

// files must be copied to output directory so they can be referred to by relative path
var filename = "music.csv";

Console.WriteLine($"Hello {filename}");

SongRequestManager.PrintColumnOptions();
SongRequestManager.UserChoosesColumns(filename);

// var records = CsvHandler.Read<Song>(filename);
// CsvHandler.Write<Song>(records, true);

