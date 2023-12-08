const int puzVer = 2;
int finalAnswer = 0;

StreamReader sr = new StreamReader("input.txt");
string line = sr.ReadLine();

Dictionary<string, int> ballBag = new Dictionary<string, int>()
{
    { "red",    12 },
    { "green",  13 },
    { "blue",   14 }
};

while (line != null)
{
    string game = line.Substring(line.IndexOf(':') + 1);

    switch(puzVer)
    {
        case 1:
            {
                if (GameIsPossible(game))
                {
                    int gameNum = Convert.ToInt32(line.Split(':')[0].Split(' ')[1]);

                    finalAnswer += gameNum;
                }
                break;
            }
        case 2: 
            {
                finalAnswer += CalculateGamePower(game);

                break;
            }
        default:
            throw new Exception("Invalid Puzzle Version");
    }

    line = sr.ReadLine();
}

Console.WriteLine(finalAnswer.ToString());

int CalculateGamePower(string game)
{
    int red = 0;
    int green = 0;
    int blue = 0;

    foreach (string draw in game.Split(';'))
    {
        Dictionary<string, int> results = new Dictionary<string, int>();

        List<string> sets = draw.Split(",").Select(x => x.Trim()).ToList();

        foreach (string set in sets)
        {
            List<string> pair = set.Split(' ').Select(x => x.Trim()).ToList();
            results.Add(pair[1], Convert.ToInt32(pair[0]));
        }

        foreach (var result in results)
        {
            switch(result.Key)
            {
                case "red":
                    {
                        if (result.Value > red) 
                        { 
                            red = result.Value;
                        }
                        break;
                    }
                case "green":
                    {
                        if (result.Value > green)
                        {
                            green = result.Value;
                        }
                        break;
                    }
                case "blue":
                    {
                        if(result.Value > blue)
                        {
                            blue = result.Value;
                        }
                        break;
                    }
            }
        }
    }

    return red * green * blue;
}

bool GameIsPossible(string game)
{
    foreach (string draw in game.Split(';'))
    {
        Dictionary<string, int> results = new Dictionary<string, int>();

        List<string> sets = draw.Split(",").Select(x => x.Trim()).ToList();

        foreach (string set in sets)
        {
            List<string> pair = set.Split(' ').Select(x => x.Trim()).ToList();
            results.Add(pair[1], Convert.ToInt32(pair[0]));
        }

        foreach (var result in results)
        {
            if (!ballBag.Keys.Contains(result.Key))
            {
                return false;
            }

            if (result.Value > ballBag[result.Key])
            {
                return false;
            }
        }
    }

    return true;
}