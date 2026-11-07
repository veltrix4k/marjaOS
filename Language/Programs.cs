using System.Collections.Generic;

namespace marjaOS;

public static class Programs
{
    private static Dictionary<string, string[]> list = new()
    {
        { "helloworld", new string[] { "PRINT hello world" } }
    };

    public static string[] Get(string name)
    {
        return list[name];
    }
}