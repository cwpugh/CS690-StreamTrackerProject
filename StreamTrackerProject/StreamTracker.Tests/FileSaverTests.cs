namespace StreamTracker.Tests;

using StreamTracker;

public class FileSaverTests
{
    FileSaver fileSaver;
    

    public FileSaverTests() {
        string listName = "test-list.txt";
        fileSaver = new FileSaver(listName);

    }



    [Fact]
    public void TestAppendListing()
    {

    }
}