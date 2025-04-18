using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Clear();     // Optional: clears console before showing chatbot UI

        AskUserName();
        
        // Play voice greeting on macOS using afplay
        try
        {
            Process.Start("afplay", "greeting.wav");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing audio: " + ex.Message);
        }

        

        Console.WriteLine("Welcome to the Cybersecurity Awareness Bot!");
        // Continue with the rest of your chatbot...

        DisplayAsciiArt();

    }

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"


       ______      __              _____                      _ __           ___                                                   ____        __ 
      / ____/_  __/ /_  ___  _____/ ___/___  _______  _______(_) /___  __   /   |_      ______ _________  ____  ___  __________   / __ )____  / /_
     / /   / / / / __ \/ _ \/ ___/\__ \/ _ \/ ___/ / / / ___/ / __/ / / /  / /| | | /| / / __ `/ ___/ _ \/ __ \/ _ \/ ___/ ___/  / __  / __ \/ __/
    / /___/ /_/ / /_/ /  __/ /   ___/ /  __/ /__/ /_/ / /  / / /_/ /_/ /  / ___ | |/ |/ / /_/ / /  /  __/ / / /  __(__  |__  )  / /_/ / /_/ / /_  
    \____/\__, /_.___/\___/_/   /____/\___/\___/\__,_/_/  /_/\__/\__, /  /_/  |_|__/|__/\__,_/_/   \___/_/ /_/\___/____/____/  /_____/\____/\__/  
         /____/                                                 /____/                                                                           


            Cybersecurity Awareness Bot        
        ");
        Console.ResetColor();
    }

    static void AskUserName()
    {
        Console.Write("\n👋 Hello! What's your name? ");
        string name = Console.ReadLine()!;

        while (string.IsNullOrWhiteSpace(name))
        {
            Console.Write("❗ Please enter a valid name: ");
            name = Console.ReadLine()!;
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✅ Welcome, {name}! I'm here to help you stay safe online.");
        Console.ResetColor();
    }

}

