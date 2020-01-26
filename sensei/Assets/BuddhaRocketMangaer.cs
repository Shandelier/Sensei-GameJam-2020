using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddhaRocketMangaer : MonoBehaviour
{
    public GameObject buddha1;
    public GameObject buddha2;
    public GameObject buddha3;
    bool playOnce = true;

    public void Update() {
        if(Input.GetKeyDown(KeyCode.L)) {
            GameObject player = GameObject.FindGameObjectsWithTag("PlayerTag")[0];
            player.GetComponent<Transform>().position = new Vector3(-287.7f, 50f, -501.1214f);
        }
    }

    void OnCollisionEnter(Collision other) {
        if (this.playOnce) {
            this.playOnce = false;
            Debug.Log("aaaaa");
            if(other.collider.tag == "PlayerTag") {
            Debug.Log("bbbbb");
                
            }
        }
        
    }
}
