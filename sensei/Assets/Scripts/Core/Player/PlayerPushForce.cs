using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushForce : MonoBehaviour
{
    float impulsePower = 10;
    void OnCollisionEnter(Collision other)
    {
        if (other.rigidbody == null)
        {
            return;
        }

        var alwaysPush = other.gameObject.GetComponent<AlwaysApplyPushForce>();
        
        if (!Input.GetKey(KeyCode.LeftShift) && alwaysPush == null)
        {
            return;
        }
        
        other.rigidbody.AddForceAtPosition(GetComponent<Rigidbody>().velocity 
                                 * impulsePower * (alwaysPush != null ? alwaysPush.impulseScale : 1), 
            transform.position, ForceMode.Impulse);
    }
}
