namespace Music;

public class GetSongByYear
{
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