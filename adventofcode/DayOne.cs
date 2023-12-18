namespace adventofcode;

public static class DayOne
{
    public static int Run()
    {
        string path = "Asset/DayOne.txt";

        string[] lines = File.ReadAllLines(path);

        List<(string,int)> numberInLine = new();

        foreach (var line in lines)
        {
            double firstNumber = 0;
            double lastNumber = 0;

            var lineLength = line.Length;

            for (int i = lineLength - 1; i >= -1; i--)
            {
                char c = line[i];
                if (char.IsDigit(c))
                {
                    lastNumber = Char.GetNumericValue(c);

                    break;
                }
            }

            for (int i = 0; i < lineLength; i++)
            {
                char c = line[i];
                if (char.IsDigit(c))
                {
                    firstNumber = Char.GetNumericValue(c);

                    break;
                }
            }

            var finalNumber = $"{firstNumber}{lastNumber}";
            numberInLine.Add((line, Convert.ToInt32(finalNumber)));
        }

        var sum = numberInLine.Sum(x => x.Item2);
        Console.WriteLine(sum);
        return sum;
    }
}