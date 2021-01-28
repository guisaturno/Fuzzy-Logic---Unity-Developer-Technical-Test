using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class Parallel : ITask
{
    private List<ITask> tasks = new List<ITask>();
    private List<ITask> runningTasks = new List<ITask>();

    public TaskState Run()
    {
        TaskState result = TaskState.RUNNING;

        void RunTasks(ITask task)
        {
            runningTasks.Add(task);
            TaskState taskState = task.Run();
            runningTasks.Remove(task);

            if (taskState == TaskState.FAILURE)
            {
                result = TaskState.FAILURE;
                Terminate();
            }
            else if (!runningTasks.Any())
            {
                result = taskState;
            }
        }

        for (int i = 0; i < tasks.Count; i++)
        {
            Thread thread = new Thread(() => RunTasks(tasks[i]));
            thread.Start();
        }

        return result;
    }

    public void Terminate()
    {
        for (int i = 0; i < tasks.Count; i++)
            tasks[i].Terminate();
    }

    #region AddTasks

    public void AddTask(ITask task)
    {
        tasks.Add(task);
    }

    public void AddTask(ITask task1, ITask task2)
    {
        tasks.Add(task1);
        tasks.Add(task2);
    }

    public void AddTask(ITask task1, ITask task2, ITask task3)
    {
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
    }

    public void AddTask(ITask task1, ITask task2, ITask task3, ITask task4)
    {
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        tasks.Add(task4);
    }

    public void AddTask(ITask task1, ITask task2, ITask task3, ITask task4, ITask task5)
    {
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        tasks.Add(task4);
        tasks.Add(task5);
    }

    public void AddTask(ITask task1, ITask task2, ITask task3, ITask task4, ITask task5, ITask task6)
    {
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        tasks.Add(task4);
        tasks.Add(task5);
        tasks.Add(task6);
    }

    public void AddTask(ITask task1, ITask task2, ITask task3, ITask task4, ITask task5, ITask task6, ITask task7)
    {
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        tasks.Add(task4);
        tasks.Add(task5);
        tasks.Add(task6);
        tasks.Add(task7);
    }

    public void AddTask(ITask task1, ITask task2, ITask task3, ITask task4, ITask task5, ITask task6, ITask task7,
        ITask task8)
    {
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        tasks.Add(task4);
        tasks.Add(task5);
        tasks.Add(task6);
        tasks.Add(task7);
        tasks.Add(task8);
    }

    public void AddTask(ITask task1, ITask task2, ITask task3, ITask task4, ITask task5, ITask task6, ITask task7,
        ITask task8, ITask task9)
    {
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        tasks.Add(task4);
        tasks.Add(task5);
        tasks.Add(task6);
        tasks.Add(task7);
        tasks.Add(task8);
        tasks.Add(task9);
    }

    public void AddTask(ITask task1, ITask task2, ITask task3, ITask task4, ITask task5, ITask task6, ITask task7,
        ITask task8, ITask task9, ITask task10)
    {
        tasks.Add(task1);
        tasks.Add(task2);
        tasks.Add(task3);
        tasks.Add(task4);
        tasks.Add(task5);
        tasks.Add(task6);
        tasks.Add(task7);
        tasks.Add(task8);
        tasks.Add(task9);
        tasks.Add(task10);
    }

    #endregion

    public void RemoveTask(ITask task)
    {
        tasks.Remove(task);
    }
}