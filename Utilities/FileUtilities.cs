namespace Utilities;

public class FileUtilities
{
    Console.WriteLine("Enter The Absolute File Path for the playlist\r");
    var absoluteFilePath = "";
    var filePath = Console.ReadLine();
        if (filePath == "") {
        absoluteFilePath = "/Users/kwilliams/RiderProjects/playlistimport/data/music.csv";
    }
}