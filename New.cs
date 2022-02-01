using System.Globalization;
using CsvHelper;

namespace playlistimport;

public class SongManager
{
    /// <summary>
    /// print available options for the user to choose from
    /// </summary>
    public static void PrintColumnOptions()
    {
        string[] options = { "name", "artist", "composer", "genre", "year", "plays" };

        Console.WriteLine("Column Choices");
        Console.WriteLine("--------------");

        foreach (string option in options)
        {
            Console.WriteLine(option);
        }
    }

    /// <summary>
    /// ask the user to enter what columns they want to see and print accordingly
    /// </summary>
    public static void UserChoosesColumns()
    {
        Console.Write("\nEnter what columns you want to view, seperated by space: ");
        string columnChoices = Console.ReadLine();
        string[] columns = columnChoices.Split(' ');
        
        PrintSelectedData(columns);
    }

    /// <summary>
    /// print data according to desired columns
    /// </summary>
    /// <param name="columns"></param>
    public static void PrintSelectedData(string[] columns)
    {
        // read file as a csv
        const string filePath = "music.csv";
        var reader = new StreamReader(filePath);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        // get a list of records from the data
        IEnumerable<dynamic> records = csv.GetRecords<dynamic>();

        // print record data according to desired column
        foreach (var record in records)
        {
            foreach (string column in columns)
            {
                switch (column)
                {
                    case "name":
                        Console.Write(record.Name);
                        break;
                    case "artist":
                        Console.Write(record.Artist);
                        break;
                    case "composer":
                        Console.Write(record.Compose);
                        break;
                    case "genre":
                        Console.Write(record.Genre);
                        break;
                    case "year":
                        Console.Write(record.Year);
                        break;
                    case "plays":
                        Console.Write(record.Plays);
                        break;
                }
                Console.Write(" | ");
            }
            Console.WriteLine();
        }
    }
}

public class Song
{
    public string Name { get; set; }
    public string Artist { get; set; }
    public string Composer { get; set; }
    public string Genre { get; set; }
    public DateOnly Year { get; set; }
    public int Plays { get; set; }
}