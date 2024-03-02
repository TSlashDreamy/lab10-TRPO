// variant 8
static double InBoundaries(double x)
{
    return 2 / (Math.Pow(x, 2) + 1);
}

static double OutsideBoundaries(double x)
{
    return Math.Abs(Math.Pow(x, 3) - 7) / x;
}

static IEnumerable<double> GenerateRange(double start, double end, double step)
{
    double current = start;
    while (current <= end)
    {
        yield return current;
        current += step;
    }
}

Console.WriteLine("Your initial x value: ");
double initialX = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Your end x value: ");
double endX = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter tabulation step: ");
double step = Convert.ToDouble(Console.ReadLine());

List<double> results = new List<double>();

Parallel.ForEach(GenerateRange(initialX, endX, step), x =>
{
    double result = (-3 <= x && x <= 3) ? InBoundaries(x) : OutsideBoundaries(x);

    lock (results)
    {
        results.Add(result);
    }
});

Console.WriteLine("Tabulation results: ");

for (int i = 0; i < results.Count; i++)
{
    Console.WriteLine($"f({initialX + i * step}) = {results[i]}");
}

Console.WriteLine("\n\nPress any key to exit");
Console.ReadKey();
