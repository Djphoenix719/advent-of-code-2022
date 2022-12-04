namespace AdventOfCode2022.Day01; 

public static class Day01a {
    public static void Run(string[] args) {
        var inputs = File.ReadAllLines("../../../Day01/inputs_01a.txt");

        var bestGroup = 0;
        var currentGroup = 0;
        foreach (var calories in inputs) {
            if (calories == "") {
                if (currentGroup > bestGroup) {
                    bestGroup = currentGroup;
                }

                currentGroup = 0;
                continue;
            }
            currentGroup += Int32.Parse(calories);
        }
        
        Console.WriteLine($"The elf carrying the most calories is carrying {bestGroup} calories.");
    }
}