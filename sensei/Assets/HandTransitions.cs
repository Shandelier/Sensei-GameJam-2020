using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTransitions : MonoBehaviour
{
    public static Animator handAnimitor;

    bool defaultIdle;

    private void Start()
    {
        handAnimitor = GetComponent<Animator>();
        defaultIdle = true;
    }

    private void Update()
    {
        /*
        if (Input.GetMouseButton(0) && defaultIdle)
        {
            handAnimitor.Play("Armature|Grab", 0);
            //handAnimitor.SetTrigger("Grab (LPM)");
            defaultIdle = false;
        }
        else if (Input.GetMouseButton(0) && !defaultIdle)
        {
            handAnimitor.Play("Armature|Default_Idle", 0);
            //handAnimitor.SetTrigger("Grab (LPM)");
            defaultIdle = true;
        }
        else if (Input.GetMouseButton(1) && !defaultIdle)
        {
            handAnimitor.Play("Armature|Throw", 0);
            //handAnimitor.SetTrigger("Throw (PPM)");
            defaultIdle = true;
        }
        */
    }

    public static void playThrow()
    {
        handAnimitor.Play("Armature|Throw", 0);
    }

    public static void playGrab()
    {
        handAnimitor.Play("Armature|Grab", 0);
    }

    public static void playRelease()
    {
        handAnimitor.Play("Armature|Default_Idle", 0);
    }
    
}
