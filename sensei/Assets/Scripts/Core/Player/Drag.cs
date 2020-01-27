using System.Collections;
using System.Collections.Generic;
using Core.SoundManager;
using Core.Player;
using UnityEngine;
using UnityEngine.Events;

public class Drag : MonoBehaviour
{
    float distance;
    float throwForce = 10;
    public System.DateTime startTime;

    public UnityEvent dragged;

    Vector3 basicScale;
    bool touched;
    bool holded;
    private Collider col;
    private Rigidbody rb;
    private bool willFreeze = false;

    private void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        basicScale = transform.localScale;
        touched = false;
        holded = false;
    }

    private void Update()
    {
        distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        if (Input.GetMouseButtonDown(0) && distance <= 2.5)
        {
            if (!touched)
            {
                HandTransitions.playGrab();
                touched = true;
                col.enabled = false;
                rb.useGravity = false;
            }
            else if (willFreeze){
                HandTransitions.playRelease();
                touched = false;
                col.enabled = true;
                rb.useGravity = true;
                gameObject.AddComponent<FrozenObjectState>();
                willFreeze = false;
            }
            else
            {
                HandTransitions.playRelease();
                touched = false;
                col.enabled = true;
                rb.useGravity = true;
            }
        }

        if (touched)
        {
            dragged.Invoke();
            
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = objPosition;

            if(Input.GetKeyDown(KeyCode.F)){
                willFreeze = !willFreeze;
            }

            if (Input.GetMouseButtonDown(1))
            {
                startTime = System.DateTime.UtcNow;
                holded = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                HandTransitions.playThrow();
                float holdingBonus = .2f;
                holdingBonus += (System.DateTime.UtcNow - startTime).Milliseconds/100;
                if (holdingBonus > 1000)
                    holdingBonus = 1000;

                rb.AddForce(Camera.main.transform.forward * throwForce * holdingBonus * rb.mass, ForceMode.Impulse);
                StartCoroutine(ChangeBackMass(rb, holdingBonus/100f));
                touched = false;
                holded = false;
                col.enabled = true;
                transform.localScale = basicScale;
                SoundManager.PlaySound(SoundManager.Sound.Throw);
            }
        }

        if (holded && (transform.localScale.x < 2 * basicScale.x))
            transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
    }
    IEnumerator ChangeBackMass(Rigidbody rb, float waitTime){
      
        yield return new WaitForSeconds(.2f + waitTime);
        rb.useGravity = true;
        if(willFreeze)
            gameObject.AddComponent<FrozenObjectState>();
            
            willFreeze = false;

    }
}