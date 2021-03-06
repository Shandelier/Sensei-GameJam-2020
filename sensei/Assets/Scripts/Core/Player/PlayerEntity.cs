using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerEntity : MonoBehaviour {

    [Inject] WorldPuzzle worldPuzzle = null;
    float counter = 0f;
    
    public UnityEvent died = new UnityEvent();

    void Start()
    {
        gameObject.AddComponent<PlayerPushForce>();
    }

    public void Update() {
        this.counter += Time.deltaTime;

        if (this.counter > TimeUtils.TIMES_1_PER_SECOND) {
            this.worldPuzzle.checkForMatchingWithPuzzles();
            this.resetCounter();
        }

        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, Mathf.Lerp(80, 100, Mathf.InverseLerp(0, 30, GetComponent<Rigidbody>().velocity.magnitude)), 0.1f);
    }

    private void resetCounter() {
        this.counter = 0f;
    }
}