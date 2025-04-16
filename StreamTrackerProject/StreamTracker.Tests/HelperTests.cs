namespace StreamTracker.Tests;

using System;
using System.IO;
using StreamTracker;

public class HelperTests
{
    
    public HelperTests() {
    
    }

    [Fact]
    public void Test_Helper_UserInput()
    {
        
        var simInput = new StringReader("Hello, world!");
        Console.SetIn(simInput);
        string inputReturn = Helper.UserInput("Enter a message");
        
        Assert.Equal("Hello, world!",inputReturn);

    }

    [Fact]
    public void Test_GetList()
    {
        var newList = new List<string>();
        string listName = "test-get-list.csv";
        File.Delete(listName);
        File.AppendAllText(listName,"Cindy,pugh,popcorn" + Environment.NewLine);
        newList = Helper.GetList(listName, 0);
        Assert.Equal(["Cindy"],newList);

    }
}