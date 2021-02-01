using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class SafeDistanceCheck : MonoBehaviour, ITask
{
    //Private variables
    private CarBrain _carBrain;
    private bool isAtSafeDistance;

    //MonoBehaviour callbacks
    private void Start()
    {
        _carBrain = GetComponentInParent<CarBrain>();

        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        isAtSafeDistance = true;
    }

    //Public methods
    public TaskState Run()
    {
        //Verify if there is enough space between the car ahead and the pedestrian crossing
        //assuring not to stop on top of it
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2) &&
            _carBrain.AtCrossing)
        {
            if (hit.collider.gameObject.CompareTag("VehicleRear"))
                _carBrain.NavMeshAgent.speed = 0;
        }

        //Return success and proceed to next task if the agent is at a safe distance
        if (isAtSafeDistance)
            return TaskState.SUCCESS;

        //Stop the agent movement, returning failure not proceeding to the next task
        _carBrain.NavMeshAgent.speed = 0;
        return TaskState.FAILURE;
    }

    public void Terminate()
    {
        throw new System.NotImplementedException();
    }

    //Private methods
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
}