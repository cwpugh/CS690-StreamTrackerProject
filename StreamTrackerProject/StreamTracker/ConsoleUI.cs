namespace StreamTracker;

using Spectre.Console;


public class ConsoleUI {
    

    public ConsoleUI() {
        

    }

    public void MainMenu() {
        string mainChoice;
        do {
            
            // Main Menu
            Console.Clear();
            mainChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Main Menu: [green]Choose a number below[/]")
                    //.PageSize(10)
                    //.MoreChoicesText("[grey](Move up and down to reveal more programs)[/]")
                    .AddChoices(new[] {
                        "Programs", "Streaming Services", "What's up Next?","Quit program",
                    }));


            // 'program' selection
            if(mainChoice == "Programs") {
                ProgramsMenu();
                
            }

            // 'streaming services' selection
            else if(mainChoice == "Streaming Services") {
                Console.WriteLine("Feature under development");
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
                
            }

            
            else if (mainChoice == "What's up Next?") {
                Console.WriteLine("Feature under development");
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
            }

        } while(mainChoice!="Quit program");

        // Message before exiting
        Console.Clear();
        Console.WriteLine("Have a nice day!");
        Console.WriteLine();

    }


    public void ProgramsMenu() {
        string programs_choice;
        do {
            
            // Programs Menu
            Console.Clear();
            programs_choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Programs Menu: [green]Choose a number below[/]")
                    //.PageSize(10)
                    //.MoreChoicesText("[grey](Move up and down to reveal more programs)[/]")
                    .AddChoices(new[] {
                        "Enter a new program", "List current programs", "Watch Next", "Return to main menu"
                    }));


            // 'new program' selection
            if(programs_choice == "Enter a new program") {
                ProgramsMgt addprogram;
                addprogram = new ProgramsMgt();
                addprogram.AddPrograms();
                

            }

            // 'list' selection
            else if(programs_choice == "List current programs") {
                 // Specify the path to your text file
                string fileName = @"movie-list.csv";

                // Check if the file exists
                if (File.Exists(fileName))
                {
                    // Display each progam
                    ProgramsMgt programlist;
                    programlist = new ProgramsMgt();
                    programlist.ListPrograms("movie-list.csv");
                    
                }
                else
                {
                    Console.WriteLine("No programs exist. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            else if(programs_choice == "Watch Next") {
                Console.WriteLine("Feature under development");
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();

            }    


        } while(programs_choice!="Return to main menu");

        // Return to Main Menu
        MainMenu();


    }

    public void StreamingServiceMenu() {

    }

    public void WhatsUpNextMenu() {

    }
}