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

        var player = other.gameObject.GetComponent<PlayerEntity>();
        if (player)
        {
            Transform playerTransform = GameObject.FindGameObjectsWithTag("PlayerTag")[0].GetComponent<Transform>();
            playerTransform.position = PlayerRespawnData.checkpointLocation;
            player.died.Invoke();

        }
    }
}
