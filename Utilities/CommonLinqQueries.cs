namespace Utilities;

public class CommonLinqQueries
{
    public static List<T>  RemoveDuplicates<T>(List<T> records) {
         List<T> noDuplicates = records.Distinct().ToList();
         return noDuplicates;
    }
}