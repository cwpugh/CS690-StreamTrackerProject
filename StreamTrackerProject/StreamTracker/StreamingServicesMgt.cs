namespace StreamTracker;

public class StreamingServicesMgt {
    FileSaver fileSaver;

    public StreamingServicesMgt() {
        fileSaver = new FileSaver("services-list.csv");
    }

    public void AddService() {

    }


    public static string UserInput(string message) {
        Console.Write(message);
        return Console.ReadLine()!;

    }
}
