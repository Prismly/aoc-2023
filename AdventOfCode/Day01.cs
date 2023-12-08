namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;
    private readonly string[] _inputLines;

    private readonly string[] numNames = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        _inputLines = _input.Split('\n');
    }

    public override ValueTask<string> Solve_1()
    {
        int runningSum = 0;

        foreach (string line in _inputLines)
        {
            if (line.Length == 0)
                break;

            int currentNum = 0;
            currentNum += SeekFirstNumber(line, false) * 10;
            currentNum += SeekLastNumber(line, false);

            runningSum += currentNum;
        }

        return new(runningSum.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        int runningSum = 0;

        foreach (string line in _inputLines)
        {
            if (line.Length == 0)
                break;

            int currentNum = 0;
            currentNum += SeekFirstNumber(line, true) * 10;
            currentNum += SeekLastNumber(line, true);

            runningSum += currentNum;
        }

        return new(runningSum.ToString());
    }

    private int SeekFirstNumber(string line, bool includePlainText)
    {
        int firstNum = -1;
        int idxFound = -1;

        for (int c = 0; c < line.Length; c++)
        {
            if (char.IsDigit(line[c]))
            {
                firstNum = line[c] - '0';
                idxFound = c;
                break;
            }
        }

        if (!includePlainText)
            return firstNum;

        for (int n = 0; n < numNames.Length; n++)
        {
            int nameIdx = line.IndexOf(numNames[n]);
            if (nameIdx != -1 && nameIdx < idxFound)
            {
                firstNum = n + 1;
                idxFound = nameIdx;
            }
        }

        return firstNum;
    }

    private int SeekLastNumber(string line, bool includeNumNames)
    {
        int lastNum = -1;
        int idxFound = -1;

        for (int c = line.Length - 1; c >= 0; c--)
        {
            if (char.IsDigit(line[c]))
            {
                lastNum = line[c] - '0';
                idxFound = c;
                break;
            }
        }

        if (!includeNumNames)
            return lastNum;

        for (int n = 0; n < numNames.Length; n++)
        {
            int nameIdx = line.LastIndexOf(numNames[n]);
            if (nameIdx != -1 && nameIdx > idxFound)
            {
                lastNum = n + 1;
                idxFound = nameIdx;
            }
        }

        return lastNum;
    }
}
