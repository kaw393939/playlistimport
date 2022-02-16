using Utilities;
namespace playlistimport;

public class run
{
    public static void Run()
    {
        

//Get the data from the user
        var filePath = UserInteractions.GetFilePathFromUser();
        var filterMethod = UserInteractions.GetFilterMethodFromUser();





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

//retrieves songs from filterMethod

        if (filterMethod.ToLower() == "genre")
        {
            //Get genres
            var genreList = CustomLinqQueries.GetGenres(records);
            Print.ListOfGenres(genreList);
        }

        var filterResult = UserInteractions.GetXFromUser(filterMethod);

        var songs = filterMethod.ToLower() switch
        {
            "artist" => CustomLinqQueries.GetSongsByArtist(noDuplicatesByName, filterResult.ToString()!),
            "genre" => CustomLinqQueries.GetSongsByGenre(noDuplicatesByName, filterResult.ToString()!),
            "year" => CustomLinqQueries.GetSongsByYear(noDuplicatesByName, int.Parse(filterResult.ToString()!)),
            _ => null
        };

        ConsoleWrite.WriteToConsole("Total Songs By "+filterMethod.ToLower()+": " + songs.Count.ToString());
        Print.PrintDashes();

        ConsoleWrite.WriteToConsole("Do you want to display the songs by "+filterMethod.ToLower()+"? (Y/N)\r");
        if (ConsoleRead.ReadFromConsole() == "Y")
        {
            Print.ListOfSongs(songs);
            Print.PrintDashes();
        }


        ConsoleWrite.WriteToConsole("Do you want to save these songs to csv? (Y/N)\r");
//Output files to a CSV
        if (ConsoleRead.ReadFromConsole() == "Y")
        {
            const string outputPath = "./Output.csv";
            CSVWriter.WriteCSVtoPath<Song>(outputPath, noDuplicates);
        }

        ConsoleWrite.WriteToConsole("Done");
        Print.PrintDashes();
    }
}