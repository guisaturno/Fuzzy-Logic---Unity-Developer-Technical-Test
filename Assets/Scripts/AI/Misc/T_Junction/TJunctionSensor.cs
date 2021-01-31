using System;
using UnityEngine;

public class TJunctionSensor : MonoBehaviour
{
    [SerializeField] private bool isRightSensor;

    //Private variables
    private TJunction tJunction;

    private void Start()
    {
        tJunction = GetComponentInParent<TJunction>();

        GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            if (isRightSensor)
                tJunction.IsSafeRight = false;
            else
                tJunction.IsSafeLeft = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            if (isRightSensor)
                tJunction.IsSafeRight = true;
            else
                tJunction.IsSafeLeft = true;
        }
    }
}