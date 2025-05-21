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

    static List<string> positiveWords = new List<string> { "good", "great", "awesome", "fantastic", "thank", "thanks" };
    static List<string> negativeWords = new List<string> { "bad", "terrible", "annoyed", "angry", "upset", "frustrated" };

    static List<string> memory = new List<string>();

    static Random random = new Random();

    static void StartChat()
    {
        Console.WriteLine("\n You can now ask me cybersecurity questions!");
        Console.WriteLine("Type 'exit' to end the chat.\n");

        string lastTopic = ""; // Tracks last keyword discussed

        while (true)
        {
            try
            {
                PrintDivider();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("🧠 You: ");
                string? input = Console.ReadLine();
                Console.ResetColor();

                // Normalize input early
                string question = input?.ToLower().Trim() ?? "";

                // Handle empty input
                if (string.IsNullOrWhiteSpace(question))
                {
                    Respond("🤖 Bot: I didn't quite understand that. Could you rephrase?");
                    continue;
                }

                // Limit input length
                if (question.Length > 200)
                {
                    Respond("🤖 Bot: That's a bit too long for me to process. Could you shorten it?");
                    continue;
                }

                // Exit command
                if (question == "exit")
                {
                    TypeResponse("👋 Goodbye! Stay safe online!");
                    break;
                }

                // Sentiment detection: check once and respond accordingly
                if (ContainsAny(positiveWords, question))
                {
                    Respond("😊 I'm glad you're feeling positive! Let me know if you need help with anything.");
                    continue;
                }

                if (ContainsAny(negativeWords, question))
                {
                    Respond("😟 I'm sorry you're feeling that way. I'm here to help you stay safe online. Ask me anything!");
                    continue;
                }

                // Memory recall
                if (question == "what did we talk about?")
                {
                    ShowLoading();
                    if (memory.Count == 0)
                    {
                        TypeResponse("🤖 Bot: We haven't talked about anything yet. Ask me something!");
                    }
                    else
                    {
                        TypeResponse("🤖 Bot: So far, we've discussed:");
                        foreach (var item in memory.Distinct())
                            Console.WriteLine(" - " + item);
                    }
                    continue;
                }

                // Add to memory
                memory.Add(question);

                // More info requests
                if (ContainsAny(new[] { "more", "explain", "why" }, question))
                {
                    ShowLoading();
                    TypeResponse(lastTopic switch
                    {
                        "password" => "🔐 Extra Tip: Consider using a password manager like Bitwarden or LastPass to safely store and generate strong passwords.",
                        "scam" => "🚨 More Info: Scammers often create a sense of urgency. Always pause and verify the source before acting.",
                        "privacy" => "🕵️ Extra Tip: Be cautious about sharing location data. Review app permissions on your devices regularly.",
                        "phishing" => "🎣 More Info: Phishing emails often look real but contain subtle errors. Always hover over links to see where they lead.",
                        _ => "🤖 Bot: Hmm, I need a bit more context to give you more info. Try asking about passwords, scams, or privacy."
                    });
                    continue;
                }

                // Random phishing tip
                if (question.Contains("phishing"))
                {
                    Respond(phishingTips[random.Next(phishingTips.Count)]);
                    continue;
                }

                // Keyword recognition
                var matchedKeyword = keywordResponses.Keys.FirstOrDefault(k => question.Contains(k));
                if (matchedKeyword != null)
                {
                    Respond(keywordResponses[matchedKeyword]);
                    lastTopic = matchedKeyword;
                    continue;
                }

                // Default response
                Respond("🤖 Bot: Hmm, I’m not sure about that. Try asking about passwords, scams, or privacy.");
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n⚠️ Oops! Something went wrong: {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    // Helper to check if any word is contained in text
    static bool ContainsAny(IEnumerable<string> words, string text)
    {
        return words.Any(word => text.Contains(word));
    }

    // Helper to wrap ShowLoading + TypeResponse calls
    static void Respond(string message)
    {
        ShowLoading();
        TypeResponse(message);
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

