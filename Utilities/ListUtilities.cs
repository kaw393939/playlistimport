using playlistimport;

namespace Utilities;

public class ListUtilities
{
    List<T> CreateNewListOfType<T>()
    {
        List<T> records = new List<T>();
        return records;
    }
    
    //removes duplicates
    var distinctItems = records.GroupBy(x => x.Name).Select(y => y.First());
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
    IEnumerable<Song> songQuery =
        from song in distinctItems
        orderby song.Plays
        where song.Year == new DateOnly(songYear,1,1)
        select song;

}