// See https://aka.ms/new-console-template for more information

using playlistimport;
using Utilities;

var keepRunning = true;

while (keepRunning)
{
    run.Run();
    var validInput = false;
    while (!validInput)
    {
        switch (ConsoleRead.ReadFromConsole("Do you want to run again? [Y \\ N]").ToLower())
        {
            case "y":
            {
                validInput = true;
                keepRunning = true;
                break;
            }
            case "n":
            {
                validInput = true;
                keepRunning = false;
                ConsoleWrite.WriteToConsole("Good bye!");
                break;
            }
            default:
            {
                ConsoleWrite.WriteToConsole("ERROR: Invalid Input\nPlease try again...");
                break;
            }
        }

    }

}

