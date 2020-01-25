using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfreezeOnTouch : MonoBehaviour
{
    public GameObject target;
    public Vector3 impulse;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<PlayerEntity>() == null)
        {
            return;
        }
        
        if (target == null)
        {
            target = gameObject;
        }
        
        
        var targetRb = target.GetComponent<Rigidbody>();
        if (targetRb == null)
        {
            targetRb = target.AddComponent<Rigidbody>();
        }
        
        targetRb.isKinematic = false;
        targetRb.AddForce(impulse, ForceMode.Impulse);
    }
}
