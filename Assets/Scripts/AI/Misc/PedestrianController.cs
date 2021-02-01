using UnityEngine;

public class PedestrianController : MonoBehaviour
{
    //Sequences
    private Sequence mainSequence;

    //Actions
    private MoveAction _moveAction;
    private GetNextPathPointAction _getNextPathPointAction;

    //MonoBehaviour callbacks
    private void Awake()
    {
        //AI structure
        mainSequence = new Sequence();

        //Actions
        _moveAction = GetComponentInChildren<MoveAction>();
        _getNextPathPointAction = GetComponentInChildren<GetNextPathPointAction>();
    }

    private void Start()
    {
        mainSequence.AddTask(_moveAction, _getNextPathPointAction);
    }

    private void Update()
    {
        mainSequence.Run();
    }
}
