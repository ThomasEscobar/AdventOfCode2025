using System.Diagnostics;
using Serilog.Core;
using AdventOfCode.ToolBox;
using Serilog;

namespace AdventOfCode.Day1;

public class Solver
{
    private readonly Logger logger;
    private List<string> input;
    public Solver(string inputFilePath, Logger logger)
    {
        this.logger = logger;
        try
        {
            this.input = ToolBoxClass.GetStringListFromInput(inputFilePath);
        }
        catch (Exception e)
        {
            logger.Error(e, $"There was an error reading the input file.{Environment.NewLine}");
            Environment.Exit(1);
        }
    }

    public void Solve()
    {
        logger.Information($"=== Day 1 ===");

        var sw = new Stopwatch();
        sw.Start();

        this.SolvePart1();
        logger.Information($"(Part 1 took {sw.ElapsedMilliseconds} ms)");

        sw.Restart();

        this.SolvePart2();
        logger.Information($"(Part 2 took {sw.ElapsedMilliseconds} ms)");

        logger.Information("=============");
    }

    public void SolvePart1()
    {
        logger.Information("PART 1 - Counting the number of times the dial rotates to exactly zero");

        var position = 50;
        var zeroCount = 0;

        foreach (var line in input)
        {
            var sign = line.Contains('R') ? 1 : -1;
            var rotation = Int32.Parse(line[1..]);

            // Calculate new position
            position = (position + sign * rotation + 100) % 100;
            if (position == 0) zeroCount++;

            logger.Debug($"Position = {position}, zeroCount = {zeroCount}");
        }

        logger.Information($"The total count of zeros is: {zeroCount}");
    }

    public void SolvePart2()
    {
        logger.Information("PART 2 - Counting the number of times the dial rotates through zero");

        var position = 50;
        var goingThroughZero = 0;

        foreach (var line in input)
        {
            var sign = line.Contains('R') ? 1 : -1;
            var rotation = Int32.Parse(line[1..]);

            // Process click by click to count each time going through 0
            var previousPosition = position;
            for (var click = 0; click < rotation; click++)
            {
                position += sign;
                if (position == 100)
                {
                    position = 0;
                }
                else if (position == -1)
                {
                    position = 99;
                }

                if (position == 0) goingThroughZero++;
            }

            logger.Debug($"{previousPosition} -> {position}; goingThroughZero={goingThroughZero}");
        }

        logger.Information($"The total count of zeros is: {goingThroughZero}");
    }
}