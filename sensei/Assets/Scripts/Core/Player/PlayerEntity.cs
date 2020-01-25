using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerEntity : MonoBehaviour {

    [Inject] WorldPuzzle worldPuzzle = null;
    float counter = 0f;

    public void Update() {
        this.counter += Time.deltaTime;

        if (this.counter > TimeUtils.TIMES_1_PER_SECOND) {
            this.worldPuzzle.checkForMatchingWithPuzzles();
            this.resetCounter();
        }
    }

    private void resetCounter() {
        this.counter = 0f;
    }
}