using System;
using UnityEngine;

public class CarBrain : AIBrain
{
    [SerializeField] private float rotationSpeed;

    //Private variables
    private bool atCrossing;

    //Properties
    public bool AtCrossing
    {
        get => atCrossing;
        set => atCrossing = value;
    }

    private void FixedUpdate()
    {
        //Rotates in towards its next path point while at a navmesh link
        if (_navMeshAgent.isOnOffMeshLink)
        {
            Vector3 target = new Vector3(_currentPath[currentPathPoint].position.x, transform.position.y,
                _currentPath[currentPathPoint].position.z);
            
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, target - transform.position,
                rotationSpeed * Time.fixedDeltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}