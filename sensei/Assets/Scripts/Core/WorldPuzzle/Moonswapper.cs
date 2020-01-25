using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Moonswapper : MonoBehaviour
{
    public GameObject moon;
    public GameObject ball;

    float alignTime;
    bool hasSwapped;

    void Start()
    {
        ball.GetComponent<Drag>().dragged.AddListener(OnMoonDragged);
    }

    void OnMoonDragged()
    {
        if (hasSwapped)
        {
            return;
        }
        
        var ballDir = ball.transform.position - Camera.main.transform.position;
        var moonDir = moon.transform.position - Camera.main.transform.position;

        if (Vector3.Angle(ballDir, moonDir) < 3)
        {
            alignTime += Time.deltaTime;
            if (alignTime > 0.1)
            {
                Swap();
            }
        }
    }

    void Swap()
    {
        ball.GetComponent<Rigidbody>().mass = 1000;
        var ballMaterial = ball.GetComponent<Renderer>().material;
        var moonMaterial = moon.GetComponent<Renderer>().material;
        ball.GetComponent<Renderer>().material = moonMaterial;
        moon.GetComponent<Renderer>().material = ballMaterial;
        //todo change material;
        hasSwapped = true;
        Debug.Log("Moon swapped");
    }
}
