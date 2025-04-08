namespace StreamTracker;

public class ConsoleUI {
    FileSaver fileSaver;

    public ConsoleUI() {
        fileSaver = new FileSaver("movie-list.txt");

    }

    public string MainMenu() {
        // show basic menu choices
        Console.WriteLine("Main Menu: Choose a number below");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("1 - Enter a new program");
        Console.WriteLine("2 - List current programs");
        Console.WriteLine("3 - Quit program");
        Console.Write("Enter your choice here: ");
        return Console.ReadLine()!;
        
    }

    public static string UserInput(string message) {
        Console.Write(message);
        return Console.ReadLine()!;

    }
}