using System.Collections.Generic;
using UnityEngine;

public class Sequence : ITask
{
    private List<ITask> tasks = new List<ITask>();
    private int currentTask;

    public TaskState Run()
    {
        TaskState taskState;

        for (int i = 0; i < tasks.Count; i++)
        {
            //Debug.Log("Sequence Task N° " + i);
            taskState = tasks[i].Run();

            if (taskState == TaskState.RUNNING)
                return TaskState.RUNNING;

            if (taskState == TaskState.FAILURE)
                return TaskState.FAILURE;
        }

        return TaskState.SUCCESS;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }

    //public TaskState Run()
    // {
    //     Debug.Log("Sequence Task N° " + currentTask);
    //     
    //     TaskState taskState;
    //     taskState = tasks[currentTask].Run();
    //
    //     if (taskState == TaskState.running)
    //         return TaskState.running;
    //
    //     if (taskState == TaskState.failure)
    //     {
    //         currentTask = 0;
    //         return TaskState.failure;
    //     }
    //     
    //     currentTask++;
    //
    //     if (currentTask == tasks.Count)
    //         currentTask = 0;
    //
    //     return TaskState.success;
    // }

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