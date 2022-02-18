using System.Runtime.CompilerServices;
using Music;
using CsvHelper;

namespace Music;
class Entry
{
    static void Main(string[] args)
    {
        List<Song> songs = UserInteraction.GetSongsFromInput();
        int yearOfSearch = UserInteraction.GetYearFromInput();
        List<Song> songsInThatYear = GetSongByYear.GetSongsByYear(songs, yearOfSearch);
        SongUtil.PrintSongs(songsInThatYear);
        UserInteraction.writeToCsvFileByUserInputFilePath(songsInThatYear);
    }
}