using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class SafeDistanceCheck : MonoBehaviour, ITask
{
    private AIBrain _aiBrain;
    private bool isAtSafeDistance;

    private void Start()
    {
        _aiBrain = GetComponentInParent<AIBrain>();
        
        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        isAtSafeDistance = true;
    }

    public TaskState Run()
    {
        if (isAtSafeDistance)
            return TaskState.SUCCESS;

        _aiBrain.NavMeshAgent.speed = 0;
        return TaskState.FAILURE;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("VehicleRear"))
            isAtSafeDistance = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("VehicleRear"))
            isAtSafeDistance = true;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }
}