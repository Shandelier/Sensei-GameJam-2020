using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class CopyTransform : MonoBehaviour
{
    public Transform from;
    public Transform to;
    
    // Start is call
    void Start()
    {
        if (to == null)
        {
            to = transform;
        }
    }
    
    void Update()
    {
        to.position = from.position;
        to.rotation = from.rotation;
    }
}
