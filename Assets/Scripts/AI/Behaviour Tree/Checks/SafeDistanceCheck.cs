using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeDistanceCheck : MonoBehaviour, ITask
{
    private AIBrain _aiBrain;

    private void Start()
    {
        _aiBrain = GetComponentInParent<AIBrain>();
    }

    public TaskState Run()
    {
        
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1) 
            || Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1))
        {
            if (hit.collider.gameObject.CompareTag("Vehicle"))
                _aiBrain.NavMeshAgent.speed = 0;
            
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left) * hit.distance,
                Color.yellow);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance,
                Color.yellow);
        }
        

        return TaskState.SUCCESS;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }
}