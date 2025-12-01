using System.Diagnostics;

using AdventOfCode.ToolBox;

using Serilog.Core;

namespace AdventOfCode.DayX;

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
        logger.Information($"=== Day X ===");

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
        logger.Information("PART 1 - ");
    }

    public void SolvePart2()
    {
        logger.Information("PART 2 - ");
    }
}