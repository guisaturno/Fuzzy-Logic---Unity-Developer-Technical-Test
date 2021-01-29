using UnityEngine;

public class WaintingCheck : MonoBehaviour, ITask
{
    //Private variables
    private AIBrain _aiBrain;

    private void Start()
    {
        _aiBrain = GetComponentInParent<AIBrain>();
    }
    
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
