using System.Globalization;
using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly string _input;
    private readonly List<string> _lines;

    public Day01()
    {
        _input = File.ReadAllText(InputFilePath);
        _lines = _input.Split("\r\n").ToList();
    }

    public override ValueTask<string> Solve_1()
    {
        List<long> numsToAdd = new List<long>();
        for (int i = 0; i < _lines.Count; i++)
        {
            char[] explodedString = _lines[i].ToCharArray();
            List<string> numbers = new List<string>();
            for (int t = 0; t < explodedString.Length; t++)
            {
                if (int.TryParse(explodedString[t].ToString(), out int num))
                {
                    numbers.Add(num.ToString());
                }
            }
            
            if (numbers.Count == 2)
            {
                numsToAdd.Add(long.Parse(numbers[0] + numbers[1]));
            }else if (numbers.Count == 1)
            {
                numsToAdd.Add(long.Parse(numbers[0] + numbers[0]));
            }
            else
            {
                numsToAdd.Add(long.Parse(numbers[0] + numbers[numbers.Count - 1]));
            }
        }
        
        int total = 0;
        foreach (int num in numsToAdd)
        {
            total += num;
        }
        return new(total.ToString());
    }
    
    public override ValueTask<string> Solve_2()
    {
        List<long> numsToAdd = new List<long>();
        for (int i = 0; i < _lines.Count; i++)
        {
            _lines[i] = _lines[i].Replace("one", "o1e");
            _lines[i] = _lines[i].Replace("two", "t2o");
            _lines[i] = _lines[i].Replace("three", "th3ee");
            _lines[i] = _lines[i].Replace("four", "fo4r");
            _lines[i] = _lines[i].Replace("five", "fi5e");
            _lines[i] = _lines[i].Replace("six", "s6x");
            _lines[i] = _lines[i].Replace("seven", "se7en");
            _lines[i] = _lines[i].Replace("eight", "ei8ht");
            _lines[i] = _lines[i].Replace("nine", "ni9e");
        }
        
        for (int i = 0; i < _lines.Count; i++)
        {
            char[] explodedString = _lines[i].ToCharArray();
            List<string> numbers = new List<string>();
            for (int t = 0; t < explodedString.Length; t++)
            {
                if (int.TryParse(explodedString[t].ToString(), out int num))
                {
                    numbers.Add(num.ToString());
                }
            }
            
            if (numbers.Count == 2)
            {
                numsToAdd.Add(long.Parse(numbers[0] + numbers[1]));
            }else if (numbers.Count == 1)
            {
                numsToAdd.Add(long.Parse(numbers[0] + numbers[0]));
            }
            else
            {
                numsToAdd.Add(long.Parse(numbers[0] + numbers[numbers.Count - 1]));
            }
        }
        
        int total = 0;
        foreach (int num in numsToAdd)
        {
            total += num;
        }
        return new(total.ToString());
    }
}
