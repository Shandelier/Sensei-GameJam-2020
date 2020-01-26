using System.Collections;
using System.Collections.Generic;
using Zenject;
using UnityEngine;
using WLF;

namespace WLF {

    public class LifetimeClock: MonoBehaviour {

        public float lifetime = 1f;
        float time = 0f;

        void Update() {
            if (this.gameObject.activeInHierarchy) {
                this.time += Time.deltaTime;

                if(this.time > this.lifetime) {
                    Pooler.returnObjectToPool(this.gameObject);
                    this.time = 0f;
                }
            }
        }
    }
}
