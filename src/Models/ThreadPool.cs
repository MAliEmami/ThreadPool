public class ThreadPool
{
    private readonly int _maxThreads;
    private readonly Queue<Action> _taskQueue = new Queue<Action>();
    private readonly List<Thread> _workerThreads = new List<Thread>();
    private readonly object _lock = new object();
    private bool _isRunning = true;
    private int _allocatedThreads = 0;
    private int _completedTasks = 0;

    public ThreadPool(int maxThreads)
    {
        _maxThreads = maxThreads;
        InitializeWorkerThreads();
    }

    private void InitializeWorkerThreads()
    {
        for (int i = 0; i < _maxThreads; i++)
        {
            var worker = new Thread(WorkerThreadProc);
            worker.Start();
            _workerThreads.Add(worker);
        }
    }

    public void AddTask(Action task)
    {
        lock (_lock)
        {
            _taskQueue.Enqueue(task);
            Monitor.Pulse(_lock); // Notify a waiting worker thread
        }
    }

    private void WorkerThreadProc()
    {
        while (_isRunning)
        {
            Action? task = null;
            lock (_lock)
            {
                while (_taskQueue.Count == 0 && _isRunning)
                {
                    Monitor.Wait(_lock);
                }

                if (_taskQueue.Count > 0)
                {
                    task = _taskQueue.Dequeue();
                    _allocatedThreads++;
                }
            }

            task?.Invoke(); // Execute the task
            Interlocked.Increment(ref _completedTasks);
        }
    }

    public void Shutdown()
    {
        _isRunning = false;
        lock (_lock)
        {
            Monitor.PulseAll(_lock); // Wake up all threads
        }

        foreach (var worker in _workerThreads)
        {
            worker.Join();
        }
    }

    public int AllocatedThreads => _allocatedThreads;
    public int CompletedTasks => _completedTasks;
    public int UnusedThreads => _maxThreads - _allocatedThreads;
}