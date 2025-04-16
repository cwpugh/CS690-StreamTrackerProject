namespace StreamTracker;

using System;
using System.IO;
using Spectre.Console;

public class ProgramsMgt {
    FileSaver fileSaver;

    public ProgramsMgt() {
        fileSaver = new FileSaver("program-list.csv");
    }

    public void AddPrograms() {
        string programName, streamingService, showOrMovie, watchStatus, season, episode;
        programName = UserInput("Please enter the program name: ");

        //Choose a streaming service
        if (!File.Exists("services-list.csv")) {
            Console.WriteLine("You need to choose a streaming service but there are no streaming services in the list");
            Console.WriteLine("Please go back the main menu to add a streaming service");
            Console.WriteLine("Press any key to coninue");
            Console.ReadKey();
            return;
        }
        else{
            List<string> streamingList = GetStreamingServices();
            streamingService = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose a streaming service:")
                    .PageSize(10)
                    .AddChoices(streamingList)
            );
        }    

        //Enter if it is a show or a movie
        showOrMovie = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Is this a show or a movie?")
                    .AddChoices(new[] {
                        "Show", "Movie"
                    }));

        watchStatus = UserInput("Have you completely watched this show? (enter y or n) ");
        while(watchStatus.ToLower() != "y" && watchStatus.ToLower()!= "n")
        {
            Console.WriteLine("Invalid choice. Please try again.");
            watchStatus = UserInput("Have you completely watched this show? (enter y or n) ");
            
        }

        //if not completely watched and the program is a show, ask for season and episode numbers
        if (watchStatus.ToLower()== "n" && showOrMovie == "Show") {
            season = UserInput("What number season are you currently watching? ");
            episode = UserInput("What is the number of the last episode you watched? ");

        }
        else {
            season = "0";
            episode = "0";

        }
        

        fileSaver.AppendListing(programName, streamingService, showOrMovie, watchStatus, season, episode);
        Console.WriteLine("Program added. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();

    }

    public void ListPrograms(string csvfile){

        //Read, separate, and list all lines in the csv file
        Console.Clear();
        Console.WriteLine("Programs - Streaming Service - Movie/Show - Status");
        Console.WriteLine("-------------------------------------------------------");

        var lines = File.ReadAllLines(csvfile);

        for (int i = 0; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');

            string program_name = values[0];
            string service = values[1];
            string showOrMovie = values[2];
            string status = values[3];
            string season = values[4];
            string episode = values[5];

            if(season == "0") {
                Console.WriteLine(program_name + " - " + service + " - " + showOrMovie + " - " + status);

            }
            else {
                Console.WriteLine(program_name + " - " + service + " - " + showOrMovie + " - " + status + " - s:"+season +" e:"+episode);
            }
            
            
        }
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine("Listing complete. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }

    static List<string> GetStreamingServices()
    {
        string filePath = "services-list.csv";
        //initalize list
        var streamingList = new List<string>();

        // Read lines
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');
            if (parts.Length == 2)
            {
                streamingList.Add(parts[0]);
                
            }
        }
        
        return streamingList;
    } 

    public static string UserInput(string message) {
        Console.Write(message);
        return Console.ReadLine()!;

    }

}