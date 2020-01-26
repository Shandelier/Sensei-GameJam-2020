using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookEnabler : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerTag")
        {
            other.gameObject.GetComponent<GrapplingHook>().enabled = true;
        }
    }

}
