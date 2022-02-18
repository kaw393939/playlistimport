namespace Music;
using ConsoleTables;

public static class SongUtil
{
    public static void PrintSongs(List<Song> songs)
    {
        var table = new ConsoleTable("Name", "Artist");
        foreach (var song in songs)
        {   
            
            table.AddRow(song.Name, song.Artist);
        }
        table.Write();
    }
    
    
}
