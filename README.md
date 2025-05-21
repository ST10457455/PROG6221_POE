📢 Author
James Baker
Student No: ST10457455
Module: PROG6221 – Portfolio of Evidence
Institution: Varsity College Newlands Cape Town
Year: 2025


# 🛡️ Cybersecurity Awareness Chatbot (Console App)

Welcome to the **Cybersecurity Awareness Chatbot** — a console-based virtual assistant designed to educate South African citizens on how to stay safe online. 🇿🇦

This project was developed as part of the **PROG6221 Portfolio of Evidence (POE)**.

- ✅ **Part 1:** Basic chatbot implementation with interactive console features  
- 🚧 **Part 2:** Dynamic responses, sentiment detection, memory recall, keyword matching, and improved conversation flow  
- 🔜 **Part 3:** Final polish, UI/game enhancements, and presentation video

---

## 🎯 Purpose

South Africa has seen a rise in cyberattacks, including phishing, malware, and identity theft. This chatbot raises awareness by simulating common cyber threat scenarios and teaching users how to respond safely.

---

## 🚀 Features

### ✅ Part 1:
✅ Voice greeting at startup  
✅ ASCII Art Logo for visual flair  
✅ Name-based personalization  
✅ Answers to common questions like:
  - "How are you?"
  - "What's your purpose?"
  - "What can I ask you?"
  - "What is phishing?"
  - "How do I create a strong password?"
✅ Input validation for unknown or blank entries
✅ Typing effect and console UI formatting 
✅ GitHub version control with CI/CD via GitHub Actions

### 🧠 Part 2 Enhancements:
✅ Sentiment detection (positive/negative messages)
✅ Keyword-based responses using dictionaries 
✅ Memory of recent questions with "What did we talk about?"  
✅ Recognition of follow-up prompts like "more", "why", and "explain" 
✅ Randomized phishing tips to keep answers dynamic 
✅ Error handling and edge case responses 
✅ Modularized helper methods for cleaner code 

---

## 🖼️ ASCII Art Sample

```plaintext
===============================
|  🛡️ Cybersecurity Awareness Bot  |
===============================

🖥️ How to Run the Project
Prerequisites:
.NET 8 SDK installed on your machine

A terminal or Visual Studio Code (optional for easier editing)

Git (for cloning the repository)

Steps:
Clone the Repository If you haven't already, open your terminal and clone the repo to your local machine:

bash
Copy
Edit
git clone https://github.com/ST10457455/PROG6221_POE.git
Navigate to the Project Folder Change to the project directory:

bash
Copy
Edit
cd PROG6221_POE
Run the Application Make sure you're in the project directory, then use the following command to run the project:

bash
Copy
Edit
dotnet run
The chatbot should launch in the terminal. You'll hear the voice greeting (if configured) and see the ASCII art displayed.

✅ GitHub Actions – CI Screenshot
Include a screenshot of a successful CI run (green checkmark) from the Actions tab here.


🛠️ Technologies Used
C# (.NET 8)

Visual Studio Code

Git & GitHub

GitHub Actions (CI/CD)

System.Console for UI & Sound (Mac-compatible workaround)

📂 Folder Structure
plaintext
Copy
Edit
ChatbotApp/
│
├── Program.cs               # Main logic
├── greeting.wav             # Voice greeting file
├── ASCII.txt                # Optional ASCII logo
├── .gitignore
├── .github/
│   └── workflows/dotnet.yml  # CI config
├── README.md
🧠 Future Enhancements (Part 2 & 3)
🧩 Topic recognition (phishing, password tips, etc.)

🎮 Simple games and quizzes

📋 Interactive tip checklist

🎥 Final video presentation 
