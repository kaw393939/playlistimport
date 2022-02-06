namespace Utilities;

public static class ListUtilities
{

    public static List<T> CreateListOfType<T>()
    {
        return new List<T>();
    }
    
    public static List<T> CreateListWithItems<T>(T[] items)
    {
        var newList = CreateListOfType<T>();

        if (!items.HasItemsAndNotNull())
            foreach (var item in items)
                newList.Add(item);

        return newList;
    }

    public static void PrintList<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    
    public static bool HasItemsAndNotNull<T>(this IEnumerable<T> source)
    {
        if (source != null && source.Any())
            return true;
        return false;
        
    }           
}