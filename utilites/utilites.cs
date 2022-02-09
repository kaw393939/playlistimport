using System.Globalization;
using CsvHelper;
namespace utilties;


public static class Utilities
{
    public static void ConsoleWrite(dynamic message)
    {
        Console.WriteLine(message);
    }
    public static void ConsoleWrite(dynamic message, params object?[] arg0)
    {
        Console.WriteLine(message, arg0);
    }

    public static string? ConsoleReadLine()
    {
        return Console.ReadLine();
    }

    public static string? ConsoleReadLineWithMessage(string message)
    {
        ConsoleWrite(message);
        return ConsoleReadLine();
    }
    
    public static int ToInt(string number)
    {
        return int.Parse(number);
    }

    public static void WriteToCsv(string file, dynamic message)
    {
        using (var writer = new StreamWriter(file))
        using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csvWriter.WriteRecords(message);
        }
    }
    
    public static object? GetProperty(this object? source, string name) {
        if (source == null) return null;
        var pi = source.GetType().GetProperty(name);
        if (pi == null) return null;
        return pi.GetValue(source);
    }
    
    public static IEnumerable<T> RemoveDuplicateSongs<T>(IEnumerable<T> list, string type)
    {
        return list.GroupBy(x => x.GetProperty(type)).Select(y => y.First());
    }
}