using System;

namespace marjaOS;

public static class Handler
{
    public static void Handle(string input)
    {
        switch (input.Trim().ToLower())
        {
            case "help":
                Console.WriteLine("Commands: help, about, clear");
                break;

            case "about":
                Console.WriteLine("marjaOS - my first operating system");
                break;

            case "clear":
                Console.Clear();
                break;

            default:
                Console.WriteLine($"\"{input}\" is not a command");
                break;
        }
    }
}