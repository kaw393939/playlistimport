using playlistimport;

namespace playlistimport.Utilities;

public class ListUtilities
{
    List<T> CreateNewListOfType<T>()
    {
        List<T> records = new List<T>();
        return records;
    }

    //removes duplicates
    public static List<T> RemoveDuplicates<T>(List<T> list)
    {
        var distinctItems = list.Distinct().ToList();
        return distinctItems;
    }
}

  