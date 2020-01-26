using System;
using System.Collections;
using System.Collections.Generic;
using ECM.Components;
using UnityEngine;

public class ApplyImpulseToPlayerOnTouch : MonoBehaviour
{
    public enum ImpulseMode
    {
        ContactVelocity,
        FixedVelocity
    }

    public ImpulseMode mode = ImpulseMode.ContactVelocity;
    public float impulseStrenght = 5;
    public Vector3 relativeDirection = Vector3.forward;
    public bool affectPlayerOnly;

    void OnCollisionEnter(Collision other)
    {
        var player = other.gameObject.GetComponent<PlayerEntity>();
        if (affectPlayerOnly && player == null)
        {
            return;
        }

        if (mode == ImpulseMode.ContactVelocity)
        {
            var rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                return;
            }
            var vel = rb.GetPointVelocity(other.contacts[0].point);
            if(other.gameObject.GetComponent<Rigidbody>() != null) {
                other.gameObject.GetComponent<Rigidbody>().AddForce(vel.normalized * impulseStrenght, ForceMode.Impulse);
            }
        }
        else
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.rotation  *(relativeDirection * impulseStrenght), ForceMode.Impulse);
        }
        
    }
}
