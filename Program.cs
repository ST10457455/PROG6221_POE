using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Play voice greeting on macOS using afplay
        try
        {
            Process.Start("afplay", "greeting.wav");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error playing audio: " + ex.Message);
        }

        Console.Clear();     // Optional: clears console before showing chatbot UI

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

}

