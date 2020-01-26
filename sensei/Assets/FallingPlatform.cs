using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx.Async;

public class FallingPlatform : MonoBehaviour
{
    Vector3 originalPosition;
    Transform transform;
    bool isFalling = false;

    void Start() {
        this.transform = this.GetComponent<Transform>();
        this.originalPosition = this.transform.position;
    }

    void OnCollisionEnter(Collision other) {

        if(!this.isFalling) {
            this.isFalling = true;
            this.fallDown();
        }
        
    }

    private async UniTask fallDown() {
        Debug.Log("bbbbb");
        Rigidbody objRigibdoby = this.GetComponent<Rigidbody>();
        await UniTask.Delay(1000, ignoreTimeScale: false);

        objRigibdoby.isKinematic = false;
        objRigibdoby.useGravity = true;
        objRigibdoby.AddForce(new Vector3(0, 100, 0), ForceMode.Impulse);

        await UniTask.Delay(10000, ignoreTimeScale: false);;

        this.isFalling = false;
        objRigibdoby.useGravity = false;
        objRigibdoby.isKinematic = true;
        this.transform.position = this.originalPosition;
        
    }
}
