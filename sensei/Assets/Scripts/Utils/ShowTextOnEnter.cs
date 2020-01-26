using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTextOnEnter : MonoBehaviour
{
    public string text;
    public float duration = 2;
    void OnTriggerEnter(Collider other)
    {
        LectorController.Get.Show(0, duration, text);
    }
}
