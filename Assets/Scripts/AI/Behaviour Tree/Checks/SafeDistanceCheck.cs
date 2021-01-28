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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            if (hit.collider.gameObject.CompareTag("Vehicle"))
                _aiBrain.NavMeshAgent.SetDestination(transform.position);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }

        return TaskState.SUCCESS;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }
}
