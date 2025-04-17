namespace StreamTracker;

using System;
using System.IO;
using Spectre.Console;

public class WhatsNextMgt {
    FileSaver fileSaver;

    public WhatsNextMgt() {
        fileSaver = new FileSaver("whatsnext-list.csv");
    }

    public static void AddNextThree() {
        string nextShowOne, nextShowTwo, nextShowThree;
        string filePath = "program-list.csv";
        string upNextFile = "whatsnext-list.csv";
        File.WriteAllText(upNextFile, string.Empty);
        //begin

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

        //Choose a program to watch first
        nextShowOne = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a program to watch first:")
                .PageSize(10)
                .AddChoices(programs));

        int index = programs.IndexOf(nextShowOne);
        if(season[index]=="0") {
            File.AppendAllText(upNextFile,"Watch First: " +programs[index] + " - " + services[index] + " - " + showMovie[index] + " - " + status[index]+Environment.NewLine);
        }
        else {
            File.AppendAllText(upNextFile,"Watch First: " +programs[index] + " - " + services[index] + " - " + showMovie[index] + " - " + status[index]+ " - s:"+season[index] +" e:"+episode[index]+Environment.NewLine);

        }
        Console.WriteLine(programs[index]+" added. Press any key to continue.");
        Console.ReadKey();

        //Choose a program to watch second
        nextShowTwo = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a program to watch second:")
                .PageSize(10)
                .AddChoices(programs));

        int index2 = programs.IndexOf(nextShowTwo);
        if(season[index2]=="0") {
            File.AppendAllText(upNextFile,"Watch Second: " +programs[index2] + " - " + services[index2] + " - " + showMovie[index2] + " - " + status[index2]+Environment.NewLine);
        }
        else {
            File.AppendAllText(upNextFile,"Watch Second: " +programs[index2] + " - " + services[index2] + " - " + showMovie[index2] + " - " + status[index2]+ " - s:"+season[index2] +" e:"+episode[index2]+Environment.NewLine);

        }
        Console.WriteLine(programs[index2]+" added. Press any key to continue.");
        Console.ReadKey();

        //Choose a program to watch third
        nextShowThree = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a program to watch third:")
                .PageSize(10)
                .AddChoices(programs));

        int index3 = programs.IndexOf(nextShowThree);
        if(season[index3]=="0") {
            File.AppendAllText(upNextFile,"Watch Third: " +programs[index3] + " - " + services[index3] + " - " + showMovie[index3] + " - " + status[index3]);
        }
        else {
            File.AppendAllText(upNextFile,"Watch Third: " +programs[index3] + " - " + services[index3] + " - " + showMovie[index3] + " - " + status[index3]+ " - s:"+season[index3] +" e:"+episode[index3]);

        }
        Console.WriteLine(programs[index3]+" added. Press any key to continue.");
        Console.ReadKey();

        
        
        //end

    }
    

}
