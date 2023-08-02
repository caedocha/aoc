var input = "./input.txt";
var sections = File.ReadAllLines(input);

void Challenge1()
{
  var totalScore = 0;
  foreach(var section in sections)
  {
    var splittedSections = section.Split(",");
    var firstSection = splittedSections[0];
    var secondSection = splittedSections[1];

    var x = int.Parse(firstSection.Split("-")[0]);
    var y = int.Parse(firstSection.Split("-")[1]);

    var a = int.Parse(secondSection.Split("-")[0]);
    var b = int.Parse(secondSection.Split("-")[1]);

    var result = "";

    if((x <= a) && (y >= b))
    {
      result = "1st pair contains 2nd pair";
      totalScore += 1;
    }
    else if((a <= x) && (b >= y))
    {
      result = "2nd pair contains 1st pair";
      totalScore += 1;
    }
    else
    {
      result = "Nothing";
    }

  }
  Console.WriteLine($"Challenge1 totalScore: '{totalScore}'");
}

void Challenge2()
{
  var totalScore = 0;
  foreach(var section in sections)
  {
    var result = "";
    var splittedSections = section.Split(",");
    var firstSection = splittedSections[0];
    var secondSection = splittedSections[1];

    var x = int.Parse(firstSection.Split("-")[0]);
    var y = int.Parse(firstSection.Split("-")[1]);
    var r1 = Enumerable.Range(x, y-x+1);

    var a = int.Parse(secondSection.Split("-")[0]);
    var b = int.Parse(secondSection.Split("-")[1]);
    var r2 = Enumerable.Range(a, b-a+1);

    var overlap = r1.Intersect(r2);
    var r1p = string.Join(", ", r1.ToList());
    var r2p = string.Join(", ", r2.ToList());
    var o = string.Join(", ", overlap.ToList());

    if(overlap.ToList().Count > 0)
    {
      result = $"+ There is overlap in r1: '{x},{y}' and r2: '{a},{b}'";
      totalScore += 1;
    }
    else
    {
      result = $"- NO overlap in r1: '{x},{y}' and r2: '{a},{b}'";
    }

  }
  Console.WriteLine($"Challenge2 totalScore: '{totalScore}'");
}

Challenge1();
Challenge2();
