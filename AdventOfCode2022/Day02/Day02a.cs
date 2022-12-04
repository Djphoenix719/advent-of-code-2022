namespace AdventOfCode2022.Day02; 

public class Day02a {
    private enum RPS {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    private record Round(RPS Opponent, RPS Self) {
        private int ChoiceScore {
            get {
                return Self switch {
                    RPS.Rock => 1,
                    RPS.Paper => 2,
                    RPS.Scissors => 3,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        private int GameScore {
            get {
                // Interestingly this collection of scores is effectively shifted one position.
                //  That property could be used to make this less of a case-by-case thing, but
                //  this is fine for a simple solution.
                return Self switch {
                    RPS.Rock => Opponent switch {
                        RPS.Rock => 3,
                        RPS.Paper => 0,
                        RPS.Scissors => 6,
                        _ => throw new ArgumentOutOfRangeException()
                    },
                    RPS.Paper =>  Opponent switch {
                        RPS.Rock => 6,
                        RPS.Paper => 3,
                        RPS.Scissors => 0,
                        _ => throw new ArgumentOutOfRangeException()
                    },
                    RPS.Scissors =>  Opponent switch {
                        RPS.Rock => 0,
                        RPS.Paper => 6,
                        RPS.Scissors => 3,
                        _ => throw new ArgumentOutOfRangeException()
                    },
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
        }

        public int Score => ChoiceScore + GameScore;
    }

    private static RPS OpponentToRPS(string input) {
        return input switch {
            "A" => RPS.Rock,
            "B" => RPS.Paper,
            "C" => RPS.Scissors,
            _ => throw new Exception($"Unknown opponent case {input}")
        };
    }
    private static RPS SelfToRPS(string input) {
        return input switch {
            "X" => RPS.Rock,
            "Y" => RPS.Paper,
            "Z" => RPS.Scissors,
            _ => throw new Exception($"Unknown self case {input}")
        };
    }
    
    
    public static void Run(string[] args) {
        var inputs = File.ReadAllLines("../../../Day02/inputs_02a.txt");
        var rpsInputs = inputs.Select(input => {
            var splitInput = input.Split(" ");
            var opponent = OpponentToRPS(splitInput[0]);
            var self = SelfToRPS(splitInput[1]);
            return new Round(opponent, self);
        }).ToArray();
        
        Console.WriteLine($"Score if everything goes according to plan is {rpsInputs.Sum(round => round.Score)}");


    }
}