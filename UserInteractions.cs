using Utilities;

namespace playlistimport;

public class UserInteractions
{
    public static string GetFilePathFromUser()
    {
        ConsoleWrite.WriteToConsole("Enter The Absolute File Path for the playlist\r");

        var filePath = ConsoleRead.ReadFromConsole();
        if (filePath == string.Empty)
        {
            filePath = "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv";
        }

        return filePath;
    }

    public static string GetFilterMethodFromUser()
    {
        var filterMethods = new List<string>
        {
            "Artist",
            "Year",
            "Genre"
        };
        ConsoleWrite.WriteToConsole("Please choose one of the following...");
       var count = 0;
       foreach (var filter in filterMethods)
       {
           count++;
           ConsoleWrite.WriteToConsole($"[{count}] {filter}");
       }

       var chosenFilter = int.Parse(ConsoleRead.ReadFromConsole());
       if (chosenFilter <= filterMethods.Count && chosenFilter > 0) return filterMethods[chosenFilter - 1];
       ConsoleWrite.WriteToConsole("ERROR: Method choice not found");
       return GetFilterMethodFromUser();
    }

    public static object GetXFromUser(string filterMethod)
    {
        ConsoleWrite.WriteToConsole($"Enter The {filterMethod}\r");
        var result = ConsoleRead.ReadFromConsole();
        var numResult = 0;
        if (int.TryParse(result, out numResult))
        {
            return numResult;
        }
        return result;
    }
    
    public static string GetStringFromUser(string filterMethod)
    {
        ConsoleWrite.WriteToConsole("Enter an artist\r");
        
        var artist = ConsoleRead.ReadFromConsole();
        if (artist == string.Empty)
        {
            artist = "Bruno Mars";
        }

        return artist;
    }
    
    public static int GetIntFromUser(string filterMethod)
    {
        ConsoleWrite.WriteToConsole($"Enter an {filterMethod}\r");
        
        var result = ConsoleRead.ReadFromConsole();
        if (result == string.Empty)
        {
            result = "2001";
        }

        return int.Parse(result);
    }
}