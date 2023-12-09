using System.Collections;

namespace AdventOfCode;

public static class Utils
{
    public static List<int> ParseNums(string input)
    {
        string[] inputSplit = input.Split(' ');
        List<int> outputList = new List<int>();
        foreach (string s in inputSplit)
            if (s.Length > 0)
                outputList.Add(int.Parse(s));
        return outputList;
    }
}
