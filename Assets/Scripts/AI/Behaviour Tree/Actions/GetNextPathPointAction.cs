using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNextPathPointAction : MonoBehaviour, ITask
{
    private AIBrain _aiBrain;

    private void Start()
    {
        _aiBrain = GetComponentInParent<AIBrain>();
    }

    public TaskState Run()
    {
        if (_aiBrain.CurrentPathPoint == _aiBrain.CurrentPath.Count - 1)
            _aiBrain.CurrentPathPoint = 0;
        else
            _aiBrain.CurrentPathPoint++;

        _aiBrain.NewDestinationSet = false;
        return TaskState.SUCCESS;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }
}