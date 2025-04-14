namespace StreamTracker.Tests;

using StreamTracker;

public class FileSaverTests
{
    FileSaver fileSaver;
    

    public FileSaverTests() {
        string listName = "test-list.txt";
        File.Delete(listName);
        fileSaver = new FileSaver(listName);

    }



    [Fact]
    public void Test_FileSaver_AppendListing()
    {
        fileSaver.AppendListing("Hello, World!","y");
        //var contentFromFile = File.ReadAllText(testFileName);
        //Assert.Equal("Hello, World!"+Environment.NewLine,contentFromFile);

    }
}