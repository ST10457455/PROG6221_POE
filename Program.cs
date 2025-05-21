using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Clear();     // Optional: clears console before showing chatbot UI

        
        
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

        AskUserName();
        
        DisplayHeader();

        StartChat();

        PrintDivider();

        ShowLoading();
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

    static Dictionary<string, string> keywordResponses = new Dictionary<string, string>()
    {
        { "password", "🔐 Password Tip: Use a mix of uppercase, lowercase, numbers, and symbols. Avoid using the same password across sites." },
        { "scam", "🚨 Scam Alert: Watch out for messages asking for personal details or urgent action. They're usually scams." },
        { "privacy", "🕵️ Privacy Tip: Avoid oversharing on social media. Adjust your privacy settings and stay cautious." }
    };

    static List<string> phishingTips = new List<string>()
    {   
        "🎣 Phishing Tip: Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
        "🎣 Phishing Tip: Never click on suspicious links, even if the email looks legitimate. Always verify the sender.",
        "🎣 Phishing Tip: Look for spelling errors or strange email addresses – they’re red flags for phishing attempts."
    };

    static void StartChat()
    {
        Console.WriteLine("\n You can now ask me cybersecurity questions!");
        Console.WriteLine("Type 'exit' to end the chat.\n");

        while (true)
        {
            PrintDivider();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("🧠 You: ");
            string? question = Console.ReadLine()?.ToLower().Trim();
            Console.ResetColor();

            if (string.IsNullOrWhiteSpace(question))
            {
                ShowLoading();
                TypeResponse("🤖 Bot: I didn't quite understand that. Could you rephrase?");
                continue;
            }

            if (question == "exit") //type exit to end chat with chatbot
            {
                TypeResponse("👋 Goodbye! Stay safe online!");
                break;
            }

            //Keyword Recognition
            string? matchedKeyword = keywordResponses.Keys.FirstOrDefault(K => question.Contains(K));
            if (matchedKeyword != null)
            {
                ShowLoading();
                TypeResponse(keywordResponses[matchedKeyword]);
                continue;
            }

            //Default response if no keyword is matched
            ShowLoading();
            TypeResponse("🤖 Bot: Hmm, I’m not sure about that. Try asking about passwords, scams, or privacy.");
        }

    }

    static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════╗");
            Console.WriteLine("║        🛡️ Cybersecurity Awareness Bot        ║");
            Console.WriteLine("╚══════════════════════════════════════════════╝");
            Console.ResetColor();
        }

    static void TypeResponse(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(30); // Adjust speed here
        }
    Console.WriteLine();
    Console.ResetColor();
    }

    static void PrintDivider()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n-----------------------------------------------\n");
        Console.ResetColor();
    }

    static void ShowLoading(string message = "🤖 Thinking", int dotCount = 3, int delay = 400)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(message);

        for (int i = 0; i < dotCount; i++)
        {
        Thread.Sleep(delay); // delay between each dot
        Console.Write(".");
        }

        Console.WriteLine(); // move to next line after animation
        Console.ResetColor();
    }

}

