namespace AdventOfCode2022.Day03; 

public class Day03b {
    private static int TypeToPriority(char type) {
        if (type >= 65 && type <= 90) {
            return (type - 65) + 27;
        }

        if (type >= 97 && type <= 122) {
            return (type - 97) + 1;
        }

        throw new Exception($"Unknown value {type}");
    }

    
    public static void Run(string[] args) {
        var inputs = File.ReadAllLines("../../../Day03/inputs_03a.txt");
        var matches = new List<char>();

        for (var i = 0; i < inputs.Length; i += 3) {
            var rucksack0 = new HashSet<char>(inputs[i+0].ToArray());
            var rucksack1 = new HashSet<char>(inputs[i+1].ToArray());
            var rucksack2 = new HashSet<char>(inputs[i+2].ToArray());
            rucksack0.IntersectWith(rucksack1);
            rucksack0.IntersectWith(rucksack2);
            matches.Add(rucksack0.First());
        }

        var sum = matches.Sum(TypeToPriority);
        Console.WriteLine($"Sum of priorities is {sum}");

    }
}