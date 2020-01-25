using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRespawner : MonoBehaviour
{
    Vector3 location;
    Quaternion rotation;
    
    void Start()
    {
        location = transform.position;
        rotation = transform.rotation;
    }

    public void Respawn()
    {
        transform.position = location;
        transform.rotation = rotation;

        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
