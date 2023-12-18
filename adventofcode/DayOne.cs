namespace adventofcode;

public static class DayOne
{
    public static int Run()
    {
        string path = "Asset/DayOne.txt";

        string[] lines = File.ReadAllLines(path);

        List<(string, int)> numberInLine = new();

        foreach (var line in lines)
        {
            List<string> lineNumbers = new();

            for (int i = 0; i < line.Length;)
            {
                char c = line[i];
                if (char.IsDigit(c))
                {
                    lineNumbers.Add(c.ToString());
                    i++;
                    break;
                }

                if (i <= line.Length - 3)
                {
                    var threeCharValue = CheckThreeCharStringExistence(line.Substring(i, 3));
                    if (threeCharValue is not null)
                    {
                        lineNumbers.Add(threeCharValue);
                        i += 2;
                        break;
                    }
                }

                if (i <= line.Length - 4)
                {
                    var fourCharValue = CheckFourCharStringExistence(line.Substring(i, 4));
                    if (fourCharValue is not null)
                    {
                        lineNumbers.Add(fourCharValue);
                        i += 3;
                        break;
                    }
                }

                if (i <= line.Length - 5)
                {
                    var fiveCharValue = CheckFiveCharStringExistence(line.Substring(i, 5));
                    if (fiveCharValue is not null)
                    {
                        lineNumbers.Add(fiveCharValue);
                        i += 4;
                        break;
                    }
                }

                i++;
            }

            for (int i = line.Length - 1; i > 0;)
            {
                char c = line[i];
                if (char.IsDigit(c))
                {
                    lineNumbers.Add(c.ToString());
                    i--;
                    break;
                }

                if (0 < i - 2)
                {
                    var threeCharValue = CheckThreeCharStringExistence(line.Substring(i - 2, 3));
                    if (threeCharValue is not null)
                    {
                        lineNumbers.Add(threeCharValue);
                        i -= 2;
                        break;
                    }
                }

                if (0 < i - 3)
                {
                    var fourCharValue = CheckFourCharStringExistence(line.Substring(i - 3, 4));
                    if (fourCharValue is not null)
                    {
                        lineNumbers.Add(fourCharValue);
                        i -= 3;
                        break;
                    }
                }

                if (0 < i - 4)
                {
                    var fiveCharValue = CheckFiveCharStringExistence(line.Substring(i - 4, 5));
                    if (fiveCharValue is not null)
                    {
                        lineNumbers.Add(fiveCharValue);
                        i -= 4;
                        break;
                    }
                }

                i--;
            }

            var finalNumber = $"{lineNumbers.First()}{lineNumbers.Last()}";
            numberInLine.Add((line, Convert.ToInt32(finalNumber)));
        }

        var sum = numberInLine.Sum(x => x.Item2);
        Console.WriteLine(sum);
        return sum;
    }

    private static string? CheckThreeCharStringExistence(string? s)
    {
        return s switch
        {
            "one" => "1",
            "two" => "2",
            "six" => "6",
            _ => null
        };
    }

    private static string? CheckFourCharStringExistence(string? s)
    {
        return s switch
        {
            "four" => "4",
            "five" => "5",
            "nine" => "9",
            _ => null
        };
    }

    private static string? CheckFiveCharStringExistence(string? s)
    {
        return s switch
        {
            "three" => "3",
            "seven" => "7",
            "eight" => "8",
            _ => null
        };
    }
}