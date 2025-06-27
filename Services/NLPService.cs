using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatbotApp
{
    public static class NLPService
    {
        // Define keyword variations
        private static readonly Dictionary<string, string> keywordMap = new()
        {
            { "password", "🔐 Password Tip: Use strong, unique passwords and a password manager." },
            { "scam", "🚨 Scam Alert: Don’t trust links or attachments from unknown senders." },
            { "privacy", "🕵️ Privacy Tip: Keep your social media private and limit shared info." },
            { "phishing", "🎣 Phishing Tip: Check URLs and sender addresses before clicking anything." }
        };

        // Synonyms or variants
        private static readonly Dictionary<string, List<string>> keywordSynonyms = new()
        {
            { "password", new List<string>{ "password", "passcode", "credentials" } },
            { "scam", new List<string>{ "scam", "fraud", "hoax" } },
            { "privacy", new List<string>{ "privacy", "personal info", "data" } },
            { "phishing", new List<string>{ "phishing", "fake email", "spoof", "spam" } }
        };

        public static string GetResponse(string input)
        {
            input = input.ToLower();

            foreach (var keyword in keywordSynonyms)
            {
                foreach (var variant in keyword.Value)
                {
                    if (input.Contains(variant))
                    {
                        return keywordMap[keyword.Key];
                    }
                }
            }

            return "🤖 I'm not sure how to answer that. Try asking about passwords, scams, privacy or phishing.";
        }
    }
}
