namespace StreamTracker;

using Spectre.Console;
using System;
using System.IO;
using System.Collections.Generic;

public class StreamingServicesMgt {
    FileSaver fileSaver;

    public StreamingServicesMgt() {
        fileSaver = new FileSaver("services-list.csv");
        
    }

    public void AddService() {
        string service, subscription;
        service = Helper.UserInput("Enter the name of the streaming service: ");
        subscription = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Do you have a current subscription?")
                .AddChoices("Yes", "No"));
        fileSaver.AppendService(service,subscription);
        Console.WriteLine("Service added. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
        

    }

    public void ListServices(string csvfile){

        //Read, separate, and list all lines in the csv file
        Console.Clear();
        Console.WriteLine("Services - Subscription Status");
        Console.WriteLine("---------------------------------------------");

        var lines = File.ReadAllLines(csvfile);

        for (int i = 0; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');

            string service_name = values[0];
            string subscription = values[1];

            Console.WriteLine(service_name + " - " + subscription);
            
        }
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Listing complete. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }

    public void EditServices(string csvfile){

        string filePath = csvfile;

        // Initialize lists
        var services = new List<string>();
        var status = new List<string>();
        

        // Read lines
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');
            if (parts.Length == 2)
            {
                services.Add(parts[0]);
                status.Add(parts[1]);
                
            }
        }
        //Choose a service to edit
        var serviceToEdit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a service to edit:")
                .PageSize(10)
                .AddChoices(services)
        );
        int index = services.IndexOf(serviceToEdit);
        string newName = Helper.UserInput("What is the new name? ");
        string updatedStatus = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Do you have a current subscription?")
                .AddChoices("Subscribed", "Not Subscribed"));

        services[index] = newName;
        status[index] = updatedStatus;

        using (var writer = new StreamWriter(filePath))
        {
            // Join and write rows
            for (int i = 0; i < services.Count && i < status.Count; i++)
            {
                writer.WriteLine($"{services[i]},{status[i]}");
            }
        }


    }

}
