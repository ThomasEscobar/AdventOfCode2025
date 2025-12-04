using System.Diagnostics;
using System.Text.RegularExpressions;
using AdventOfCode.ToolBox;
using Serilog;
using Serilog.Core;

namespace AdventOfCode.Day2;

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
        logger.Information($"=== Day 2 ===");

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
        logger.Information("PART 1 - Calculating the sum of all invalid IDs (sequence of digits repeated twice)");

        double sum = 0;
        var ranges = input[0].Split(',');

        foreach (var range in ranges)
        {
            var firstId = Double.Parse(range.Split('-')[0]);
            var lastId = Double.Parse(range.Split('-')[1]);
            for (var id = firstId; id <= lastId; id++)
            {
                var idStr = id.ToString();
                if (idStr[..(idStr.Length / 2)] == idStr[(idStr.Length / 2)..])
                {
                    logger.Debug($"{idStr[..(idStr.Length / 2)]} is the same as {idStr[(idStr.Length / 2)..]}");
                    sum += id;
                }
            }
        }

        logger.Information($"The final sum is {sum}");
    }

    public void SolvePart2()
    {
        logger.Information("PART 2 - Calculating the sum of all invalid IDs (sequence of digits repeated AT LEAST twice)");

        double sum = 0;
        var ranges = input[0].Split(',');

        foreach (var range in ranges)
        {
            var firstId = Double.Parse(range.Split('-')[0]);
            var lastId = Double.Parse(range.Split('-')[1]);
            for (var id = firstId; id <= lastId; id++)
            {
                var idStr = id.ToString();
                for (var i = 1; i <= idStr.Length / 2; i++)
                {
                    var regex = new Regex($"^({idStr[..i]})+$");
                    if (regex.IsMatch(idStr))
                    {
                        logger.Debug($"{idStr} is made of repeated {idStr[..i]}");
                        sum += id;
                        break;
                    }
                }
            }
        }

        logger.Information($"The final sum is {sum}");
    }
}