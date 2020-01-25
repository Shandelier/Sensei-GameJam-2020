using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    Transform playerTransform;
    Vector3 checkpointLocation = new Vector3();
    int checkpointIndex = -1;

    void Start() {
        this.playerTransform = this.GetComponent<Transform>();
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Spawnpoint") {
            SpawnCheckpoint spawnCheckpoint = other.GetComponent<SpawnCheckpoint>();

            if(this.checkpointIndex != spawnCheckpoint.index) {

                this.checkpointIndex = spawnCheckpoint.index;
                this.checkpointLocation = new Vector3(spawnCheckpoint.spawnX, spawnCheckpoint.spawnY, spawnCheckpoint.spawnZ);
            }
        }
    }

    public void respawnPlayer() {
        this.playerTransform.position = checkpointLocation;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) this.respawnPlayer();
    }
}
