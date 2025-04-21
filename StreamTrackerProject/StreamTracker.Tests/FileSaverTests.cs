namespace StreamTracker.Tests;

using StreamTracker;

public class FileSaverTests
{
    FileSaver fileSaver0;
    FileSaver fileSaver;
    FileSaver fileSaver2;
    

    public FileSaverTests() {
        string newFile = "file-test.csv";
        string listName = "test-list.csv";
        string serviceName = "test-service.csv";
        File.Delete(newFile);
        File.Delete(listName);
        File.Delete(serviceName);
        fileSaver0 = new FileSaver(newFile);
        fileSaver = new FileSaver(listName);
        fileSaver2 = new FileSaver(serviceName);

    }


    [Fact]
    public void Test_FileCreation()
    {
        string checkFile = @"file-test.csv";
        bool fileExists = File.Exists(checkFile);
        Assert.True(fileExists);
    }

    [Fact]
    //AppendListing(string name, string streamingService, string showOrMovie, string status, string season, string episode)
    public void Test_FileSaver_AppendListing()
    {
        fileSaver.AppendListing("Hello, World!","Hulu","Movie","y","0","0");
        string fileName = @"test-list.csv"; 
        string contentFromFile = File.ReadAllText(fileName);
        Assert.Equal("Hello, World!,Hulu,Movie,Watched,0,0"+Environment.NewLine,contentFromFile);

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