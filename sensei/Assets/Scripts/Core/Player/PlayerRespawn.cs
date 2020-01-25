using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Debug.Log(other);
    }
}
