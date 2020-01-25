using System.Collections;
using System.Collections.Generic;
using Core.Player;
using UnityEngine;

public class SwingingPlatform : MonoBehaviour
{
    public float swingSpeed = 1;
    public float swingAmplitude = 6;

    public float swingOffset = 0;
    public Transform targetPivot;
    public GameObject body;
    public Vector3 axis = new Vector3(1, 0, 0);

    float time;
    
    // Start is called before the first frame update
    void Start()
    {
        time += swingOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPivot == null)
        {
            targetPivot = transform;
        }

        if (body == null)
        {
            body = GetComponentInChildren<Rigidbody>()?.gameObject;
        }

        if (body != null && body.GetComponent<FrozenObjectState>() != null)
        {
            return;
        }
        
        targetPivot.localRotation = Quaternion.AngleAxis( Mathf.Sin(time) * swingAmplitude, axis);
        time += swingSpeed * Time.deltaTime;
    }
}
