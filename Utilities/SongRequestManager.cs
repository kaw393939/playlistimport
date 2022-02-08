using static Utilities.ListUtilities;

namespace Utilities;

/// <summary>
/// manages logic for reading and writing music data from a csv file
/// </summary>
public class SongRequestManager
{
    /// <summary>
    /// print available options for the user to choose from
    /// </summary>
    public static void PrintColumnOptions()
    {
        var options = CreateListWithItems(new[] {"name", "artist", "composer", "genre", "year", "plays"});
        
        Console.WriteLine("Column Choices");
        Console.WriteLine("--------------");

        PrintList(options);
    }

    /// <summary>
    /// ask the user to enter what columns they want to see and print accordingly
    /// </summary>
    public static void UserChoosesColumns(string filename)
    {
        Console.Write("\nEnter what columns you want to view, seperated by space: ");
        string columnChoices = Console.ReadLine();
        string[] columns = columnChoices.Split(' ');
        
        PrintSelectedData(columns, filename);
    }

    /// <summary>
    /// print data according to desired columns
    /// </summary>
    /// <param name="columns"></param>
    private static void PrintSelectedData(string[] columns, string filename)
    {
        // read file as a csv
        var records = CsvHandler.Read<Song>(filename);

        // print record data according to desired column
        foreach (var record in records)
        {
            foreach (var column in columns)
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
                        Console.Write(record.Composer);
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

/// <summary>
/// representative of 6 of the most "important" columns in a file with song data
/// </summary>
public class Song
{
    public string Name { get; set; }
    public string Artist { get; set; }
    public string Composer { get; set; }
    public string Genre { get; set; }
    public DateOnly Year { get; set; }
    public int Plays { get; set; }
}