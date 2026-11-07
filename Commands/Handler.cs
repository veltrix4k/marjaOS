using System;
namespace marjaOS;

public static class Handler
{
    private static void RunProgram(string name)
    {
        foreach (var line in Programs.Get(name))
            Interpreter.Execute(line);
    }
    public static void Handle(string input)
    {
        var parts = input.Trim().Split(' ');

        switch (parts[0].ToLower())
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

            case "echo":
                Console.WriteLine(parts[1]);
                break;

            case "run":
                RunProgram(parts[1]);
                break;

            default:
                Console.WriteLine($"\"{input}\" is not a command");
                break;
        }
    }
}