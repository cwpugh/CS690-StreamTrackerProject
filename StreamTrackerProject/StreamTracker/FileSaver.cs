namespace StreamTracker;

using System.IO;

public class FileSaver {
    string filename;

    public FileSaver(string filename) {
        this.filename = filename;
        File.Create(this.filename).Close();

    }


    public void AppendListing(string name, string status) {

        string newStatus;
        if(status.ToLower() == "y") {
            newStatus = "Watched";
            File.AppendAllText(filename,name + ", " + newStatus + Environment.NewLine);
        } else if(status.ToLower() == "n") {
            newStatus = "Not Watched";
            File.AppendAllText(filename,name + ", " + newStatus + Environment.NewLine);
            
        } 

    }

    
}