namespace adventofcode;

public static class DayTwo
{
    private const int MaxRed = 12;
    private const int MaxGreen = 13;
    private const int MaxBlue = 14;

    public static void PartTwoRun()
    {
        string path = "Asset/DayTwo.txt";
        string[] lines = File.ReadAllLines(path);
        var games = ParsGames(lines);

        var gameMinimumToPower = new List<int>();

        foreach (var game in games)
        {
            int? maxRed = null;
            int? maxBlue = null;
            int? maxGreen = null;
            foreach (var gamePart in game.Parts)
            {
                foreach (var set in gamePart.Sets)
                {
                    switch (set.Color)
                    {
                        case Color.Blue:
                        {
                            if (maxBlue is null)
                            {
                                maxBlue = set.Count;
                                continue;
                            }

                            if (maxBlue < set.Count) maxBlue = set.Count;
                            continue;
                        }
                        case Color.Red:
                        {
                            if (maxRed is null)
                            {
                                maxRed = set.Count;
                                continue;
                            }

                            if (maxRed < set.Count) maxRed = set.Count;
                            continue;
                        }
                        case Color.Green:
                        {
                            if (maxGreen is null)
                            {
                                maxGreen = set.Count;
                                continue;
                            }

                            if (maxGreen < set.Count) maxGreen = set.Count;
                            continue;
                        }
                    } // switch
                    
                } // set loop
                
            } // part loop
            gameMinimumToPower.Add((int)(maxRed*maxBlue*maxGreen));
        } // game loop

        Console.WriteLine(gameMinimumToPower.Sum());
    }


    public static void PartOneRun()
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
                    switch (set.Color)
                    {
                        case Color.Blue:
                        {
                            if (set.Count > MaxBlue)
                            {
                                possible = false;
                            }

                            continue;
                        }
                        case Color.Red:
                        {
                            if (set.Count > MaxRed)
                            {
                                possible = false;
                            }

                            continue;
                        }
                        case Color.Green:
                        {
                            if (set.Count > MaxGreen)
                            {
                                possible = false;
                            }

                            continue;
                        }
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