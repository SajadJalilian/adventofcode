namespace adventofcode;

public static class DayTwo
{
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

    public static void Run()
    {
        string path = "Asset/DayTwo.txt";

        string[] lines = File.ReadAllLines(path);

        List<Game> games = new();

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
        }
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
}