using System;
using System.Collections;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private float timePerTurn;

    //Private variables
    private float timeCounter;
    private int currentTurn;
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
        if(!_timer.Counting(ref timeCounter, timePerTurn))
        {
            currentTurn++;
            if (currentTurn > stopsAmount)
                currentTurn = 1;
            print(currentTurn);
        }
    }

}