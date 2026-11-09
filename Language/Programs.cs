using System.IO;

namespace marjaOS;

public static class Programs
{
    public static string[] Get(string name)
    {
        return File.ReadAllLines("/cdrom/programs/" + name + ".mjrs");
    }
}