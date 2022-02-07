using Utilities;

namespace playlistimport;

public class UserInteractions
{
    public static string GetFilePathFromUser()
    {
        ConsoleWrite.WriteToConsole("Enter The Absolute File Path for the playlist\r");

        var filePath = ConsoleRead.ReadFromConsole();
        if (filePath == String.Empty)
        {
            filePath = "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv";
        }

        return filePath;
    }

    public static int GetYearFromUser()
    {
        ConsoleWrite.WriteToConsole("Enter The year\r");
        
        var songYear = ConsoleRead.ReadFromConsole();
        if (songYear == String.Empty)
        {
            songYear = "2015";
        }

        return int.Parse(songYear);;
    }
}