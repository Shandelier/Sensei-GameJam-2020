using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.SoundManager;

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

            if (myParticleSystem != null && this.index != PlayerRespawnData.checkpointIndex) {
                myParticleSystem.Emit(80);
                SoundManager.PlaySound(SoundManager.Sound.Checkpoint);
                // Destroy(myParticleSystem, 10);
            }
        }
    }
}
