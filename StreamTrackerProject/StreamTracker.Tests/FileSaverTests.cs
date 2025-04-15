namespace StreamTracker.Tests;

using StreamTracker;

public class FileSaverTests
{
    FileSaver fileSaver;
    FileSaver fileSaver2;
    

    public FileSaverTests() {
        string listName = "test-list.csv";
        string serviceName = "test-service.csv";
        File.Delete(listName);
        File.Delete(serviceName);
        fileSaver = new FileSaver(listName);
        fileSaver2 = new FileSaver(serviceName);

    }



    [Fact]
    public void Test_FileSaver_AppendListing()
    {
        fileSaver.AppendListing("Hello, World!","y");
        string fileName = @"test-list.csv"; 
        string contentFromFile = File.ReadAllText(fileName);
        Assert.Equal("Hello, World!,Watched"+Environment.NewLine,contentFromFile);

    }

    [Fact]
    public void Test_FileSaver_AppendService()
    {
        fileSaver2.AppendService("Hello, World!","Yes");
        string fileName = @"test-service.csv"; 
        string contentFromFile = File.ReadAllText(fileName);
        Assert.Equal("Hello, World!,Subscribed"+Environment.NewLine,contentFromFile);

    }
}