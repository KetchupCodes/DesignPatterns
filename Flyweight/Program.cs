using System;
using System.Collections.Generic;
// Flyweight Pattern in a text editor application.
// 
// Suppose you're building a word processor where you need to represent text with different formatting styles,
// such as font, size, and color.
//
//
//
// Instead of creating a separate object for each character with its formatting information,
// you can use the Flyweight Pattern to share common formatting data among multiple characters.

// Flyweight interface
public interface ICharacter
{
    void Display();
}

// Concrete flyweight class representing a character with formatting
public class Character : ICharacter
{
    private char symbol;
    private string font;
    private int size;
    private ConsoleColor color;

    public Character(char symbol, string font, int size, ConsoleColor color)
    {
        this.symbol = symbol;
        this.font = font;
        this.size = size;
        this.color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = color;
        Console.Write($"[{symbol} ({font}, {size}px)] ");
        Console.ResetColor();
    }
}

// Flyweight factory
public class CharacterFactory
{
    private Dictionary<string, ICharacter> characters = new Dictionary<string, ICharacter>();

    public ICharacter GetCharacter(char symbol, string font, int size, ConsoleColor color)
    {
        // Generate a unique key based on symbol and formatting attributes
        string key = $"{symbol}{font}{size}{color}";

        // Check if the character exists in the dictionary
        if (!characters.ContainsKey(key))
        {
            // If not, create a new character and add it to the dictionary
            characters[key] = new Character(symbol, font, size, color);
        }

        // Return the shared character object
        return characters[key];
    }
}

// Client code
class Program
{
    static void Main(string[] args)
    {
        // Create a character factory
        CharacterFactory factory = new CharacterFactory();

        // Text to be displayed
        string text = "Hello, world!";

        // Display the text using flyweight objects
        foreach (char c in text)
        {
            // Get a character from the factory with specific formatting
            ICharacter character = factory.GetCharacter(c, "Arial", 12, ConsoleColor.Red);

            // Display the character
            character.Display();
        }
    }
}
