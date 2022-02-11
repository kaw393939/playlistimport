namespace Utilities.UserInteraction;

public class FilePathOperations
{
    public static string GetFilePath(string message, string defaultValue)
    {
        Console.WriteLine(message);
        var filePath = Console.ReadLine();
        return string.IsNullOrEmpty(filePath) ? defaultValue : filePath;
    }
    public static int GetInt(string message, int defaultValue)
    {
        Console.WriteLine(message);
        var readYear = Console.ReadLine();
        return !string.IsNullOrEmpty(readYear) ? int.Parse(readYear) : defaultValue;
    }
}
