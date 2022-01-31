namespace playlistimport;

public class SongManager
{
    /* create a menu of available columns
     * ask user to enter what columns they want top see
     * present the columns asked to the user
     */
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

    public static void UserChoosesColumns()
    {
        Console.WriteLine("Enter what columns you want to view, seperated by space: ");
        string columnChoices = Console.ReadLine();
        string[] columns = columnChoices.Split(' ');
        
        PrintSelectedData(columns);
    }

    public static void PrintSelectedData(string[] columns)
    {
        const string filePath = "music.csv";
        var reader = new StreamReader(filePath);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        Console.WriteLine("Filepath: " + AppDomain.CurrentDomain.BaseDirectory);

        IEnumerable<dynamic> records = csv.GetRecords<dynamic>();

// records = csv.GetRecord<dynamic>();

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
                        Console.Write(record.Name);
                        break;
                    case "composer":
                        Console.Write(record.Name);
                        break;
                    case "genre":
                        Console.Write(record.Name);
                        break;
                    case "year":
                        Console.Write(record.Name);
                        break;
                    case "plays":
                        Console.Write(record.Name);
                        break;
                }
                Console.WriteLine();
            }
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