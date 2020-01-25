using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    float distance;
    float throwForce = 500;
    public System.DateTime startTime;

    Vector3 basicScale;
    bool touched;
    bool holded;

    private void Start()
    {
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
                touched = true;
            else
                touched = false;
        }

        if (touched)
        {
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            this.transform.position = objPosition;

            if (Input.GetMouseButtonDown(1))
            {
                startTime = System.DateTime.UtcNow;
                holded = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                int holdingBonus = (System.DateTime.UtcNow - startTime).Milliseconds/100;
                if (holdingBonus > 1000)
                    holdingBonus = 1000;

                GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * throwForce * holdingBonus);
                touched = false;
                holded = false;
                transform.localScale = basicScale;
            }
        }

        if (holded && (transform.localScale.x < 2 * basicScale.x))
            transform.localScale += new Vector3(0.03f, 0.03f, 0.03f);
    }
}