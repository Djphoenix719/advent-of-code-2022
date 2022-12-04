namespace AdventOfCode2022.Day03; 

public class Day03a {

    record Rucksack(string Left, string Right);

    private static int TypeToPriority(char type) {
        if (type >= 65 && type <= 90) {
            return (type - 65) + 27;
        }

        if (type >= 97 && type <= 122) {
            return (type - 97) + 1;
        }

        throw new Exception($"Unknown value {type}");
    }

    private static Rucksack StringToRucksack(string input) {
        var length = input.Length / 2;
        return new Rucksack(input[Range.EndAt(length)], input[Range.StartAt(length)]);
    }

    
    public static void Run(string[] args) {
        var inputs = File.ReadAllLines("../../../Day03/inputs_03a.txt");
        var inputRucksacks = inputs.Select(StringToRucksack).ToArray();
        var matches = new List<char>();

        foreach (var rucksack in inputRucksacks) {
            var charSetLeft = new HashSet<char>(rucksack.Left.ToArray());
            var charSetRight = new HashSet<char>(rucksack.Right.ToArray());
            charSetLeft.IntersectWith(charSetRight);
            matches.Add(charSetLeft.First());
        }

        var sum = matches.Sum(TypeToPriority);
        Console.WriteLine($"Sum of priorities is {sum}");

    }
}