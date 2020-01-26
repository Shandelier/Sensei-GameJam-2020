using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.SoundManager;
using UniRx.Async;

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

    private async UniTask OnCollisionEnter(Collision other) {
        if (this.playOnce) {
            Debug.Log("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            if(other.gameObject.tag == "PlayerTag") {
                this.playOnce = false;
                Debug.Log("YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");

                await UniTask.Delay(8000, ignoreTimeScale: false);

                SoundManager.PlayMusic(SoundManager.Music.ducktales);
                
                await UniTask.Delay(2000, ignoreTimeScale: false);

                this.buddha1.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0), ForceMode.Acceleration);

                await UniTask.Delay(1000, ignoreTimeScale: false);

                this.buddha1.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10000, 0), ForceMode.Acceleration);
                this.buddha2.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0), ForceMode.Acceleration);

                await UniTask.Delay(1000, ignoreTimeScale: false);

                this.buddha2.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10000, 0), ForceMode.Acceleration);
                this.buddha3.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0), ForceMode.Acceleration);

                await UniTask.Delay(1000, ignoreTimeScale: false);

                this.buddha3.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10000, 0), ForceMode.Acceleration);
                
            }
        }
        
    }
}
