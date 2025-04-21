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
        programName = Helper.UserInput("Please enter the program name: ");

        //Choose a streaming service
        string fileName = "services-list.csv";
        if (!File.Exists(fileName)|| new FileInfo(fileName).Length == 0) {
            Console.WriteLine("You need to choose a streaming service but there are no streaming services in the list");
            Console.WriteLine("Please go back the main menu to add a streaming service");
            Console.WriteLine("Press any key to coninue");
            Console.ReadKey();
            return;
        }
        else{
            List<string> streamingList = Helper.GetList(fileName,0);
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

        watchStatus = Helper.UserInput("Have you completely watched this show? (enter y or n) ");
        while(watchStatus.ToLower() != "y" && watchStatus.ToLower()!= "n")
        {
            Console.WriteLine("Invalid choice. Please try again.");
            watchStatus = Helper.UserInput("Have you completely watched this show? (enter y or n) ");  
        }

        //if not completely watched and the program is a show, ask for season and episode numbers
        if (watchStatus.ToLower()== "n" && showOrMovie == "Show") {
            season = Helper.UserInput("What number season are you currently watching? ");
            episode = Helper.UserInput("What is the number of the last episode you watched? ");
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

    public void EditPrograms(string csvfile){

        string filePath = csvfile;

        // Initialize lists
        var programs = new List<string>();
        var services = new List<string>();
        var showMovie = new List<string>();
        var status = new List<string>();
        var season = new List<string>();
        var episode = new List<string>();
        
        // Read lines
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');
            programs.Add(parts[0]);
            services.Add(parts[1]);
            showMovie.Add(parts[2]);
            status.Add(parts[3]);
            season.Add(parts[4]);
            episode.Add(parts[5]);	     
        }
        
        //Choose a program to edit
        var programToEdit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a program to edit:")
                .PageSize(10)
                .AddChoices(programs));

        int index = programs.IndexOf(programToEdit);
        string changeValue;
        
        do{
            Console.Clear();
            if(season[index]=="0") {
                Console.WriteLine("Current Information: " +programs[index] + " - " + services[index] + " - " + showMovie[index] + " - " + status[index]);
            }
            else {
                Console.WriteLine("Current Information: " +programs[index] + " - " + services[index] + " - " + showMovie[index] + " - " + status[index]+ " - s:"+season[index] +" e:"+episode[index]);

            }
            Console.WriteLine();

            changeValue = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("What do you want to change?")
                .PageSize(10)
                .AddChoices("Program Name", "Streaming Service", "Show or Movie", "Watch Status", "Current Season and Episode", "Return to Programs Menu"));

            //change program name
            if (changeValue == "Program Name") {
                string newName = Helper.UserInput("What is the new program name? ");
                programs[index] = newName;
            }

            //change streaming service
            else if (changeValue == "Streaming Service") {
                //get list of streaming services
                var serviceList = Helper.GetList("services-list.csv",0);
                string newService = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose streaming service:")
                    .PageSize(10)
                    .AddChoices(serviceList));
                services[index] = newService;
            }

            //change movie or show
            else if (changeValue == "Show or Movie") {
                string newShowMovie = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Is this a show or a movie?")
                    .AddChoices("Show", "Movie"));
                showMovie[index] = newShowMovie;
            }

            //change complete watch status
            else if (changeValue == "Watch Status") {

                string updatedStatus = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Have you completely watched this show/movie?")
                    .AddChoices("Watched", "Not Watched"));
                status[index] = updatedStatus;
            }

            //change season and episode
            else if (changeValue == "Current Season and Episode") {
                string updatedSeason = Helper.UserInput("What season are you watching? ");
                string updatedEpisode = Helper.UserInput("What was the last episode watched? ");
                season[index] = updatedSeason;
                episode[index] = updatedEpisode;
            }

            //save changes back to file
            using (var writer = new StreamWriter(filePath))
            {
                // Join and write rows
                for (int i = 0; i < services.Count && i < status.Count; i++)
                {
                    writer.WriteLine($"{programs[i]},{services[i]},{showMovie[i]},{status[i]},{season[i]},{episode[i]}");
                }
            }

        } while (changeValue!="Return to Programs Menu");
    }
}