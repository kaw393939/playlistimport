﻿namespace playlistimport.Utilities;

public static class Prints
{
    public static void PrintDashSpacer()
    {
        Console.WriteLine("_____________________________\r");
    }
    public static string DefaultFilePath()
    {
        return "/Users/mandd/RiderProjects/playlistimport/data/music.csv";
    }
    public static string FilePathRequest()
    {
        return "Enter The Absolute File Path for the playlist\r";
    }

    public static string YearRequest()
    {
        return "Enter The year\r";
    }

    public static int DefaultYear()
    {
        return 2015;
    }
}