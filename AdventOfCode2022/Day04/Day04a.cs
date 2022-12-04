namespace AdventOfCode2022.Day04; 

public class Day04a {
    record Assignment(int Start, int End);

    private static Assignment StringToAssignment(string value) {
        var parts = value.Split("-");
        return new Assignment(Int32.Parse(parts[0]), Int32.Parse(parts[1]));
    }

    private static bool IsWithin(Assignment a, Assignment b) {
        return (a.Start >= b.Start && a.End <= b.End);
    }
    
    public static void Run(string[] args) {
        var inputs = File.ReadAllLines("../../../Day04/inputs_04a.txt");

        var count = 0;
        foreach (var input in inputs) {
            var assignmentStrings = input.Split(",");
            var assignmentA = StringToAssignment(assignmentStrings[0]);
            var assignmentB = StringToAssignment(assignmentStrings[1]);

            if (IsWithin(assignmentA, assignmentB) || IsWithin(assignmentB, assignmentA)) {
                count += 1;
            }
            
        }
        
        Console.WriteLine($"Encapsulated range count is {count}");
        
    }
}