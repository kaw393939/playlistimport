using Utilities;

namespace playlistimport.Utilities;

public class UserInput
{
    public static string GetFilePath()
    {
        Console.WriteLine("Enter The Absolute File Path for the playlist\r");
        var absoluteFilePath = "";
        absoluteFilePath = ConsoleRead.ReadConsole();
        if (absoluteFilePath == "")
        {
            absoluteFilePath = "/Users/Andrey Morales/Desktop/playlistimport1/data/music.csv";
        }

        return absoluteFilePath;
    }

    public static int GetYear()
    {
        ConsoleWrite.WriteToConsole("Enter The year\r");
        var readYear = ConsoleRead.ReadConsole();
        var songYear = 2015;
        if (readYear != String.Empty)
        {
            songYear = int.Parse(readYear);
        }

        return songYear;
    }
}