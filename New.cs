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
        
    }
}