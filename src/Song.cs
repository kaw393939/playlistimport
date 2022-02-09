namespace Music;

public class RawSong
{
    public string Name { get; set; }
    public string Artist { get; set; }
    
    public string Composer { get; set; }
    
    public string Album { get; set; }
    
    public string Grouping { get; set; }
    
    public string Work { get; set; }

    public string Genre { get; set; }
    
    public string Year { get; set; }

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