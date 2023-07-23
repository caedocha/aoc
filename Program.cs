
var files = Directory.GetFiles(".");
var input = "input.txt";
var maxCounter = 0;

void Challenge1()
{
  foreach(var file in files)
  {
    if(file.Contains(input))
    {
      var counter = 0;
      var lines = File.ReadAllLines(file);
      foreach(var line in lines)
      {
        if(line != "")
        {
	  counter += int.Parse(line);
        }
        else
        {
          if(counter > maxCounter)
	  {
            maxCounter = counter;
	  }
        counter = 0;
        }
      }
    }
  }

  Console.WriteLine($"maxCounter: {maxCounter}");
}

void Challenge2()
{
  var counterSums = new List<int>();
  foreach(var file in files)
  {
    if(file.Contains(input))
    {
      var counter = 0;
      var lines = File.ReadAllLines(file);
      foreach(var line in lines)
      {
        if(line != "")
        {
	  counter += int.Parse(line);
        }
        else
        {
	  counterSums.Add(counter);
          counter = 0;
        }
      }
    }
  }

  Console.WriteLine("--------------- Before");
  foreach(var c in counterSums)
  {
    Console.WriteLine(c);
  }
  counterSums = counterSums.OrderByDescending(i => i).ToList();
  
  Console.WriteLine("--------------- After");
  foreach(var c in counterSums)
  {
    Console.WriteLine(c);
  }

  var top3Counters = counterSums.GetRange(0, 3); 

  foreach(var counter in top3Counters)
  {
    maxCounter += counter;
  }

  Console.WriteLine($"maxCounter: {maxCounter}");
}

// Challenge1();
Challenge2();
