using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour, ITask
{
    //Private variables
    private AIBrain _aiBrain;

    private void Start()
    {
        _aiBrain = GetComponentInParent<AIBrain>();
    }

    public TaskState Run()
    {
        if (_aiBrain.NavMeshAgent.remainingDistance > _aiBrain.NavMeshAgent.stoppingDistance ||
            !_aiBrain.NewDestinationSet)
        {
            if (_aiBrain.IsWaiting)
                _aiBrain.NavMeshAgent.speed = 0;
            else
                _aiBrain.NavMeshAgent.speed = _aiBrain.DefaultSpeed;
            
            _aiBrain.NavMeshAgent.SetDestination(_aiBrain.CurrentPath[_aiBrain.CurrentPathPoint].position);
            _aiBrain.NewDestinationSet = true;
            print("is moving");
            return TaskState.RUNNING;
        }

        print("isn't moving");
        return TaskState.SUCCESS;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }
}