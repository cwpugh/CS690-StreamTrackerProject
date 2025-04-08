namespace StreamTracker;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string mainChoice, programName, watchStatus;
        
        do {

            //get choice from MainMenu
            ConsoleUI mainUI = new ConsoleUI();
            mainChoice = mainUI.MainMenu();
        

            // 'program' selection
            if(mainChoice == "1") {
                programName = UserInput("Please enter the program name: ");
                watchStatus = UserInput("Have you watched this show? (enter y or n) ");
                while(watchStatus.ToLower() != "y" && watchStatus.ToLower()!= "n")
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    watchStatus = UserInput("Have you watched this show? (enter y or n) ");
                    
                }
                
                AppendListing("movie-list.txt",programName,watchStatus);
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
 
}
