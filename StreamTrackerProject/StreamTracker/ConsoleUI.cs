namespace StreamTracker;

using Spectre.Console;


public class ConsoleUI {
    FileSaver fileSaver;

    public ConsoleUI() {
        fileSaver = new FileSaver("movie-list.csv");

    }

    public void MainMenu() {
        string mainChoice, programName, watchStatus;
        do {
            
            // Main Menu
            Console.Clear();
            mainChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Main Menu: [green]Choose a number below[/]")
                    //.PageSize(10)
                    //.MoreChoicesText("[grey](Move up and down to reveal more programs)[/]")
                    .AddChoices(new[] {
                        "Enter a new program", "List current programs", "Quit program",
                    }));


            // 'program' selection
            if(mainChoice == "Enter a new program") {
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

            // 'list' selection
            else if(mainChoice == "List current programs") {
                 // Specify the path to your text file
                string fileName = @"movie-list.csv";

                // Check if the file exists
                if (File.Exists(fileName))
                {
                    // Read all lines from the text file
                    //string[] programList = File.ReadAllLines(fileName);

                    // Display each progam
                    
                    ManageCSV managecsv;
                    managecsv = new ManageCSV();
                    managecsv.ReadMovieCSV("movie-list.csv");

                    //foreach (string program in programList)
                    //{
                    //    Console.WriteLine(program);
                        
                    //}
                    
                }
                else
                {
                    Console.WriteLine("No programs exist. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            // invalid selection
            else if (mainChoice!="Quit program") {
                Console.WriteLine("'" + mainChoice + "' is an invalid response. Please try again.");
                Console.WriteLine();
            }

        } while(mainChoice!="Quit program");

        // Message before exiting
        Console.Clear();
        Console.WriteLine("Have a nice day!");
        Console.WriteLine();

    }

    public static string UserInput(string message) {
        Console.Write(message);
        return Console.ReadLine()!;

    }
}