namespace Music.util;
using ConsoleTables;

public static class SongUtil
{
    public static void PrintSongs(PlayList playList)
    {
        var table = new ConsoleTable("Name", "Artist", "Year");
        foreach (var song in playList.GetSongsList())
        {
            table.AddRow(song.Name, song.Artist, song.Year);
        }
        table.Write();
    }
    
    
}
