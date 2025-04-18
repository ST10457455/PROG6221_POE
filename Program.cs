using System;
using System.Media;

class Program
{
    static void Main(string[] args)
    {
        // Play voice greeting
        try
        {
            SoundPlayer player = new SoundPlayer("greeting.wav"); // use relative path if in folder
            player.PlaySync(); // PlaySync blocks until sound finishes
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing sound: " + ex.Message);
        }

        Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
        // You can now continue with asking for name, etc.
    }
}