using CsvHelper.Configuration.Attributes;

namespace Music;


public class RawSong
{
    
    [Name("Name")]
    public string Name { get; set; }
    
    [Name("Artist")]
    public string Artist { get; set; }
    
    [Name("Composer")]
    public string Composer { get; set; }
    
    [Name("Album")]
    public string Album { get; set; }
    
    [Name("Grouping")]
    public string Grouping { get; set; }
    
    [Name("Work")]
    public string Work { get; set; }

    [Name("Genre")]
    public string Genre { get; set; }
    
    [Name("Year")]
    public string Year { get; set; }

    [Name("Plays")]
    public string Plays { get; set; }
    
    

}

public class Song
{
    public string Name { get; set; }
    public string Artist { get; set; }
    
    public string Composer { get; set; }
    
    public string Genre { get; set; }
    
    public int Year { get; set; }

    public int Plays { get; set; }

}