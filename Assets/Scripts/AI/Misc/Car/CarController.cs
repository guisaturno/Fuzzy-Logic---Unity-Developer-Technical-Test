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
    private WaintingCheck _waintingCheck;

    //MonoBehaviour callbacks
    private void Awake()
    {
        //AI structure
        mainSequence = new Sequence();

        //Actions
        _moveAction = GetComponentInChildren<MoveAction>();
        _getNextPathPointAction = GetComponentInChildren<GetNextPathPointAction>();

        //Checks
        _safeDistanceCheck = GetComponentInChildren<SafeDistanceCheck>();
        _waintingCheck = GetComponentInChildren<WaintingCheck>();
    }

    private void Start()
    {
        mainSequence.AddTask(_waintingCheck, _safeDistanceCheck, _moveAction, _getNextPathPointAction);
    }

    private void Update()
    {
        mainSequence.Run();
    }
}