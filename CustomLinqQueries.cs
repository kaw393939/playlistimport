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
    
    public static List<Song> GetSongsByArtist(IEnumerable<Song> songs, string artist)
    {
        var songQuery =
            from song in songs
            orderby song.Plays
            where song.Artist == artist
            select song;
        return songQuery.ToList();
    }
    
    public static List<Song> GetSongsByGenre(IEnumerable<Song> songs, string genre)
    {
        var songQuery =
            from song in songs
            orderby song.Plays
            where song.Genre == genre
            select song;
        return songQuery.ToList();
    }

    public static IEnumerable<string> GetGenres(IEnumerable<Song> songs)
    {
        var genreQuery =
            from song in songs
            group song by song.Genre
            into genres
            select genres;
        return genreQuery.Select(genre => genre.Key).ToList();
    }
}

