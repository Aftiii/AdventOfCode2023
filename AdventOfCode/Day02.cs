namespace AdventOfCode;

public class Day02 : BaseDay
{
    private readonly string _input;
    private readonly List<string> _lines;
    private readonly int MAX_RED_CUBES = 12;
    private readonly int MAX_GREEN_CUBES = 13;
    private readonly int MAX_BLUE_CUBES = 14;

    public Day02()
    {
        _input = File.ReadAllText(InputFilePath);
        _lines = _input.Split("\r\n").ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        int gameIdCounts = 0;
        foreach (string line in _lines)
        {
            bool exitLine = false;
            string[] gameAndHandfulls = line.Split(":");
            int gameId = int.Parse(gameAndHandfulls[0].Split("Game ")[1]);
            string[] handFulls = gameAndHandfulls[1].Split(";");
            foreach (string handfull in handFulls)
            {
                if (exitLine)
                {
                    break;
                }

                string[] cubes = handfull.Split(",");
                foreach (string cube in cubes)
                {
                    //Is red
                    if (cube.EndsWith("d"))
                    {
                        int count = int.Parse(cube.Replace(" red", "").Trim());
                        if (count > MAX_RED_CUBES)
                        {
                            exitLine = true;
                            break;
                        }
                    }
                    //Is blue
                    else if (cube.EndsWith("e"))
                    {
                        int count = int.Parse(cube.Replace(" blue", "").Trim());
                        if (count > MAX_BLUE_CUBES)
                        {
                            exitLine = true;
                            break;
                        }
                    }
                    //Is green
                    else if (cube.EndsWith("n"))
                    {
                        int count = int.Parse(cube.Replace(" green", "").Trim());
                        if (count > MAX_GREEN_CUBES)
                        {
                            exitLine = true;
                            break;
                        }
                    }
                }
            }

            if (!exitLine)
            {
                gameIdCounts += gameId;
            }
        }

        return new(gameIdCounts.ToString());
    }

    public override ValueTask<string> Solve_2()
    {
        List<int> powers = new List<int>();
        foreach (string line in _lines)
        {
            bool exitLine = false;
            string[] gameAndHandfulls = line.Split(":");
            string[] handFulls = gameAndHandfulls[1].Split(";");
            int highestRed = 0;
            int highestBlue = 0;
            int highestGreen = 0;
            foreach (string handfull in handFulls)
            {
                string[] cubes = handfull.Split(",");
                foreach (string cube in cubes)
                {
                    //Is red
                    if (cube.EndsWith("d"))
                    {
                        int count = int.Parse(cube.Replace(" red", "").Trim());
                        if (highestRed < count)
                        {
                            highestRed = count;
                        }
                    }
                    //Is blue
                    else if (cube.EndsWith("e"))
                    {
                        int count = int.Parse(cube.Replace(" blue", "").Trim());
                        if (highestBlue < count)
                        {
                            highestBlue = count;
                        }
                    }
                    //Is green
                    else if (cube.EndsWith("n"))
                    {
                        int count = int.Parse(cube.Replace(" green", "").Trim());
                        if (highestGreen < count)
                        {
                            highestGreen = count;
                        }
                    }
                }
            }

            int powerOfLine = highestRed * highestGreen * highestBlue;
            powers.Add(powerOfLine);
        }

        int total = 0;
        foreach (int power in powers)
        {
            total += power;
        }

        return new(total.ToString());
    }
}