using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHookAid : MonoBehaviour, IGrapplingHookable
{
    public Transform grapTarget;

    public Vector3 GetTargetPoint(RaycastHit hit, GameObject player)
    {
        return grapTarget.transform.position;
    }

    public Vector3 GetVisualTargetPoint(RaycastHit hit, GameObject player)
    {
        return grapTarget.transform.position;
    }
}
