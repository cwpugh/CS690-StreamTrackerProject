namespace StreamTracker.Tests;

using StreamTracker;

public class FileSaverTests
{
    FileSaver fileSaver;
    

    public FileSaverTests() {
        string listName = "test-list.csv";
        File.Delete(listName);
        fileSaver = new FileSaver(listName);

    }



    [Fact]
    public void Test_FileSaver_AppendListing()
    {
        fileSaver.AppendListing("Hello, World!","y");
        string fileName = @"test-list.csv"; 
        string contentFromFile = File.ReadAllText(fileName);
        Assert.Equal("Hello, World!,Watched"+Environment.NewLine,contentFromFile);

    }
}