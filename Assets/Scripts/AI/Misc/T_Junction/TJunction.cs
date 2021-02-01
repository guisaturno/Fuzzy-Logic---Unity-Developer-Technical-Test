using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class TJunction : MonoBehaviour
{
    //Private variables
    private bool isSafeRight;
    private bool isSafeLeft;

    //Properties
    public bool IsSafeRight
    {
        set => isSafeRight = value;
    }

    public bool IsSafeLeft
    {
        set => isSafeLeft = value;
    }

    //MonoBehaviour callbacks
    private void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            AIBrain otherBrain = other.GetComponent<AIBrain>();

            //Decide if it is safe to proceed, based on where it is headed, and from which side there are agents coming
            if (otherBrain.CurrentPath[otherBrain.CurrentPathPoint].position.x < gameObject.transform.position.x)
            {
                if (isSafeRight)
                    otherBrain.IsWaiting = false;
                else
                    otherBrain.IsWaiting = true;
            }
            else if (isSafeLeft)
                otherBrain.IsWaiting = false;
            else
                otherBrain.IsWaiting = true;
        }
    }
}