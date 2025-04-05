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
            Console.WriteLine("To enter a new program, type 'program'");
            Console.WriteLine("To see a list of programs, type 'list'");
            Console.WriteLine("If you are finished, type 'quit'");
            Console.WriteLine("Enter your choice here: ");
            mainChoice = Console.ReadLine();

            // 'program' selection
            if(mainChoice == "program") {
                Console.WriteLine("Please enter the program name:");
                programName = Console.ReadLine();
                Console.WriteLine("Have you watched this show? (enter y or n)");
                watchStatus = Console.ReadLine();

                File.AppendAllText("movie-list.txt",programName + ", " + watchStatus + Environment.NewLine);
            }

            // 'list' selection
            else if(mainChoice == "list") {
                Console.WriteLine("You entered 'list'");
                Console.WriteLine();
            }

            // invalid selection
            else if (mainChoice!="quit") {
                Console.WriteLine("'" + mainChoice + "' is an invalid response. Please try again.");
                Console.WriteLine();
            }

        } while(mainChoice!="quit");

        // Message before exiting
        Console.Clear();
        Console.WriteLine("Have a nice day!");
        Console.WriteLine();
        
        
    
    }
}
