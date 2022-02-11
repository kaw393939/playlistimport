using Utilities;

namespace playlistimport;

public class UserInteractions
{
    public static string GetFilePathFromUser()
    {
        ConsoleWrite.WriteToConsole("Enter The Absolute File Path for the playlist\r");

        var filePath = ConsoleRead.ReadFromConsole();
        if (filePath == string.Empty)
        {
            filePath = "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv";
        }

        return filePath;
    }

    public static int GetYearFromUser()
    {
        ConsoleWrite.WriteToConsole("Enter The year\r");
        
        var songYear = ConsoleRead.ReadFromConsole();
        if (songYear == string.Empty)
        {
            songYear = "2015";
        }

        return int.Parse(songYear);;
    }
    
    public static string GetArtistFromUser()
    {
        ConsoleWrite.WriteToConsole("Enter an artist\r");
        
        var artist = ConsoleRead.ReadFromConsole();
        if (artist == string.Empty)
        {
            artist = "Bruno Mars";
        }

        return artist;
    }
}