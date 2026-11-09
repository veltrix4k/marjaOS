using System;
using Sys = Cosmos.Kernel.System;

namespace marjaOS;

public static class errorScreen
{
    public static void DisplayError(string message)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Clear();
        Console.Beep(500, 500);
        Console.WriteLine("Oops! An error occurred!");
        Console.WriteLine("Error: " + message);
        Console.WriteLine("Press any key to restart...");
        Console.ReadKey(true);

        Sys.Power.Reboot();
    }
}
