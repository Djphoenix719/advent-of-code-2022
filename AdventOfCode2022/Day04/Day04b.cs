namespace AdventOfCode2022.Day04; 

public class Day04b {
    record Assignment(int Start, int End);

    private static Assignment StringToAssignment(string value) {
        var parts = value.Split("-");
        return new Assignment(Int32.Parse(parts[0]), Int32.Parse(parts[1]));
    }

    private static bool IsOverlapping(Assignment a, Assignment b) {
        // A ....XXX.......................
        // B ......XXX.....................
        return a.End >= b.Start && a.Start <= b.End;
    }
    
    public static void Run(string[] args) {
        var inputs = File.ReadAllLines("../../../Day04/inputs_04a.txt");

        var count = 0;
        foreach (var input in inputs) {
            var assignmentStrings = input.Split(",");
            var assignmentA = StringToAssignment(assignmentStrings[0]);
            var assignmentB = StringToAssignment(assignmentStrings[1]);

            if (IsOverlapping(assignmentA, assignmentB) || IsOverlapping(assignmentB, assignmentA)) {
                count += 1;
            }
            
        }
        
        Console.WriteLine($"Encapsulated range count is {count}");
        
    }
}