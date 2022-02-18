using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;


namespace Music;

public class UserInteraction
{
    public static List<Song> GetSongsFromInput()
    {
        Console.WriteLine("Enter the path to your play list");
        bool noPath = true;
        List<Song> resultList = null;
        while (noPath)
        {
            var userInput = Console.ReadLine();
            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Your path is empty; please input again");
                continue;
            }

            try
            {
                resultList = CsvRead.FromPath<Song, SongMap>(userInput);
                noPath = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Csv file not found");
                continue;
            }
        }

        List<Song> noDupResultList = resultList.Distinct().ToList();
        return noDupResultList;
    }

    public static int GetYearFromInput()
    {
        bool noPassed = true;
        int resultYear = 0;
        Console.WriteLine("Input the year for search");
        while (noPassed)
        {
            var userInput = Console.ReadLine();
            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Your path is empty; please input again");
                continue;
            }

            try
            {
                int year = int.Parse(userInput);
                resultYear = year;
                noPassed = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("You should input a number");
            }
            
        }

        return resultYear;
    }

    public static void writeToCsvFileByUserInputFilePath(List<Song> songs)
    {
        bool notPassed = true;
        Console.WriteLine("Where do you want to save your result");
        while (notPassed)
        {
            var userInput = Console.ReadLine();
            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Your path is empty; please input again");
                continue;
            }

            try
            {
                CsvWrite.WriteCSVtoPath<Song>(userInput, songs);
                notPassed = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("I cannot access your path");
                continue;
            }
        }
    }
}