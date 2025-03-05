using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace src.Models
{
    public class Simulation
    {
        private readonly ThreadPool _threadPool;
        private readonly List<Action> _tasks;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private readonly List<TaskInfo> _taskInfos = new List<TaskInfo>();

        public Simulation(int numThreads, List<Action> tasks)
        {
            _threadPool = new ThreadPool(numThreads);
            _tasks = tasks;
        }

        public void Run()
        {
            _stopwatch.Start();

            for (int i = 0; i < _tasks.Count; i++)
            {
                int taskId = i;
                Action originalTask = _tasks[taskId];
                Action timedTask = () =>
                {
                    var taskInfo = new TaskInfo { TaskId = taskId, StartTime = _stopwatch.ElapsedMilliseconds };
                    originalTask.Invoke();
                    taskInfo.EndTime = _stopwatch.ElapsedMilliseconds;
                    _taskInfos.Add(taskInfo);
                };
                _threadPool.AddTask(timedTask);
            }

            _threadPool.Shutdown();
            _stopwatch.Stop();

            GenerateReport();
        }

        private void GenerateReport()
        {
            Console.WriteLine("______________________________ Simulation Report ______________________________");
            Console.WriteLine($"Total Simulation Time: {_stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Total Allocated Threads: {_threadPool.AllocatedThreads}");
            Console.WriteLine($"Total Completed Tasks: {_threadPool.CompletedTasks}");
            Console.WriteLine($"Unused Threads: {_threadPool.UnusedThreads}");
            Console.WriteLine("_______________________________________________________________________________\n");

            Console.WriteLine("_____________________________ Task Timing Report ______________________________");
            foreach (var taskInfo in _taskInfos)
            {
                Console.WriteLine($"Task {taskInfo.TaskId + 1}: Start Time = {taskInfo.StartTime} ms, End Time = {taskInfo.EndTime} ms, Duration = {taskInfo.Duration} ms");
            }
            Console.WriteLine("_______________________________________________________________________________\n");
        }
    }
}