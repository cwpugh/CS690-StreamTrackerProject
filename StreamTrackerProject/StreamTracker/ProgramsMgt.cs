namespace StreamTracker;

using System;
using System.IO;

public class ProgramsMgt {
    FileSaver fileSaver;

    public ProgramsMgt() {
        fileSaver = new FileSaver("movie-list.csv");
    }

    public void AddPrograms() {
        string programName, watchStatus;
        programName = UserInput("Please enter the program name: ");
        watchStatus = UserInput("Have you watched this show? (enter y or n) ");
        while(watchStatus.ToLower() != "y" && watchStatus.ToLower()!= "n")
        {
            Console.WriteLine("Invalid choice. Please try again.");
            watchStatus = UserInput("Have you watched this show? (enter y or n) ");
            
        }
        
        fileSaver.AppendListing(programName,watchStatus);
        Console.WriteLine("Program added. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();

    }

    public void ListPrograms(string csvfile){

        //Read, separate, and list all lines in the csv file
        Console.Clear();
        Console.WriteLine("Programs - Status");
        Console.WriteLine("---------------------------------------------");

        var lines = File.ReadAllLines(csvfile);

        for (int i = 0; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');

            string program_name = values[0];
            string status = values[1];

            Console.WriteLine(program_name + " - " + status);
            
        }
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Listing complete. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }

    public static string UserInput(string message) {
        Console.Write(message);
        return Console.ReadLine()!;

    }



}