using CsvHelper.Configuration;

namespace Music;
using System.Globalization;
using CsvHelper;


public class PlayList
{
    private static PlayList _uniqueInst;
    private List<Song> _songsList = new List<Song>();
    
    private PlayList(string csvPath)
    {
        // Read songs from CSV
        var reader = new StreamReader(csvPath);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        
        var csv = new CsvReader(reader, config);
        var records = csv.GetRecords<RawSong>();
        foreach (var record in records)
        {
            Song song = TranslateRawSongToSong(record);
            _songsList.Add(song);

        }
    }

    public static PlayList GetInstance(string csvPath)
    {
        if (_uniqueInst == null)
        {
            _uniqueInst = new PlayList(csvPath);
        }

        return _uniqueInst;
    }

    private Song TranslateRawSongToSong(RawSong rawSong)
    {
        Song song = new Song();
        song.Name = rawSong.Name;
        song.Artist = rawSong.Artist;
        song.Genre = rawSong.Genre;
        song.Composer = rawSong.Composer;
        if (rawSong.Plays == "")
        {
            song.Plays = 0;
        }
        else
        {
            song.Plays = Int32.Parse(rawSong.Plays);
        }

        if (rawSong.Year == "")
        {
            song.Year = 0;
        }
        else
        {
            song.Year = Int32.Parse(rawSong.Year);
        }
        return song;
    }

    public List<Song> GetSongsList()
    {
        return _songsList;
    }
}
