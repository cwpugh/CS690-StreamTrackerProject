namespace StreamTracker;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        string mainChoice;
        string programName, watchStatus;
        do {
            // show basic menu choices
            Console.WriteLine("Main Menu: Choose a number below");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1 - Enter a new program");
            Console.WriteLine("2 - List current programs");
            Console.WriteLine("3 - Quit program");
            Console.Write("Enter your choice here: ");
            mainChoice = Console.ReadLine();

            // 'program' selection
            if(mainChoice == "1") {
                Console.Write("Please enter the program name: ");
                programName = Console.ReadLine();
                Console.Write("Have you watched this show? (enter y or n) ");
                watchStatus = Console.ReadLine();

                File.AppendAllText("movie-list.txt",programName + ", " + watchStatus + Environment.NewLine);
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
                }
                else
                {
                    Console.WriteLine("No programs exist.");
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
