// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;
using playlistimport;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory
//put the path to the file you want to import

void Run()
{
    var records = ReadRecords(GetFilePath());
    var songQuery = SongQueryByYear(records, GetYear());
    WriteSongListToCsv(songQuery);
}

string GetFilePath()
{
    Console.WriteLine("Enter The Absolute File Path for the playlist\r");
    var filePath = Console.ReadLine();
    return string.IsNullOrEmpty(filePath) ? "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv" : filePath;
}

int GetYear()
{
    Console.WriteLine("Enter The year\r");
    var readYear = Console.ReadLine();
    return !string.IsNullOrEmpty(readYear) ? int.Parse(readYear) : 2015;
}

List<Song> ReadRecords(string filePath)
{
    List<Song> records;
    using (var reader = new StreamReader(filePath))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        csv.Context.RegisterClassMap<SongMap>();
        Console.WriteLine("Reading the CSV File\r");
        records = csv.GetRecords<Song>().ToList();
    }

    Console.WriteLine($"Record Count = {records.Count}\r");
    Console.WriteLine("_____________________________\r");

    records = RemoveDuplicateSongs(records);
    
    Console.WriteLine($"Distinct Record Count = {records.Count}\r");
    Console.WriteLine("_____________________________\r");

    return records;
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
    Console.WriteLine(songCountCount);
    foreach (Song song in songQueryResults)
    {
        Console.WriteLine("{0},{1}, {2}",song.Name,song.Artist, song.Genre);
    }

    return songQueryResults;
}

void WriteSongListToCsv(List<Song> songs)
{
    using (var writer = new StreamWriter("./Output.csv"))
    using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
    {
        csvWriter.WriteRecords(songs);
    }
    Console.WriteLine("Done Writing");
}

Run();