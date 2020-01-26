using System.Collections;
using System.Collections.Generic;
using Core.SoundManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public interface IGrapplingHookable
{
    Vector3 GetTargetPoint(RaycastHit hit, GameObject player);
    Vector3 GetVisualTargetPoint(RaycastHit hit, GameObject player);
}

public class GrapplingHook : MonoBehaviour
{
    float speed = 60;
    float maxDistance = 100;
    float springStrength = 20;
    float springDistanceFactor = 0.5f;
    bool isAttached;
    bool isLaunched;
    Vector3 handOffset = new Vector3(0.3f, 0, 0.7f);

    [SerializeField] public GameObject rightHand;

    LineRenderer line;
    Rigidbody rb;
    UnityEvent released = new UnityEvent();

    float hookDistance;
    Vector3 hookPosition;
    Vector3 hookVelocity;
    Vector3 attachedPoint;
    Vector3 visualAttachedPoint;
    
    void Start()
    {
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
 
        var player = GetComponent<PlayerEntity>();
        player.died.AddListener(OnDied);
    }

    void OnDied()
    {
        if (isLaunched)
        {
            isLaunched = false;
        } 
        else if (isAttached)
        {
            isAttached = false;
            released.Invoke();
        }
    }
    
    void Update()
    {
        if (line == null)
        {
            return;
        }
        
        if (isAttached || isLaunched)
        {
            line.enabled = true;
            line.positionCount = 2;
            line.SetPosition(0, transform.TransformPoint(handOffset));
            if (isAttached)
            {
                line.SetPosition(1, visualAttachedPoint);
            }
            else
            {
                line.SetPosition(1, hookPosition);
            }
        }
        else
        {
            line.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isAttached)
            {
                isAttached = false;
                released.Invoke();
            }
        }

        
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.E))
        {
            if (isLaunched)
            {
                isLaunched = false;
                Debug.Log("Launch Cancelled");
                rightHand.SetActive(true);
            }
            else if (isAttached)
            {
                isAttached = false;
                released.Invoke();
                Debug.Log("Hook Detached");
                rightHand.SetActive(true);
            }
            else
            {
                SoundManager.PlaySound(SoundManager.Sound.Throw);
                isLaunched = true;
                hookPosition = Camera.main.transform.position;
                hookVelocity = Camera.main.transform.forward * speed;
                rightHand.SetActive(false);
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
                if (hit.collider.gameObject.tag != "PlayerTag" && !hit.collider.isTrigger)
                {
                    Debug.Log("Hooked!");
                    
                    var handler = hit.collider.GetComponent<IGrapplingHookable>();
                    if (handler != null)
                    {
                        attachedPoint = handler.GetTargetPoint(hit, gameObject);
                        visualAttachedPoint = handler.GetVisualTargetPoint(hit, gameObject);
                    }
                    else
                    {
                        attachedPoint = visualAttachedPoint = hit.point;
                    }

                    hookPosition = attachedPoint;
                    hookDistance = Vector3.Distance(attachedPoint, Camera.main.transform.position) * springDistanceFactor;
                    SoundManager.PlaySound(SoundManager.Sound.Whip);
                    isAttached = true;
                    isLaunched = false;
                    break;
                }
            }
        }

        if (isAttached)
        {
            var dist = Vector3.Distance(transform.position, attachedPoint);
            if (dist > hookDistance)
            {
                rb.AddForce((attachedPoint - transform.position) * springStrength);
            }
        }
    }
}
