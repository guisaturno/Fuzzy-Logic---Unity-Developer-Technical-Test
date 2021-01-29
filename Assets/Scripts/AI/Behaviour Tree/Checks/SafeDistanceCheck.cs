using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class SafeDistanceCheck : MonoBehaviour, ITask
{
    private CarBrain _carBrain;
    private bool isAtSafeDistance;

    private void Start()
    {
        _carBrain = GetComponentInParent<CarBrain>();

        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        isAtSafeDistance = true;
    }

    public TaskState Run()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2) &&
            _carBrain.AtCrossing)
        {
            if (hit.collider.gameObject.CompareTag("VehicleRear"))
                _carBrain.NavMeshAgent.speed = 0;
        }

        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.yellow);

        if (isAtSafeDistance)
            return TaskState.SUCCESS;

        _carBrain.NavMeshAgent.speed = 0;
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