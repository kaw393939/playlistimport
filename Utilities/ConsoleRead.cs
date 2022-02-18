namespace Utilities;

public class ConsoleRead
{
    public static string WriteToConsole(string message)
    {
        var userInput = Console.ReadLine();
        return userInput;
    }
}