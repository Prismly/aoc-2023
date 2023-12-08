namespace AdventOfCode;

public class Day06 : BaseDay
{
    private readonly string _input;
    private readonly string[] _inputLines;

    public Day06()
    {
        _input = File.ReadAllText(InputFilePath);
        _inputLines = _input.Split('\n');
    }

    public override ValueTask<string> Solve_1()
    {
        return new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");
    }

    public override ValueTask<string> Solve_2()
    {
        return new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
    }
}
