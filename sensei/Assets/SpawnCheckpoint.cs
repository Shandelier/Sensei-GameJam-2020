using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCheckpoint : MonoBehaviour
{
    public int index = -1;

    void Start() {
        var myParticleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        if (myParticleSystem != null) {
            myParticleSystem.Stop();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered collider");
        if(other.tag == "PlayerTag")
        {
            Debug.Log("Player entered collider");
            var myParticleSystem = gameObject.GetComponentInChildren<ParticleSystem>();

            if (myParticleSystem != null) {
                myParticleSystem.Emit(80);
                // Destroy(myParticleSystem, 10);
            }
        }
    }
}
