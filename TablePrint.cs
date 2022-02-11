using playlistimport;

namespace Music.util;
using ConsoleTables;
public static class TablePrint
{
    public static void PrintSong(List<Song> songs)
    {
        var table = new ConsoleTable("Name", "Artist", "Year", "Genre");
        foreach (Song song in songs)
        {
            table.AddRow(song.Name, song.Artist, song.Year.Year, song.Genre);
        }
        table.Write();
    }
}