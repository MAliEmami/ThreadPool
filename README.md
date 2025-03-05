# Thread Pool

## Overview
This project is a simple implementation of a thread pool in C#. The program reads a list of tasks from an input file, assigns them to a thread pool with a specified maximum number of threads, and executes them concurrently. After execution, it generates a report summarizing the execution time of each task and the overall simulation performance.
This project is the Final Project for the Operating Systems course at Bu-Ali Sina University during the Fall 1403 semester, showcasing key concepts of multi-threading, synchronization, and task scheduling.

## Features
- Custom thread pool implementation.
- Concurrent execution of tasks.
- Task scheduling and execution management.
- Simulation report including execution time and resource utilization.

## Getting Started
### Prerequisites
- .NET SDK installed
- Basic knowledge of C# and multi-threading

### Installation
1. Clone the repository:
   ```sh
   git clone 
   cd ThreadPool
   ```
2. Build the project:
   ```sh
   dotnet build
   ```

### Usage
1. Modify `Program.cs` to specify the input file:
   ```csharp
   string filePath = "./Inputs/input_1.txt";
   ```
2. Run the program:
   ```sh
   dotnet run
   ```
3. The program reads tasks from the input file, executes them using the thread pool, and prints a detailed simulation report.

## Input File Format
The input file should follow this format:
```
<max_threads>
<task_name> <execution_time_in_ms>
<task_name> <execution_time_in_ms>
...
```
### Example Input:
```
10
Task1 500
Task2 300
Task3 200
Task4 400
Task5 100
Task6 150
```

## Simulation Report Example
```
______________________________ Simulation Report ______________________________
Total Simulation Time: 504 ms
Total Allocated Threads: 6
Total Completed Tasks: 10
Unused Threads: 4
_______________________________________________________________________________

_____________________________ Task Timing Report ______________________________
Task 5:  Allocation = 0 ms,      Completion = 107 ms,    Duration = 107 ms
Task 6:  Allocation = 0 ms,      Completion = 153 ms,    Duration = 153 ms
Task 3:  Allocation = 0 ms,      Completion = 201 ms,    Duration = 201 ms
Task 2:  Allocation = 0 ms,      Completion = 312 ms,    Duration = 312 ms
Task 4:  Allocation = 0 ms,      Completion = 408 ms,    Duration = 408 ms
Task 1:  Allocation = 0 ms,      Completion = 504 ms,    Duration = 504 ms
_______________________________________________________________________________
```