// See https://aka.ms/new-console-template for more information

using Utilities;

var filename = "music.csv";

SongRequestManager.PrintColumnOptions();
SongRequestManager.UserChoosesColumns(filename);

// var records = CsvHandler.Read<Song>(filename);
// CsvHandler.Write<Song>(records, true);

