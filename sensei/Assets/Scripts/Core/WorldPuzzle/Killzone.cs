using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var respwaner = other.gameObject.GetComponent<ObjectRespawner>();
        if (respwaner != null)
        {
            respwaner.Respawn();
        }
    }
}
