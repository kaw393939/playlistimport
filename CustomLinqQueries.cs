namespace playlistimport;

public class CustomLinqQueries
{
    public static List<Song> RemoveDuplicatesBySongName(IEnumerable<Song> songs)
    {
        var distinctItems = songs.GroupBy(x => x.Name).Select(y => y.First());
        return distinctItems.ToList();
    }
    public static List<Song> GetSongsByYear(IEnumerable<Song> songs, int songYear)
    {
        var songQuery =
            from song in songs
            orderby song.Plays
            where song.Year == new DateOnly(songYear,1,1)
            select song;
        return songQuery.ToList();
    }
}

