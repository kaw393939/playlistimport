using System.Globalization;
using CsvHelper;
namespace utilites;


public class Utilities
{
    public static void ConsoleWrite(dynamic message)
    {
        Console.WriteLine(message);
    }
    public static void ConsoleWrite(dynamic message, params object?[] arg0)
    {
        Console.WriteLine(message, arg0);
    }

    public static string ConsoleReadLine()
    {
        return Console.ReadLine();
    }

    public static string ConsoleReadLineWithMessage(string message)
    {
        ConsoleWrite(message);
        return ConsoleReadLine();
    }

    public static int ToInt(string number)
    {
        return int.Parse(number);
    }

    public static void WriteToCSV(string file, dynamic message)
    {
        using (var writer = new StreamWriter(file))
        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(message);
        }
    }

    public static List<T> CreateNewList<T>()
    {
        List<T> records = new List<T>();
        return records;
    }
}