using src.Models;

string filePath = "./Inputs/input_2.txt";

var lines = File.ReadAllLines(filePath);
int maxThreads = int.Parse(lines[0]);

List<Action> tasks = new List<Action>();
foreach (var line in lines[1..]) // lines[1..] skip firts line because of maxThreads
{
    var parts = line.Split(' ');
    tasks.Add(() =>
    {
        Thread.Sleep(int.Parse(parts[1]));
        Console.WriteLine($"{parts[0]} completed");
    });
}

var simulation = new Simulation(maxThreads, tasks);
simulation.Run();
