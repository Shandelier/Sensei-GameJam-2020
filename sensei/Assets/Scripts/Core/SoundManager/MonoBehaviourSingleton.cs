using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
{ 
    static T instance;

    public static T Get {
        get{
            if (instance == null){
                instance = FindObjectOfType<T>();
            }
            return instance;
        }
    }

    private void OnDestroy() {
        instance = null;    
    }

}
