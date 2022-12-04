namespace AdventOfCode2022.Day02; 

public class Day02b {
    private enum RPS {
        Rock = 0,
        Paper = 1,
        Scissors = 2
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
    private static RPS SelfToRPS(RPS opponent, string input) {
        // Need to draw == index+0
        // Need to win == index+1
        // Need to lose == index+2
        RPS[] choices = { RPS.Rock, RPS.Paper, RPS.Scissors };

        int indexOf(RPS choice, int offset) {
            var index = (int)choice;
            return (index + offset) % 3;
        }
        
        // X == need to lose
        // Y == need to draw
        // Z == need to win
        return input switch {
            "X" => choices[indexOf(opponent, 2)],
            "Y" => choices[indexOf(opponent, 0)],
            "Z" => choices[indexOf(opponent, 1)],
            _ => throw new Exception($"Unknown self case {input}")
        };
    }
    
    
    public static void Run(string[] args) {
        var inputs = File.ReadAllLines("../../../Day02/inputs_02a.txt");
        var rpsInputs = inputs.Select(input => {
            var splitInput = input.Split(" ");
            var opponent = OpponentToRPS(splitInput[0]);
            var self = SelfToRPS(opponent, splitInput[1]);
            return new Round(opponent, self);
        }).ToArray();
        
        Console.WriteLine($"Score if everything goes according to plan is {rpsInputs.Sum(round => round.Score)}");


    }
}