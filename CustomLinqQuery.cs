namespace playlistimport;

public class CustomLinqQuery
{
    public static List<Song> GetSongsByYr(List<Song> Songs, int songYr)
    {
        IEnumerable<Song> songQuery =
            from song in Songs
            orderby song.Plays
            where song.Year == new DateOnly(songYr, 1, 1)
            select song;
        return songQuery.ToList();
    }
    
}