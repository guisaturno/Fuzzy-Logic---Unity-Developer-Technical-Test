using UnityEngine;

public class Intersection : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private float timePerTurn;
    [SerializeField] private float delayTime;
    
    //Private variables
    private float timeCounter;
    private bool atDelayTime;
    private int currentTurn;
    private int delayedTurn;
    private int stopsAmount;
    private Timer _timer;

    //Properties
    public int CurrentTurn => currentTurn;

    private void Start()
    {
        _timer = new Timer();
        IntersectionStop[] count = GetComponentsInChildren<IntersectionStop>();
        stopsAmount = count.Length;
    }

    private void FixedUpdate()
    {
        if (atDelayTime && !_timer.Counting(ref timeCounter, delayTime))
        {
            atDelayTime = false;
            currentTurn = delayedTurn;
        }
        
        if(!atDelayTime && !_timer.Counting(ref timeCounter, timePerTurn))
        {
            atDelayTime = true;
            currentTurn = 0;
            delayedTurn++;
            if (delayedTurn > stopsAmount)
                delayedTurn = 1;
        }
    }

}