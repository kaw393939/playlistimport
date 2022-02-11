using Music.util;

namespace playlistimport;

public class CustomQueries
{
    public static List<Song> SongByYear(List<Song> songs, int year)
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        IEnumerable<Song> songQuery =
            from song in songs
            orderby song.Plays
            where song.Year.Year == year
            select song;

        var songQueryResults = songQuery.ToList();
        //var songCountCount = songQueryResults.Count.ToString();
        //Console.WriteLine(songCountCount);
        TablePrint.PrintSong(songQueryResults);
        return songQueryResults;
    }

}