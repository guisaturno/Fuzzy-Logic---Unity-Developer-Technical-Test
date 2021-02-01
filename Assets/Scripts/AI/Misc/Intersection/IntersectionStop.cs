using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class IntersectionStop : MonoBehaviour
{
    //Serialized variables
    [SerializeField] private int myTurnNumber;

    //Private variables
    private Intersection _intersection;

    //MonoBehaviour callbacks
    private void Start()
    {
        _intersection = GetComponentInParent<Intersection>();

        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            if (_intersection.CurrentTurn == myTurnNumber)
                other.GetComponentInParent<AIBrain>().IsWaiting = false;
            else
                other.GetComponentInParent<AIBrain>().IsWaiting = true;
        }
    }
}