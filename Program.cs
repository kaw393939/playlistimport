using Music;
using Music.util;
namespace playlistimport;
class Entry
{
    static void Main(string[] args)
    {
        string csvPath = args[0];
        PlayList playList = PlayList.GetInstance(csvPath);
        SongUtil.PrintSongs(playList);
    }
}