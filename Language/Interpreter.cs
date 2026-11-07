using System;

namespace marjaOS;

public static class Interpreter
{
    public static void Execute(string line)
    {
        var parts = line.Split(' ');

        if (parts[0] == "PRINT")
        {
            Console.WriteLine(string.Join(" ", parts, 1, parts.Length - 1));
        }
    }
}