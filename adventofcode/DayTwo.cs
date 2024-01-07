namespace adventofcode;

public static class DayTwo
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;

    public static void Run()
    {
        string path = "Asset/DayTwo.txt";
        string[] lines = File.ReadAllLines(path);
        var games = ParsGames(lines);

        var possibleGames = new List<Game>();

        foreach (var game in games)
        {
            var possible = true;

            foreach (var gamePart in game.Parts)
            {
                foreach (var set in gamePart.Sets)
                {
                    if (set.Color is Color.Blue)
                    {
                        if (set.Count > MaxBlue)
                        {
                            possible = false;
                        }

                        continue;
                    }

                    if (set.Color is Color.Red)
                    {
                        if (set.Count > MaxRed)
                        {
                            possible = false;
                        }

                        continue;
                    }

                    if (set.Color is Color.Green)
                    {
                        if (set.Count > MaxGreen)
                        {
                            possible = false;
                        }

                        continue;
                    }
                }
            }

            if (possible)
            {
                possibleGames.Add(game);
            }
        }

        var value = possibleGames.Select(x => x.Id);
        Console.WriteLine(value.Sum());
    }

    private static List<Game> ParsGames(string[] lines)
    {
        var games = new List<Game>();
        foreach (var line in lines)
        {
            var game = new Game();
            var splitByColon = line.Split(":");
            var gameNumber = splitByColon[0].Split(" ")[1];

            game.Id = Convert.ToInt32(gameNumber);

            var parts = splitByColon[1].Split(";");

            var partList = new List<Part>();

            foreach (var part in parts)
            {
                var partStruct = new Part();
                var setList = new List<Set>();
                var sets = part.Split(",");

                foreach (var set in sets)
                {
                    var setSplits = set.Split(" ");
                    setList.Add(new Set
                    {
                        Color = MapToColor(setSplits[2]),
                        Count = Convert.ToInt32(setSplits[1])
                    });

                    partStruct.Sets = setList;
                }

                partList.Add(partStruct);
            }

            game.Parts = partList;

            games.Add(game);
        }

        return games;
    }

    private static Color MapToColor(string input)
    {
        var colorEnum = input switch
        {
            "blue" => Color.Blue,
            "red" => Color.Red,
            "green" => Color.Green,
            _ => Color.Green
        };

        return colorEnum;
    }

    enum Color
    {
        Blue = 1,
        Red,
        Green
    }

    struct Set
    {
        public Color Color;
        public int Count;
    }

    struct Part
    {
        public List<Set> Sets;
    }

    struct Game
    {
        public List<Part> Parts;
        public int Id;
    }
}