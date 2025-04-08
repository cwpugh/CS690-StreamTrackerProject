namespace StreamTracker;

using System.IO;

public class FileSaver {
    string filename;

    public FileSaver(string filename) {
        this.filename = filename;
        File.Create(this.filename).Close();

    }


    public static void AppendListing(string listName, string name, string status) {

        string newStatus;
        if(status.ToLower() == "y") {
            newStatus = "Watched";
            File.AppendAllText(listName,name + ", " + newStatus + Environment.NewLine);
        } else if(status.ToLower() == "n") {
            newStatus = "Not Watched";
            File.AppendAllText(listName,name + ", " + newStatus + Environment.NewLine);
            
        } 
        Console.WriteLine("Program added. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();

    }

    
}