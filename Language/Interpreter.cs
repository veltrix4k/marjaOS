using System;
using System.Collections.Generic;

namespace marjaOS;

public static class Interpreter
{
    private static Dictionary<string, string> memory = new();

    public static void Execute(string line)
    {
        var parts = line.Trim().Split(' ');

        if (parts[0] == "")
            return;

        string word = parts[0].ToUpper();

        if (word == "PRINT")
        {
            if (parts.Length < 2)
            {
                Console.WriteLine();
                return;
            }

            for (int i = 1; i < parts.Length; i++)
            {
                if (parts[i][0] == '$')
                {
                    string name = parts[i].Substring(1);

                    if (memory.ContainsKey(name))
                        parts[i] = memory[name];
                }
            }

            Console.WriteLine(string.Join(" ", parts, 1, parts.Length - 1));
        }
        else if (word == "SET")
        {
            if (parts.Length < 3)
            {
                Console.WriteLine("usage: SET name value");
                return;
            }

            memory[parts[1]] = string.Join(" ", parts, 2, parts.Length - 2);
        }
        else
        {
            Console.WriteLine("unknown word: " + parts[0]);
        }
    }
}