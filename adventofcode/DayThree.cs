namespace adventofcode;

public static class DayThree
{
    static char[] charsToCheck = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.'];

    public static void PartOneRun()
    {
        string path = "Asset/DayThree.txt";
        string[] lines = File.ReadAllLines(path);
        List<string> newLines = new();


        var newData = new List<char>();

        for (var index = 0; index <= lines.Length - 1; index++)
        {
            /*
             * TODO:
             * 1- Find numbers and start/end position
             * 2- Find symbols and start/end position
             * 3- Check if number adjacent to symbol in a any direction
             * 4- Add valid number to list and get sum of them later
             */

            var line = lines[index];

            // handle first and last line
            if (index == 0)
            {
                var currentLineSymbolPositions = GetSymbolPositions(lines[index]);
                var nextLineSymbolPositions = GetSymbolPositions(lines[index + 1]);
            }
            else if (index == lines.Length)
            {
                var previousLineSymbolPositions = GetSymbolPositions(lines[index - 1]);
                var currentLineSymbolPositions = GetSymbolPositions(lines[index]);
            }
            else
            {
                var previousLineSymbolPositions = GetSymbolPositions(lines[index - 1]);
                var currentLineSymbolPositions = GetSymbolPositions(lines[index]);
                var nextLineSymbolPositions = GetSymbolPositions(lines[index + 1]);
                var numbers = GetNumbersWithStartAndEndPosition(lines[index]);

                for (int i = 0; i <= line.Length - 1; i++)
                {
                    
                    // newData.Add(line[i]);
                }

                var ss = new string(newData.ToArray());
                newLines.Add(ss);
                Console.WriteLine($"{newLines.Count}  {ss}");
            }
        }
    }

    private static int[] GetSymbolPositions(string line)
    {
        var symbolPositions = new List<int>();

        for (var index = 0; index < line.Length; index++)
        {
            if (!charsToCheck.Contains(line[index]))
            {
                symbolPositions.Add(index);
            }
        }

        return symbolPositions.ToArray();
    }

    private static (int start, int end, int number)[] GetNumbersWithStartAndEndPosition(string line)
    {
        var numbers = new List<(int start, int end, int number)>();

        int? start = null;
        int? end = null;

        var number = new List<char>();

        for (var index = 0; index < line.Length; index++)
        {
            if (char.IsNumber(line[index]) && start is null)
            {
                start = index;

                number.Add(line[index]);
                continue;
            }

            if (char.IsNumber(line[index]) && start is not null && end is null)
            {
                number.Add(line[index]);
                continue;
            }

            if (!char.IsNumber(line[index]) && start is not null && end is null)
            {
                end = index - 1;
                var ss = new string(number.ToArray());
                numbers.Add((start.Value, end.Value, int.Parse(ss)));

                number.Clear();
                start = null;
                end = null;
            }
        }

        return numbers.ToArray();
    }
}