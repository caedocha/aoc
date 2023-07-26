var input = "./input.txt";
var lines = File.ReadAllLines(input);

var OPPONENT_CHOICES = new Dictionary<char, string>()
{
  {'A', "Rock"},
  {'B', "Paper"},
  {'C', "Scissors"}
};

var MY_CHOICES = new Dictionary<char, string>()
{
  {'X', "Rock"},
  {'Y', "Paper"},
  {'Z', "Scissors"}
};

var WHAT_DEFEATS_WHAT = new Dictionary<string, string>()
{
  {"Rock", "Scissors"},
  {"Scissors", "Paper"},
  {"Paper", "Rock"}
};

var CHOICE_SCORE = new Dictionary<string, int>()
{
  {"Rock", 1},
  {"Paper", 2},
  {"Scissors", 3}
};

var OUTCOME_SCORE = new Dictionary<string, int>()
{
  {"Win", 6},
  {"Loss", 0},
  {"Draw", 3}
};

var EXPECTED_OUTCOME = new Dictionary<char, string>()
{
  {'X', "Loss"},
  {'Y', "Draw"},
  {'Z', "Win"}
};

bool DoIWin(string myChoice, string opponentChoice)
{
  return WHAT_DEFEATS_WHAT[myChoice] == opponentChoice;
}

bool DoesOpponentWin(string myChoice, string opponentChoice)
{
  return WHAT_DEFEATS_WHAT[opponentChoice] == myChoice;
}

void Challenge1()
{
        var totalScore = 0;
        foreach(var line in lines)
        {
          var roundScore = 0;
          var chars = line.Split(" ");
          var opponent = OPPONENT_CHOICES[char.Parse(chars[0])];
          var mine = MY_CHOICES[char.Parse(chars[1])];
          var result = "";

          roundScore += CHOICE_SCORE[mine];
          if(DoIWin(mine, opponent))
          {
            result = "win";
            roundScore += OUTCOME_SCORE["Win"];
          }
          else if(DoesOpponentWin(mine, opponent))
          {
            result = "loss";
            roundScore += OUTCOME_SCORE["Loss"];
          }
          else
          {
            result = "draw";
            roundScore += OUTCOME_SCORE["Draw"];
          }

          totalScore += roundScore;

          // Console.WriteLine($"Round stats: mine: {mine}, opponent: {opponent}, result: {result}, roundScore: {roundScore}, total: {totalScore}");
        }

        Console.WriteLine($"Challenge 1 totalScore: {totalScore}");
}

void Challenge2()
{
        var totalScore = 0;
        foreach(var line in lines)
        {
          var mine = "";
          var result = "";
          var roundScore = 0;
          var chars = line.Split(" ");
          var opponent = OPPONENT_CHOICES[char.Parse(chars[0])];
          var expectedOutcome = EXPECTED_OUTCOME[char.Parse(chars[1])];

          if(expectedOutcome == "Win")
          {
            result = "win";
            mine = WHAT_DEFEATS_WHAT.FirstOrDefault( x => x.Value == opponent).Key;
            roundScore += CHOICE_SCORE[mine];
            roundScore += OUTCOME_SCORE["Win"];
          }
          else if(expectedOutcome == "Loss")
          {
            result = "loss";
            mine = WHAT_DEFEATS_WHAT[opponent];
            roundScore += CHOICE_SCORE[mine];
            roundScore += OUTCOME_SCORE["Loss"];
          }
          else if(expectedOutcome == "Draw")
          {
            result = "draw";
            mine = opponent;
            roundScore += CHOICE_SCORE[mine];
            roundScore += OUTCOME_SCORE["Draw"];
          }
          else
          {
            Console.WriteLine("ERROR -----------------------------------------------------------------------------------------------------------------");
          }

          totalScore += roundScore;

          // Console.WriteLine($"Round stats: mine: {mine}, opponent: {opponent}, result: {result}, roundScore: {roundScore}, total: {totalScore}");
        }

        Console.WriteLine($"Challenge 2 totalScore: {totalScore}");
}

Challenge1();
Challenge2();
