namespace Utilities;

public class ListCreation
{
    public static List<T> CreateNewListOfType<T>()
    {
        List<T> list = new List<T>();
        return list;
    }
}