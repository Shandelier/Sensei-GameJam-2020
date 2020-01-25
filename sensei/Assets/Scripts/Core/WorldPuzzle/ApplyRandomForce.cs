using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyRandomForce : MonoBehaviour
{
    public float speed = 1;
    public float strength = 1;
    
    float time;
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(
            Noise.SimplexValue1D(Vector3.up * time, 1).value,
            Noise.SimplexValue1D(Vector3.right * time, 1).value,
            Noise.SimplexValue1D(Vector3.forward * time, 1).value
        ) * strength);
        
        time += Time.deltaTime * speed;
    }
}
