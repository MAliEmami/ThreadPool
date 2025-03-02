using src.Models;

// Example input parameters
int maxThreads = 10;
var tasks = new List<Action>
{
    () => { Thread.Sleep(500); Console.WriteLine("Task 1 completed"); },
    () => { Thread.Sleep(300); Console.WriteLine("Task 2 completed"); },
    () => { Thread.Sleep(200); Console.WriteLine("Task 3 completed"); },
    () => { Thread.Sleep(400); Console.WriteLine("Task 4 completed"); },
    () => { Thread.Sleep(100); Console.WriteLine("Task 5 completed"); },
    () => { Thread.Sleep(150); Console.WriteLine("Task 6 completed"); }
};

var simulation = new Simulation(maxThreads, tasks);
simulation.Run();