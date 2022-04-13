using System;
using System.Collections.Generic;
using System.Linq;
using wordleconsole;

string currentWord = "";
string[] words = Resources.wordlist.Split("\r");
string saveDataPath = Resources.data;
List<Day> days = new();
List<Stat> stats = new();
Queue<string> availableWords = new Queue<string>();
string guess = "";

for (int i = 0; i < words.Length; i++)
{
    if (words[i].Length > 5)
    {
        words[i] = words[i].Remove(0, 1);
    }
}

void SelectWord()
{
    if (availableWords.Count == 0)
    {
        var shuffledWords = from word in words
                            orderby Guid.NewGuid().ToString()
                            select word;
        foreach (string word in shuffledWords)
        {
            availableWords.Enqueue(word);
        }
    }
    currentWord = availableWords.Dequeue();
    Console.WriteLine(currentWord);
}

Console.WriteLine("When you want to stop exit the console please!");
while (true)
{
selector: SelectWord();
    Console.WriteLine("Guess the word!\n");
    for (int i = 0; i < 6; i++)
    {
        guess = Console.ReadLine();
        if (guess.Length != 5)
        {
            Console.WriteLine("Guess must be 5 letters!");
        }
        for (int j = 0; j < 5; j++)
        {
            if (currentWord[j] == guess[j])
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(guess[j]);
            }
            else if (currentWord.Contains(guess[j]))
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(guess[j]);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(guess[j]);
            }
        }
        Console.WriteLine(Environment.NewLine);
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        if (currentWord == guess)
        {
            Console.WriteLine($"The word was {currentWord}!");
            Console.WriteLine("New Word!");
            goto selector;
        }
    }
}