using UnityEngine;

public class WaintingCheck : MonoBehaviour, ITask
{
    //Private variables
    private AIBrain _aiBrain;

    //MonoBehaviour callbacks
    private void Start()
    {
        _aiBrain = GetComponentInParent<AIBrain>();
    }
    
    //Public methods
    public TaskState Run()
    {
        if (_aiBrain.IsWaiting)
        {
            _aiBrain.NavMeshAgent.speed = 0;
            return TaskState.SUCCESS;
        }
        
        _aiBrain.NavMeshAgent.speed = _aiBrain.DefaultSpeed;
        return TaskState.SUCCESS;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }
}
