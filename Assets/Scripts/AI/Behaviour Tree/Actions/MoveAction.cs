using UnityEngine;

public class MoveAction : MonoBehaviour, ITask
{
    //Private variables
    private AIBrain _aiBrain;

    //MonoBehaviour calls
    private void Start()
    {
        _aiBrain = GetComponentInParent<AIBrain>();
    }

    //Public methods
    public TaskState Run()
    {
        //Move the agent based on it's navmesh and destination point
        if (_aiBrain.NavMeshAgent.remainingDistance > _aiBrain.NavMeshAgent.stoppingDistance ||
            !_aiBrain.NewDestinationSet)
        {
            _aiBrain.NavMeshAgent.SetDestination(_aiBrain.CurrentPath[_aiBrain.CurrentPathPoint].position);
            _aiBrain.NewDestinationSet = true;
            //Return running while is moving towards it's destination 
            return TaskState.RUNNING;
        }
        
        //Return success upon arrival
        return TaskState.SUCCESS;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }
}