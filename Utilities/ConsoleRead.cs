namespace Utilities;

public class ConsoleRead
{
    public static string ReadFromConsole()
    {
        var userInput = Console.ReadLine();
        return userInput;
    }

    public static string ReadFromConsole(string message)
    {
        ConsoleWrite.WriteToConsole(message);
        var userInput = Console.ReadLine();
        return userInput;
    }
}

