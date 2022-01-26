// See https://aka.ms/new-console-template for more information

using System.Globalization;
using CsvHelper;

//you will need to run "dotnet add package CsvHelper" inside the consoleApp2 Project folder or create the project
//if you are doing this from scratch or you can create the project with the solution by checking that
//box when you create it and just add it in the project solution directory

//put the path to the file you want to import

var reader = new StreamReader("../../../data/music.csv");
var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
var records = csv.GetRecords<Song>();

foreach (var record in records)
{
    Console.WriteLine(record.Name+" || "+record.Artist);
}

public class Song
{
    public string Name { get; set; }
    public string Artist { get; set; }
    
    public string Composer { get; set; }

    public string Genre { get; set; }
    
    public string Year { get; set; }

    public string Plays { get; set; }

}