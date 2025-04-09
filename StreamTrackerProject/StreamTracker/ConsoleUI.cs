namespace StreamTracker;

public class ConsoleUI {
    FileSaver fileSaver;

    public ConsoleUI() {
        fileSaver = new FileSaver("movie-list.txt");

    }

    public void MainMenu() {
        string mainChoice, programName, watchStatus;
        do {
            
            // show basic menu choices
            Console.Clear();
            Console.WriteLine("Main Menu: Choose a number below");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1 - Enter a new program");
            Console.WriteLine("2 - List current programs");
            Console.WriteLine("3 - Quit program");
            Console.Write("Enter your choice here: ");
            mainChoice = Console.ReadLine()!;

            // 'program' selection
            if(mainChoice == "1") {
                programName = UserInput("Please enter the program name: ");
                watchStatus = UserInput("Have you watched this show? (enter y or n) ");
                while(watchStatus.ToLower() != "y" && watchStatus.ToLower()!= "n")
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    watchStatus = UserInput("Have you watched this show? (enter y or n) ");
                    
                }
                
                fileSaver.AppendListing(programName,watchStatus);
            }

            // 'list' selection
            else if(mainChoice == "2") {
                 // Specify the path to your text file
                string fileName = @"movie-list.txt";

                // Check if the file exists
                if (File.Exists(fileName))
                {
                    // Read all lines from the text file
                    string[] programList = File.ReadAllLines(fileName);

                    // Display each progam
                    Console.Clear();
                    Console.WriteLine("Programs");
                    Console.WriteLine("------------------------");
                    foreach (string program in programList)
                    {
                        Console.WriteLine(program);
                        
                        
                    }
                    Console.WriteLine("------------------------");
                    Console.WriteLine("Listing complete. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("No programs exist. Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            // invalid selection
            else if (mainChoice!="3") {
                Console.WriteLine("'" + mainChoice + "' is an invalid response. Please try again.");
                Console.WriteLine();
            }

        } while(mainChoice!="3");

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