var input = "./input.txt";
var rucksacks = File.ReadAllLines(input);

int CalculatePosition(char commonItem)
{
          var position = (int) commonItem % 32;

          if(char.IsUpper(commonItem))
          {
            position += 26;
          }

          return position;
}

void Challenge1()
{
        var totalScore = 0;
        foreach(var rucksack in rucksacks)
        {
          var middleIndex = rucksack.Length / 2;
          var compartment1 = rucksack
                  .Substring(0, middleIndex)
                  .ToList()
                  .OrderBy(i => i);

          var compartment2 = rucksack
                  .Substring(middleIndex)
                  .ToList()
                  .OrderBy(i => i);

          var commonItem = compartment1
                  .Intersect(compartment2)
                  .FirstOrDefault();

          var position = CalculatePosition(commonItem);

          totalScore += position;
        }

        Console.WriteLine($"Challenge1 totalScore: {totalScore}");
}


List<List<string>> groupRucksacks(string[] rucksacks)
{
        var groups = new List<List<string>>();
        var currentGroup = new List<string>();
        foreach(var rucksack in rucksacks)
        {
                if(currentGroup.Count == 3)
                {
                  groups.Add(currentGroup);

                  currentGroup = new List<string>();
                  currentGroup.Add(rucksack);
                }
                else
                {
                  currentGroup.Add(rucksack);
                }
        }
        groups.Add(currentGroup); // Add last group of rucksack manually
        return groups;
}

void Challenge2()
{
  var totalScore = 0;
  var groups = groupRucksacks(rucksacks);

  foreach(var currentGroup in groups)
  {
          var item1 = currentGroup[0].ToList();
          var item2 = currentGroup[1].ToList();
          var item3 = currentGroup[2].ToList();
          var intersect1 = item1.Intersect(item2);
          var intersect2 = intersect1.Intersect(item3);

          var i = intersect2.FirstOrDefault();

          var position = CalculatePosition(i);
          totalScore += position;
  }
  Console.WriteLine($"Challenge2 totalScore: {totalScore}");
}

Challenge1();
Challenge2();
