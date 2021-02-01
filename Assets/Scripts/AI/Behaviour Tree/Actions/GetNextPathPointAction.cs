using UnityEngine;

public class GetNextPathPointAction : MonoBehaviour, ITask
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
        //Verify if the list went full circle and assign the next path point
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