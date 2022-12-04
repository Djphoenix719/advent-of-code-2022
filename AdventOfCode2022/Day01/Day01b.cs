namespace AdventOfCode2022.Day01; 

public static class Day01b {
    public static void Run(string[] args) {
        var inputs = File.ReadAllLines("../../../Day01/inputs_01b.txt");

        var bestGroups = new List<int> {
            0, // Third best 
            0, // Second best
            0  // First Best
        };
        var currentGroup = 0;
        foreach (var calories in inputs) {
            if (calories == "") {
                if (currentGroup > bestGroups[0]) {
                    bestGroups[0] = currentGroup;
                    bestGroups.Sort();
                }

                currentGroup = 0;
                continue;
            }
            currentGroup += Int32.Parse(calories);
        }
        
        Console.WriteLine($"The top three elves are carrying {bestGroups.Sum()} calories.");
    }
}