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

void Run()
{
    var file = new GetFilePath(Utilities.ConsoleReadLineWithMessage("Please Enter Absolute The Folder Path for the input file "));
    var records = new ReadRecords<Song>(file.DisplayFilePath());

    records = Utilities.RemoveDuplicateSongs(records.AccessRecords(), "name");

    var songQuery = SongQueryByYear(records.AccessRecords(), GetYear());
    
    
    Utilities.WriteToCsv(Utilities.ConsoleReadLineWithMessage("Please Enter Absolute The Folder Path for the output file")+"output.csv",songQuery);
    Utilities.ConsoleWrite("Done Writing!");
}

List<Song> RemoveDuplicateSongs(List<Song> list)
{
    var distinctItems = list.GroupBy(x => x.Name).Select(y => y.First());
    return distinctItems.ToList();
}

List<Song> SongQueryByYear(List<Song> songs, int year)
{
    //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
    IEnumerable<Song> songQuery =
        from song in songs
        orderby song.Plays
        where song.Year == new DateOnly(year,1,1)
        select song;

    var songQueryResults = songQuery.ToList();
    var songCountCount = songQueryResults.Count.ToString();
    Utilities.ConsoleWrite(songCountCount);
    foreach (Song song in songQueryResults)
    {
        Utilities.ConsoleWrite("{0},{1}, {2}",song.Name,song.Artist, song.Genre);
    }

    return songQueryResults;
}

Run();