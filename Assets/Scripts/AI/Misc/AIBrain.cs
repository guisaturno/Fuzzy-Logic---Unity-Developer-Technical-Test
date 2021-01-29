using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private List<Transform> _currentPath;

    //Private variables
    private NavMeshAgent _navMeshAgent;
    private bool newDestinationSet;
    private int currentPathPoint;
    private bool isWaiting;
    private float defaultSpeed;

    //Properties
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    public float DefaultSpeed => defaultSpeed;

    public List<Transform> CurrentPath
    {
        get => _currentPath;
        set => _currentPath = value;
    }

    public bool NewDestinationSet
    {
        get => newDestinationSet;
        set => newDestinationSet = value;
    }

    public int CurrentPathPoint
    {
        get => currentPathPoint;
        set => currentPathPoint = value;
    }

    public bool IsWaiting
    {
        get => isWaiting;
        set => isWaiting = value;
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        defaultSpeed = _navMeshAgent.speed;
    }
}