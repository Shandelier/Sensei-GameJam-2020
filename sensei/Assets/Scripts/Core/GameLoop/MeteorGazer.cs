using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using WLF;

public class MeteorGazer : MonoBehaviour
{
    Vector3 meteorPosition;
    float counter = 0f;
    public GameObject meteor;

    public void Start() {
        this.meteorPosition = GetComponent<Transform>().position;     
    }

    public void Update() {
        this.counter += Time.deltaTime;

        if (this.counter > 1f) {
            Vector3 shootPosition = meteorPosition;
            GameObject objectFromPool = Pooler.getObjectFromPool(Pooler.METEOR);

            if(objectFromPool != null) {
                objectFromPool.transform.position = shootPosition;
                objectFromPool.SetActive(true);
            }
        }
    }



}
