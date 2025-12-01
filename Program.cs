using AdventOfCode.Logging;

namespace AdventOfCode;

class AdventOfCode
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            throw new Exception("Please select a day to solve and an input file");
        }

        // If a third argument is provided (doesn't matter what atm...), enable verbose logging
        var logger = CustomLogging.Init("logfile.txt", args.Length > 2);
        logger.Information("Welcome to Thomas' Advent Of Code 2025 project !");

        // Find the class based on name
        var className = $"AdventOfCode.Day{args[0]}.Solver";
        var solverType = Type.GetType(className);
        if (solverType == null)
        {
            logger.Error($"Class {className} not found");
            return;
        }

        // Create an instance of the found class
        var solverInstance = Activator.CreateInstance(solverType, $"Day{args[0]}/{args[1]}", logger);

        // Invoke the method by name for the created instance
        var solverMethod = solverType.GetMethod("Solve");
        if (solverMethod == null)
        {
            logger.Error($"Method \"Solve\" not found for class {className}");
            return;
        }

        solverMethod.Invoke(solverInstance, null);
    }
}
