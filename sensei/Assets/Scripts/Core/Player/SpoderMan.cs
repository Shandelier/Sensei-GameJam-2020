using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpoderMan : MonoBehaviour
{
    float speed = 60;
    float maxDistance = 100;
    float springStrength = 20;
    float springDistanceFactor = 0.5f;
    bool isHooked;
    bool isLaunched;
    Vector3 handOffset = new Vector3(0.3f, 0, 0.7f);

    LineRenderer line;
    Rigidbody rb;

    float hookDistance;
    Vector3 hookPosition;
    Vector3 hookVelocity;
    Vector3 hookPoint;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (line == null)
        {
            return;
        }
        
        if (isHooked || isLaunched)
        {
            line.enabled = true;
            line.positionCount = 2;
            line.SetPosition(0, transform.TransformPoint(handOffset));
            line.SetPosition(1, hookPosition);
        }
        else
        {
            line.enabled = false;
        }

        
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isLaunched)
            {
                isLaunched = false;
                Debug.Log("Launch Cancelled");
            } 
            else if (isHooked)
            {
                isHooked = false;
                Debug.Log("Hook Detached");
            }
            else
            {
                isLaunched = true;
                hookPosition = Camera.main.transform.position;
                hookVelocity = Camera.main.transform.forward * speed;
            }
        }

        if (isLaunched)
        {
            var hits = Physics.RaycastAll(hookPosition, hookVelocity.normalized, 
                 hookVelocity.magnitude * Time.deltaTime);

            hookPosition += hookVelocity * Time.deltaTime;
            
            if (Vector3.Distance(hookPosition, Camera.main.transform.position) > maxDistance)
            {
                isLaunched = false;
                return;
            }
            
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.tag != "PlayerTag")
                {
                    Debug.Log("Hooked!");
                    hookPoint = hit.point;
                    hookPosition = hookPoint;
                    hookDistance = Vector3.Distance(hookPoint, Camera.main.transform.position) * springDistanceFactor;
                    isHooked = true;
                    isLaunched = false;
                    break;
                }
            }
        }

        if (isHooked)
        {
            var dist = Vector3.Distance(transform.position, hookPoint);
            if (dist > hookDistance)
            {
                Debug.Log("Apply force " + dist);
                rb.AddForce((hookPoint - transform.position) * springStrength);
            }
        }
    }
}
