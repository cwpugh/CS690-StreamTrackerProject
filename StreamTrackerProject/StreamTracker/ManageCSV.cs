namespace StreamTracker;

using System;
using System.IO;

public class ManageCSV {
    
    public ManageCSV() {

    }

    public void ReadMovieCSV(string csvfile){

        //Read and separate all lines in the csv file
        Console.Clear();
        Console.WriteLine("Programs - Status");
        Console.WriteLine("------------------------");

        var lines = File.ReadAllLines(csvfile);

        for (int i = 0; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');

            string program_name = values[0];
            string status = values[1];

            Console.WriteLine(program_name + " - " + status);
            
        }
        Console.WriteLine("------------------------");
        Console.WriteLine("Listing complete. Press any key to continue.");
        Console.ReadKey();
        Console.Clear();
    }
}