namespace playlistimport;

public class CustomLinqQueries
{
    public static List<Song> RemoveDuplicatesBySongName(List<Song> Songs)
    {
        var distinctItems = Songs.GroupBy(x => x.Name).Select(y => y.First());
        return distinctItems.ToList();
    }
    public static List<Song> GetSongsByYear(List<Song> Songs, int songYear)
    {
        IEnumerable<Song> songQuery =
            from song in Songs
            orderby song.Plays
            where song.Year == new DateOnly(songYear,1,1)
            select song;
        return songQuery.ToList();
    }
}

