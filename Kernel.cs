using Sys = Cosmos.Kernel.System;

using Cosmos.Kernel.System.Storage;
using Cosmos.Kernel.HAL.Devices.Storage;
using Cosmos.Kernel.System.FileSystem;
using Cosmos.Kernel.System.FileSystem.Iso9660;

namespace marjaOS;

public class Kernel : Sys.Kernel
{
    protected override void BeforeRun()
    {
        int pointer = 0;
        string[] entries = { "Start MarjaOS", "TEST" };

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < entries.Length; i++)
            {
                if (i == pointer)
                    Console.WriteLine("> " + entries[i]);
                else
                    Console.WriteLine(entries[i]);
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.DownArrow)
                if (pointer < entries.Length - 1)
                    pointer++;

            if (key.Key == ConsoleKey.UpArrow)
                if (pointer > 0)
                    pointer--;

            if (key.Key == ConsoleKey.Enter)
            {
                if (pointer == 0)
                {
                    break;
                }
                else if (pointer == 1)
                {
                    Console.WriteLine("TEST");
                    Console.ReadKey(true);
                }
            }
        }

        IBlockDevice cdrom = StorageManager.Devices[0];

        VfsManager.RegisterFileSystem("iso", new Iso9660FileSystemType(cdrom));

        if (VfsManager.TryMount("iso", "", MountFlags.None, "/cdrom", out _))
        {
            Console.WriteLine(File.ReadAllText("/cdrom/test.txt"));
        }
        else
        {
            Console.WriteLine("Failed to mount ISO");

}
    }

    protected override void Run()
    {
        Console.Write("PROMPT> ");
        var thing = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(thing))
            return;

        Handler.Handle(thing);
    }
}
