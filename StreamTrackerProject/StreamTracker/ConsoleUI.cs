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
                StreamingServiceMenu();
                
            }
            
            else if (mainChoice == "What's up Next?") {
                WhatsUpNextMenu();
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
                    .AddChoices(new[] {
                        "Enter a new program", "List current programs", "Edit a program","Choose programs to watch next", "Return to main menu"
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
                string fileName = @"program-list.csv";

                // Check if the file exists
                if (File.Exists(fileName)&& new FileInfo(fileName).Length != 0)
                {
                    // Display each progam
                    ProgramsMgt programlist;
                    programlist = new ProgramsMgt();
                    programlist.ListPrograms(fileName);
                    
                }

                else
                {
                    Helper.ProgramsDoNotExist();
                }
            }
            // edit a program choice
            else if(programs_choice == "Edit a program") {
                // Specify the path to your text file
                string fileName = @"program-list.csv";

                // Check if the file exists
                if (File.Exists(fileName)&& new FileInfo(fileName).Length != 0)
                {
                    // Display each progam
                    ProgramsMgt programedit;
                    programedit = new ProgramsMgt();
                    programedit.EditPrograms(fileName);
                    
                }

                else
                {
                    Helper.ProgramsDoNotExist();
                }
    

            }

            else if(programs_choice == "Choose programs to watch next") {
                string fileName = "program-list.csv";
                if (!File.Exists(fileName)|| new FileInfo(fileName).Length == 0) {
                    Helper.ProgramsDoNotExist();
                    return;
                }

                else{
                    WhatsNextMgt.AddNextThree();
                }


            }    

        } while(programs_choice!="Return to main menu");
    }

    public void StreamingServiceMenu() {
        string services_choice;
        do {
            
            // Streaming Service Menu
            Console.Clear();
            services_choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Streaming Services Menu: [green]Choose a number below[/]")
                    //.PageSize(10)
                    //.MoreChoicesText("[grey](Move up and down to reveal more programs)[/]")
                    .AddChoices(new[] {
                        "Enter a new streaming service", "List current streaming services", "Edit streaming services","Return to main menu"
                    }));


            // 'new service' selection
            if(services_choice == "Enter a new streaming service") {
                StreamingServicesMgt addservice;
                addservice = new StreamingServicesMgt();
                addservice.AddService();

            }

            // 'list' selection
            else if(services_choice == "List current streaming services") {
                // Specify the path to your text file
                string fileName = @"services-list.csv";

                // Check if the file exists and not empty
                if (File.Exists(fileName)&& new FileInfo(fileName).Length != 0)
                {
                    // Display each progam
                    StreamingServicesMgt serviceslist;
                    serviceslist = new StreamingServicesMgt();
                    serviceslist.ListServices("services-list.csv");
                    
                }

                else
                {
                    Helper.ServicesDoNotExist();
                }
            }

            else if (services_choice == "Edit streaming services") {
                // Specify the path to your text file
                string fileName = @"services-list.csv";

                // Check if the file exists and not empty
                if (File.Exists(fileName)&& new FileInfo(fileName).Length != 0) {
                
                    StreamingServicesMgt editservice;
                    editservice = new StreamingServicesMgt();
                    editservice.EditServices(fileName);
                }
                else {
                    Helper.ServicesDoNotExist();
                }
            }

        } while(services_choice!="Return to main menu");
    }



    public void WhatsUpNextMenu() {
        string nextListPath = "whatsnext-list.csv";

        if (File.Exists(nextListPath)&& new FileInfo(nextListPath).Length != 0)
        {
            string content = File.ReadAllText(nextListPath);
            Console.WriteLine("Next shows to watch:");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(content);
            Console.WriteLine("------------------------------------------------------------");
        }
        else
        {
            Console.WriteLine("No programs found.");
        }
        Console.WriteLine("Press and key to continue.");
        Console.ReadKey();
        
    }

    
}