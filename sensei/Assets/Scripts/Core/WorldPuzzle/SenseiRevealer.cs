using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseiRevealer : MonoBehaviour
{
    public GameObject sensei;

    Material material;
    bool hasStartedRevealing = false;
    float startTime = -999;
    private bool alreadyVisited = false; 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTag" && !alreadyVisited )
        {
            Reveal();
            alreadyVisited = true;
        }
    }


    void Start()
    {
        var render = sensei.GetComponent<MeshRenderer>();
        render.material = material = Instantiate(render.material);
    }

    public void Reveal()
    {
        startTime = Time.time;
        hasStartedRevealing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStartedRevealing)
        {
            material.SetFloat("_Reveal", Time.time - startTime);
        }
    }
}
