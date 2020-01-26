using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.Async.Triggers;
using UnityEngine;

public class PlayerMoveWithPlatform : MonoBehaviour
{
    Vector3 positionDelta;
    Vector3 lastPosition;

    Vector3 contactOffset;

    GameObject player;

    void ResetDeltaTransform()
    {
        lastPosition = transform.TransformPoint(contactOffset);
    }

    void UpdateDeltaTransform()
    {
        var newPosition = transform.TransformPoint(contactOffset);
        positionDelta = newPosition - lastPosition;
        lastPosition = newPosition;
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerTag")
        {
            player = other.gameObject;
        }
        else
        {
            return;
        }

        contactOffset = transform.InverseTransformPoint(other.contacts[0].point);
        ResetDeltaTransform();
    }

    void OnCollisionExit(Collision other)
    {
        if (player != null)
        {
            player = null;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

        UpdateDeltaTransform();
        Debug.Log($"DELTA {positionDelta}");
        player.transform.position += positionDelta;
    }
}
