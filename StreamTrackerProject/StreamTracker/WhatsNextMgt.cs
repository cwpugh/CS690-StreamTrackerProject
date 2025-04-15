namespace StreamTracker;

public class WhatsNextMgt {
    FileSaver fileSaver;

    public WhatsNextMgt() {
        fileSaver = new FileSaver("whatsnext-list.csv");
    }

}
