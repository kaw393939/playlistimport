using System.Text;
using Utilities;

namespace playlistimport;

public class Print
{
    public static void ListOfSongs(List<Song> songQueryResults)
    {
        foreach (Song song in songQueryResults)
        {
  
            StringBuilder text = new StringBuilder(song.Name + " " + song.Artist + " " +  song.Genre);
            ConsoleWrite.WriteToConsole(text.ToString());
        }
    }
    public static void PrintDashes()
    {
        ConsoleWrite.WriteToConsole("_____________________________\r");

    }
}