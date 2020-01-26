using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnData {
    public static Vector3 checkpointLocation;
    public static int checkpointIndex = -1;
}

public class PlayerRespawn : MonoBehaviour
{
    Transform playerTransform;

    void Start() {
        this.playerTransform = GameObject.FindGameObjectsWithTag("PlayerTag")[0].GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("1");    
        if(other.tag == "PlayerTag") {
            SpawnCheckpoint spawnCheckpoint = this.GetComponent<SpawnCheckpoint>();
            Vector3 spawnPosition = this.GetComponent<Transform>().position;

            if(PlayerRespawnData.checkpointIndex != spawnCheckpoint.index) {
                Debug.Log("2");    

                PlayerRespawnData.checkpointIndex = spawnCheckpoint.index;
                PlayerRespawnData.checkpointLocation = spawnPosition;
            }
        }
    }

    public void respawnPlayer() {
        this.playerTransform.position = PlayerRespawnData.checkpointLocation;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) this.respawnPlayer();
    }
}
