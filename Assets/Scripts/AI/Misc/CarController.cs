using UnityEngine;

public class CarController : MonoBehaviour
{
    //Sequences
    private Sequence mainSequence;

    //Actions
    private MoveAction _moveAction;
    private GetNextPathPointAction _getNextPathPointAction;

    //Checks
    private SafeDistanceCheck _safeDistanceCheck;

    private void Awake()
    {
        //AI structure
        mainSequence = new Sequence();

        //Actions
        _moveAction = GetComponentInChildren<MoveAction>();
        _getNextPathPointAction = GetComponentInChildren<GetNextPathPointAction>();

        //Checks
        _safeDistanceCheck = GetComponentInChildren<SafeDistanceCheck>();
    }

    private void Start()
    {
        mainSequence.AddTask(_moveAction, _getNextPathPointAction);
    }

    private void Update()
    {
        mainSequence.Run();
        
        /*NOTE: The ideal way to implement the following line, would be to perform a parallel task withing the main
        sequence,running the check alongside the move action. However, the behaviour tree system is at it's early stages
        of development and for the time being does not support it*/
        _safeDistanceCheck.Run();
    }
}