namespace StreamTracker;

using System;
using System.IO;
using System.Collections.Generic;

public class Helper {


    public static string UserInput(string message) {
        Console.Write(message);
        return Console.ReadLine()!;

    }


    public static List<string> GetList(string filePath, int index)
    {
        //initalize list
        var newList = new List<string>();

        // Read lines
        var lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');
            newList.Add(parts[index]);
    
        }
        
    return newList;
    }

    public static void ProgramsDoNotExist() {
        Console.WriteLine("No programs exist. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();

    }

    public static void ServicesDoNotExist() {
        Console.WriteLine("No streaming services exist. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();

    }








}