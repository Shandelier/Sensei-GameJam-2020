using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheckpoint : MonoBehaviour
{
    public int index = -1;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered collider");
        if(other.tag == "PlayerTag")
        {
            Debug.Log("Player entered collider");
            var myParticleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
            myParticleSystem.Stop();
            Destroy(myParticleSystem, 10);
        }
    }
}
