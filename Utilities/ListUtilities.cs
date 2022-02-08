namespace Utilities;

public static class ListUtilities
{

    /// <summary>
    /// create an empty list 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> CreateListOfType<T>()
    {
        return new List<T>();
    }
    
    /// <summary>
    /// create and return a list with items
    /// </summary>
    /// <param name="items"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> CreateListWithItems<T>(T[] items)
    {
        var newList = CreateListOfType<T>();

        if (items.HasItemsAndNotNull())
            foreach (var item in items)
                newList.Add(item);

        return newList;
    }

    /// <summary>
    /// print each item in a list line by line
    /// </summary>
    /// <param name="items"></param>
    /// <typeparam name="T"></typeparam>
    public static void PrintList<T>(List<T> items)
    {
        items.ForEach(item => Console.WriteLine(item));
    }
    
    /// <summary>
    /// check if source has items within it
    /// </summary>
    /// <param name="source">a list of items</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static bool HasItemsAndNotNull<T>(this IEnumerable<T> source)
    {
        if (source != null && source.Any())
            return true;
        return false;
        
    }           
}