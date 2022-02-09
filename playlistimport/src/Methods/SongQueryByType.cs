using utilties;

namespace playlistimport.Methods;

public class SongQueryByType
{
    private IEnumerable<Song>? songQuery;
    public SongQueryByType(List<Song> songs, string type, T value)
    {
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        songQuery = type switch
        {
            "year" => from song in songs
                orderby song.Plays
                where song.GetProperty(type) == new DateOnly(value, 1, 1)
                select song,
            "name" => from song in songs orderby song.Plays where song.GetProperty(type) == value select song,
            "artist" => from song in songs orderby song.Plays where song.GetProperty(type) == value select song,
            _ => songQuery
        };
    }

    public List<Song> AccessList()
    {
        return songQuery.ToList();
    }
}