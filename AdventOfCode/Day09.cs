using Spectre.Console;
using System.Collections;

namespace AdventOfCode;

public class Day09 : BaseDay
{
    private readonly string _input;
    private readonly string[] _inputLines;

    public Day09()
    {
        _input = File.ReadAllText(InputFilePath);
        _inputLines = _input.Split('\n');
    }

    public override ValueTask<string> Solve_1()
    {
        int runningSum = 0;
        foreach (string history in _inputLines)
        {
            if (history.Length == 0)
                continue;
            List<int> historyNums = Utils.ParseNums(history);
            runningSum += ExtrapolateNext(historyNums);
        }
        return new(runningSum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int runningSum = 0;
        foreach (string history in _inputLines)
        {
            if (history.Length == 0)
                continue;
            List<int> historyNums = Utils.ParseNums(history);
            historyNums.Reverse();
            runningSum += ExtrapolateNext(historyNums);
        }
        return new(runningSum.ToString());
    }

    private int ExtrapolateNext(List<int> history)
    {
        List<int> lastNums = new List<int>();
        while (!AllZeroes(history))
        {
            lastNums.Add(history.Last());
            for (int i = 0; i < history.Count - 1; i++)
            {
                history[i] = history[i + 1] - history[i];
            }
            history.RemoveAt(history.Count - 1);
        }

        lastNums.Reverse();

        int extrapolated = lastNums.First();
        for (int i = 1; i < lastNums.Count; i++)
        {
            extrapolated += lastNums[i];
        }
        return extrapolated;
    }

    private bool AllZeroes(List<int> input)
    {
        foreach (int num in input)
            if (num != 0)
                return false;
        return true;
    }
}
