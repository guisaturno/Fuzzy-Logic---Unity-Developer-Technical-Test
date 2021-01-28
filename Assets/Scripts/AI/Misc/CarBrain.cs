using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBrain : AIBrain
{
    //Serialized variables
    [SerializeField] private float safeDistance;
    
    //Private variables
    private bool isAtSafeDistance;
    
    //Properties
    public float SafeDistance => safeDistance;

    public bool IsAtSafeDistance
    {
        get => isAtSafeDistance;
        set => isAtSafeDistance = value;
    }
}
