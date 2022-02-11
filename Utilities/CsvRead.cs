﻿using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace playlistimport.Utilities;

public class CsvRead
{
    public static List<T> ReadRecords<T>(string filePath, ClassMap<T> map)
    {
        List<T> records;
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Context.RegisterClassMap(map);
            Console.WriteLine("Reading the CSV File\r");
            records = csv.GetRecords<T>().ToList();
        }

        Console.WriteLine($"Record Count = {records.Count}\r");
        Printables.PrintDashSpacer();
        return records;
    }

    public static List<T> ReadDistinctRecords<T>(string filePath, ClassMap<T> map)
    {
        List<T> records = ReadRecords<T>(filePath, map);
        records = ListOperations.RemoveDuplicates(records);

        Console.WriteLine($"Distinct Record Count = {records.Count}\r");
        Printables.PrintDashSpacer();

        return records;
    }
}