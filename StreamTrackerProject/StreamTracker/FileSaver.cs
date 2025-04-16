namespace StreamTracker;

using System.IO;

public class FileSaver {
    string filename;

    public FileSaver(string filename) {
        this.filename = filename;
        if (!File.Exists(filename)) {
            File.Create(this.filename).Close();
        }
    }

//name, streamingService, showOrMovie, status, season, episode
    public void AppendListing(string name, string streamingService, string showOrMovie, string status, string season, string episode) {

        string newStatus;
        if(status.ToLower() == "y") {
            newStatus = "Watched";
            File.AppendAllText(filename,name + "," + streamingService + "," + showOrMovie + "," + newStatus + ","+ season + "," + episode +Environment.NewLine);
        } else if(status.ToLower() == "n") {
            newStatus = "Not Watched";
            File.AppendAllText(filename,name + "," + streamingService + "," + showOrMovie + "," + newStatus + ","+ season + "," + episode +Environment.NewLine);

        }
        
    }

    public void AppendService(string service, string subscription) {

        string newSub;
        if(subscription == "Yes") {
            newSub = "Subscribed";
            File.AppendAllText(filename,service + "," + newSub + Environment.NewLine);
        } else if(subscription == "No") {
            newSub = "Not Subscribed";
            File.AppendAllText(filename,service + "," + newSub + Environment.NewLine);
            
        }
            
    }

 
}